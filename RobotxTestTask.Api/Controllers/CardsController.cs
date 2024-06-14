using Microsoft.AspNetCore.Mvc;
using ReobotxTestTask.Core.Services;
using RobotxTestTask.Common.Models;

namespace RobotxTestTask.Api.Controllers
{
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardService cardService;
        public CardsController(CardService dataService)
        {
            this.cardService = dataService;
        }

        [HttpGet]
        [Route("cards")]
        public async Task<IActionResult> GetCards()
        {
            return new JsonResult(await cardService.GetCards());
        }

        [HttpPost]
        [Route("cards/add")]
        public async Task<IActionResult> AddCard([FromBody] Card card)
        {
            await cardService.AddCard(card);
            return Ok();
        }

        [HttpPost]
        [Route("cards/update")]
        public async Task<IActionResult> UpdateCards(List<Card> cards)
        {
            await cardService.UpdateCards(cards);
            return Ok();
        }
    }
}
