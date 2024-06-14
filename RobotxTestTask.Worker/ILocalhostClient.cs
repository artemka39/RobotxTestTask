using Refit;
using RobotxTestTask.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotxTestTask.Worker
{
    public interface ILocalhostClient
    {
        [Get("/cards/{cardCode}")]
        Task<Card> GetCard([Query] int cardCode);

        [Post("/cards/add")]
        [Headers("Content-Type: application/json")]
        Task AddCard([Body] Card card);

        [Post("/cards/update")]
        Task UpdateCard([Body] Card card);
    }
}
