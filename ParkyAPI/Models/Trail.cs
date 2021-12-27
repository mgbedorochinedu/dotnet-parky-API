using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Models
{
    public class Trail
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public enum DifficultyType { Easy, Moderate, Difficult, Expert }
        public DifficultyType Difficulty { get; set; }

        [ForeignKey("NationalParkId")]
        public int NationalParkId { get; set; }
        public NationalPark NationalPark { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
