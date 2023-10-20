using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReRoboRecords.Areas.Games.Models
{
    public class GameModel
    {
        /// <summary>
        /// Id of the Game.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the Game.
        /// </summary>
        [Required]
        public string Name { get; set; }
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
        public List<CategoryModel> Categories { get; set; }

    }
}