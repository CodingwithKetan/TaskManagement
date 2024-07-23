using Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class TaskCreateRequest
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedTo { get; set; } 
        public Guid CreatedBy { get; set; }

        public List<string> Validate()
        {
            var validationMessages = new List<string>();
            if (TaskName.IsBlank())
            {
                validationMessages.Add("TaskName Can't be Blank.");
            }

            if (Description.IsBlank())
            {
                validationMessages.Add("TaskName Can't be Blank.");
            }

            if (CreatedBy.ToString().IsBlank())
            {
                validationMessages.Add("Task's creator Id Can't be Blank.");
            }

            if (AssignedTo.ToString().IsBlank())
            {
                validationMessages.Add("AssignedTo Employee Id Can't be Blank.");
            }
            return validationMessages;
        }
    }
}
