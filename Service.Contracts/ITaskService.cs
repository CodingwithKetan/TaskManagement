using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ITaskService
    {
        Task<TaskBaseDto> CreateTaskAsync(TaskCreateRequest taskCreateDto);
        Task<IEnumerable<TaskBaseDto>> GetTasksAssignedTo(Guid employeeId);
        Task<IEnumerable<TaskBaseDto>> GetTasksCreatedBy(Guid employeeId);
        Task<IEnumerable<TaskBaseDto>> GetTasksDueByDateAsync(DateTime dueDate);
        Task<TaskBaseDto> GetTaskByIdAsync(Guid id);
        Task UpdateTaskStatusAsync(TaskStatusUpdateDto taskUpdateStatusDto);
        Task AddNoteToTaskAsync(TaskAddNotRequest taskAddNoteDto);
        Task UploadFileToTaskAsync(Guid taskId, UploadFileDto uploadFileDto);
        Task<DocumentDto> GetDocumentByIdAsync(Guid documentId);
    }
}
