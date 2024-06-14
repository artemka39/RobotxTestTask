using Microsoft.EntityFrameworkCore;
using RobotxTestTask.Common.Models;
using RobotxTestTask.Data.DataServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReobotxTestTask.Core.Services
{
    public class CardService
    {
        private readonly CardDataService dataService;
        public CardService(CardDataService dataService)
        {
            this.dataService = dataService;
        }

        public async Task<List<Card>> GetCards()
        {
            return await dataService.GetCards();
        }

        public async Task AddCard(Card card)
        {
            await dataService.AddCard(card);
        }

        public async Task UpdateCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                await dataService.UpdateCard(card);
            }
        }
    }
}
