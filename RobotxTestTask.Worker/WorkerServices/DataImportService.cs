using ExcelDataReader;
using RobotxTestTask.Common.Models;
using RobotxTestTask.Data;
using RobotxTestTask.Worker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReobotxTestTask.Core.Services
{
    public class DataImportService
    {
        private readonly IServiceProvider serviceProvider;
        public DataImportService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task ImportData(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.OpenRead(path))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    foreach (DataTable table in result.Tables)
                    {
                        for (int i = 1; i < table.Rows.Count; i++)
                        {
                            await AddOrUpdateCard(table.Rows[i].ItemArray);
                        }
                    }
                }
            }
        }

        private async Task AddOrUpdateCard(object[] row)
        {
            var card = MapData(row);
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;
            var cardService = services.GetService<CardService>();
            await cardService.AddCard(card);
        }

        private Card MapData(object[] row)
        {
            return new Card
            {
                CardCode = Convert.ToInt32(row[0]),
                LastName = row[1] != DBNull.Value ? (string)row[1] : default,
                FirstName = row[2] != DBNull.Value ? (string)row[2] : default,
                SurName = row[3] != DBNull.Value ? (string)row[3] : default,
                PhoneMobile = row[4] != DBNull.Value ? (string)row[4] : default,
                Email = row[5] != DBNull.Value ? (string)row[5] : default,
                GenderId = row[6] != DBNull.Value ? (string)row[6] : default,
                Birthday = row[7] != DBNull.Value ? Convert.ToDateTime(row[7]) : default,
                City = row[8] != DBNull.Value ? (string)row[8] : default,
                Pincode = row[9] != DBNull.Value ? Convert.ToInt32(row[9]) : default,
                Bonus = row[10] != DBNull.Value ? Convert.ToInt32(row[10]) : default,
                Turnover = row[11] != DBNull.Value ? Convert.ToInt32(row[11]) : default
            };
        }
    }
}
