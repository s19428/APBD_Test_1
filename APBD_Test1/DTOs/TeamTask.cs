using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Test1.DTOs
{
    //name of the task, description, deadline, name of the project this task is a part of and the task type

    public class TeamTask
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string deadline { get; set; }

        [Required]
        public string projectName { get; set; }

        [Required]
        public string taskType { get; set; }
    }
}