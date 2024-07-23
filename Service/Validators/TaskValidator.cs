using Repository.Contracts;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class TaskValidator
    {
        private readonly ITaskRepository _taskRepository;

        public TaskValidator(ITaskRepository taskRepository)
        {
               _taskRepository = taskRepository;
        }

        public void ValidateTaskExists(Guid taskId)
        {
            var task = _taskRepository.GetByIdAsync(taskId);
            if (task == null)
            {
                throw EntityNotFoundException.CreateTaskNotFoundException(taskId);
            }
        }
    }
}
