using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobotxTestTask.Common.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CardCode { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? SurName { get; set; }
        public string? PhoneMobile { get; set; }
        public string? Email { get; set; }
        public string? GenderId { get; set; }
        public DateTime Birthday { get; set; }
        public string? City { get; set; }
        public int Pincode { get; set; }
        public int Bonus { get; set; }
        public int Turnover { get; set; }
    }
}
