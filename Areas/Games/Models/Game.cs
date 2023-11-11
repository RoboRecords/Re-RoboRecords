using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReRoboRecords.Areas.Games.Models
{
    public class Game
    {
        /// <summary>
        /// Id of the Game.
        /// </summary>
        public int GameId { get; set; }
        
        /// <summary>
        /// Name of the Game.
        /// </summary>
        [Required]
        public string Title { get; set; }
        
        /// <summary>
        /// Path of the image for the game.
        /// </summary>
        public string? GameImagePath { get; set; }
        
        /// <summary>
        /// Version of the Game. Should be in the format of X.X. 2.2 or 2.1.
        /// </summary>
        public float GameVersion { get; set; }
        
        /// <summary>
        /// Description of the Game.
        /// </summary>
        public string Description { get; set;}
        
        /// <summary>
        /// Release date of the Game.
        /// </summary>
        public string ReleaseDate { get; set; }
        
        /// <summary>
        /// Privacy state. If private, should be hidden to non-admins.
        /// </summary>
        public bool IsPrivate { get; set; }
        
        /// <summary>
        /// Categories of the game.
        /// </summary>
        public List<Category> Categories { get; set; }

    }
}