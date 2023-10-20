using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReRoboRecords.Areas.Games.Models;

namespace ReRoboRecords.Areas.Games.Models
{
    public class RulesModel
    {
        /// <summary>
        /// Id of the rules.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Description of the rules.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Category that the rules belong to.
        /// </summary>
        public CategoryModel Category { get; set; }   
    }
}