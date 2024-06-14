using Microsoft.EntityFrameworkCore;
using RobotxTestTask.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotxTestTask.Data.DataServices
{
    public class CardDataService
    {
        private readonly TestTaskDbContext dbContext;
        public CardDataService(TestTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Card>> GetCards()
        {
            var cards = await dbContext.Cards.ToListAsync();
            return cards;
        }

        public async Task<Card> GetCard(int cardCode)
        {
            var card = await dbContext.Cards.FirstOrDefaultAsync(c => c.CardCode == cardCode);
            return card;
        }

        public async Task AddCard(Card card)
        {
            await dbContext.Cards.AddAsync(card);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateCard(Card card)
        {
            dbContext.Cards.Update(card);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCard(int cardCode)
        {
            var cardToRemove = await GetCard(cardCode);
            dbContext.Cards.Remove(cardToRemove);
            await dbContext.SaveChangesAsync();
        }
    }
}
