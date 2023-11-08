using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReRoboRecords.Areas.Games.Models
{
    public class Category
    {
        /// <summary>
        /// Id of the category.
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Name of the category.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of the category.
        /// </summary>
        public string Description { get; set; }

        
    }
}