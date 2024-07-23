using Shared.Exceptions;
using Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class TaskStatusUpdateDto
    {
        public Guid TaskId { get; set; }
        public string Status { get; set; }

        public void Validate()
        {
            if (Status.IsBlank())
            {
                throw new ValidationFailedException("Status can't be null");
            }
        }
    }
}
