using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ReRoboRecords.Areas.Leaderboards.Models;

namespace ReRoboRecords.Areas.Games.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; } // Primary key for the Game

        [Required]
        [StringLength(255)]
        public string Title { get; set; } // Name of the Game

        public string GameImagePath { get; set; } // Path of the image for the game

        [Required]
        public string GameVersion { get; set; } // Version of the Game, changed to string for format flexibility

        [StringLength(1000)]
        public string? Description { get; set; } // Description of the Game

        public DateTime ReleaseDate { get; set; } // Release date of the Game, changed to DateTime type

        public bool IsPrivate { get; set; } // Privacy state

        // Navigation properties
        public virtual ICollection<Level> Levels { get; set; } // Collection of levels associated with this game
        public virtual ICollection<Character> Characters { get; set; } // Collection of characters associated with this game
        public virtual ICollection<Run> Runs { get; set; } // Collection of runs associated with this game
        public virtual ICollection<Category> Categories { get; set; } // Collection of categories associated with this game

        // Constructor to initialize the collections
        public Game()
        {
            Levels = new HashSet<Level>();
            Characters = new HashSet<Character>();
            Runs = new HashSet<Run>();
            Categories = new HashSet<Category>();
        }
    }
}