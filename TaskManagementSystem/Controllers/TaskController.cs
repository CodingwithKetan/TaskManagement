using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.CommonModels;
using Shared.DataTransferObjects;
using Shared.Exceptions;
using Shared.Utils;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Controllers
{
    [Route("api/task")]
    [Authorize]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Authorize(Roles = "Manager,Admin")]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateRequest taskCreateDto)
        {
            var validationMessages = taskCreateDto.Validate();
            if (validationMessages.Any())
            {
                throw new ValidationFailedException(validationMessages.JoinUsing(","));
            }

            var createdTask = await _taskService.CreateTaskAsync(taskCreateDto);
            return Ok(createdTask);
        }

        
        [HttpPost("{taskId}/note-by/{employeeId}")]
        public async Task<IActionResult> AddNoteToTask(Guid taskId, Guid employeeId, [FromBody] string note)
        {
            var taskAddNoteDto = new TaskAddNotRequest
            {
                TaskId = taskId,
                CreatedBy = employeeId,
                Content = note
            };

            taskAddNoteDto.Validate();
            await _taskService.AddNoteToTaskAsync(taskAddNoteDto);
            return NoContent();
        }

        [HttpPost("{taskId}/add-document")]
        public async Task<IActionResult> AddDocument(Guid taskId, [FromForm] UploadFileDto uploadFileDto)
        {
            uploadFileDto.Validate();
            await _taskService.UploadFileToTaskAsync(taskId, uploadFileDto);
            return NoContent();
        }

        [HttpGet("assigned-to/{employeeId}")]
        public async Task<IActionResult> GetTasksAssigneTo(Guid employeeId)
        {
            var tasks = await _taskService.GetTasksAssignedTo(employeeId);
            return Ok(tasks);
        }

        [HttpGet("created-by/{employeeId}")]
        public async Task<IActionResult> GetTasksCreatedBy(Guid employeeId)
        {
            var tasks = await _taskService.GetTasksCreatedBy(employeeId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return Ok(task);
        }

        [HttpPut("{taskId}/status")]
        public async Task<IActionResult> UpdateTaskStatus(Guid taskId, string status)
        {
            var taskStatusUpdateDto = new TaskStatusUpdateDto
            {
                TaskId = taskId,
                Status = status
            };

            taskStatusUpdateDto.Validate();
          
            await _taskService.UpdateTaskStatusAsync(taskStatusUpdateDto);
            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("due")]
        public async Task<IActionResult> GetTasksDueByRange([FromQuery] string dateRange)
        {
            if (!dateRange.IsValidEnum<DateRange>())
            {
                return BadRequest("Invalid date range specified.");
            }
            var dueDate = dateRange.ToEnumOrDefault(DateRange.Weekly).CalculateDueDate();
            var tasks = await _taskService.GetTasksDueByDateAsync(dueDate);
            return Ok(tasks);
        }

        [HttpGet("document/{documentId}/download")]
        public async Task<IActionResult> GetDocument(Guid taskId, Guid documentId)
        {
            var documentDto = await _taskService.GetDocumentByIdAsync(documentId);

            if (documentDto == null)
            {
                return NotFound();
            }

            return File(documentDto.FileContent, "application/octet-stream", documentDto.FileName);  
        }

    }
}
