using Shared.Exceptions;
using Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class TaskAddNotRequest
    {
        public Guid TaskId { get; set; }
        public string Content { get; set; }
        public Guid CreatedBy { get; set; }


        public void Validate()
        {
            if (Content.IsBlank())
            {
                throw new ValidationFailedException("Content cannot be blank.");
            }
        }
    }
}
