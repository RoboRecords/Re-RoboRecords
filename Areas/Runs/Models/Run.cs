using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ReRoboRecords.Areas.Runs.Models
{
    public class Run
    {
        /// <summary>
        /// Id of the run.
        /// </summary>
        public Guid RunId { get; set; }
        /// <summary>
        /// Id of the IdentityUser who submitted.
        /// </summary>
        [Required]
        public Guid RunnerId { get; set; }
        /// <summary>
        /// Runner's comment on their run.
        /// </summary>
        public string RunnerComment { get; set;}
        /// <summary>
        /// Date when the run was performed.
        /// </summary>
        public DateTime RunDate { get; set; }
        /// <summary>
        /// Id of the Category the run is for.
        /// </summary>
        public int CategoryId { get; set; }

        // TODO: Add an enum variable that shows the state of the run being verified, pending review or rejected.

    }
}