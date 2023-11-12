using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ReRoboRecords.Areas.Games.Models;

namespace ReRoboRecords.Areas.Leaderboards.Models
{
    public class Category
    {
        [Key] public int CategoryId { get; set; }

        [Required] [StringLength(255)] public string Name { get; set; }
        
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual ICollection<Run> Runs { get; set; }
    }
}