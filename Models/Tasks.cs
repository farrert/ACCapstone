using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OOPCapstone.Models
{
    public class Tasks
    {
        public int ID { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }
        public int TaskStateValue { get; set; }
        public TaskState State
        {
            get { return (TaskState)TaskStateValue; }
            set { TaskStateValue = (int)value; }
        }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
    public enum TaskState
    {
        Incomplete,
        InProgress,
        Complete
    }
}
