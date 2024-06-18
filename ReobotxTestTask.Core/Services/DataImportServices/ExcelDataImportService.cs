using ExcelDataReader;
using Microsoft.Extensions.DependencyInjection;
using ReobotxTestTask.Core.Services;
using RobotxTestTask.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotxTestTask.Core.Services
{
    public class ExcelDataImportService
    {
        private readonly IServiceProvider serviceProvider;
        public ExcelDataImportService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task ImportData(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.OpenRead(path);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            foreach (DataTable table in result.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    await AddOrUpdateCard(row);
                }
            }
        }

        private async Task AddOrUpdateCard(DataRow row)
        {
            var card = MapData(row);
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;
            var cardService = services.GetService<CardService>();
            await cardService.AddCard(card);
        }

        private Card MapData(DataRow row)
        {
            return new Card
            {
                CardCode = ToInt(row[0]),
                LastName = row[1].ToString(),
                FirstName = row[2].ToString(),
                SurName = row[3].ToString(),
                PhoneMobile = row[4].ToString(),
                Email = row[5].ToString(),
                GenderId = row[6].ToString(),
                Birthday = ToDateTime(row[7]),
                City = row[8].ToString(),
                Pincode = ToInt(row[9]),
                Bonus = ToInt(row[10]),
                Turnover = ToInt(row[11])
            };
        }
        private int ToInt(object obj)
        {
            return int.TryParse(obj.ToString(), out int res)? res : default;
        }
        private DateTime ToDateTime(object obj)
        {
            return DateTime.TryParse(obj.ToString(), out DateTime res) ? res : default;
        }
    }
}
