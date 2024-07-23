using AutoMapper;
using Domain.Models;
using Repository.Contracts;
using Service.Contracts;
using Service.Validators;
using Shared.DataTransferObjects;
using Shared.Exceptions;
using Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeValidator _employeeValidator;
        private readonly TaskValidator _taskValidator;

        public TaskService(ITaskRepository taskRepository, INoteRepository noteRepository,  IMapper mapper, IEmployeeRepository employeeRepository, IDocumentRepository documentRepository)
        {
            _taskRepository = taskRepository;
            _noteRepository = noteRepository;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _documentRepository = documentRepository;
            _employeeValidator = new EmployeeValidator(_employeeRepository);
            _taskValidator = new TaskValidator(_taskRepository);    
        }

        public async Task<TaskBaseDto> CreateTaskAsync(TaskCreateRequest taskCreateDto)
        {
            var task = _mapper.Map<UserTask>(taskCreateDto);
            await _employeeValidator.ValidateEmployeesExists(task.GetAssociatedEmployeeIds());
            task.Status = UserTaskStatus.NotStarted; // Default status
            task.CreatedDate = DateTimeUtils.GetCurrentTimeInUTC();
            await _taskRepository.CreateAsync(task);
            return _mapper.Map<TaskBaseDto>(task);
        }

        public async Task AddNoteToTaskAsync(TaskAddNotRequest taskAddNoteDto)
        {
            var note = new Note
            {
                TaskId = taskAddNoteDto.TaskId,
                Content = taskAddNoteDto.Content,
                CreatedDate = DateTimeUtils.GetCurrentTimeInUTC(),
                AddedBy = taskAddNoteDto.CreatedBy,
            };

            ValidateNoteToAdd(note);

            await _noteRepository.CreateAsync(note);
        }

        public async Task<IEnumerable<TaskBaseDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetTasksWithDetailsAsync();
            return _mapper.Map<IEnumerable<TaskBaseDto>>(tasks);
        }

        public async Task<TaskBaseDto> GetTaskByIdAsync(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if(task == null){
                throw EntityNotFoundException.CreateTaskNotFoundException(id);
            }
            return _mapper.Map<TaskBaseDto>(task);
        }

        public async Task<IEnumerable<TaskBaseDto>> GetTasksAssignedTo(Guid employeeId)
        {
            var tasks = await _taskRepository.GetTasksAssignedTo(employeeId);
            return _mapper.Map<IEnumerable<TaskBaseDto>>(tasks);
        }

        public async Task<IEnumerable<TaskBaseDto>> GetTasksCreatedBy(Guid employeeId)
        {
            var tasks = await _taskRepository.GetTasksCreatedBy(employeeId);
            return _mapper.Map<IEnumerable<TaskBaseDto>>(tasks);
        }

        public async Task UpdateTaskStatusAsync(TaskStatusUpdateDto taskUpdateStatusDto)
        {
            var task = await _taskRepository.GetByIdAsync(taskUpdateStatusDto.TaskId);
            if (task == null) {
                throw EntityNotFoundException.CreateTaskNotFoundException(taskUpdateStatusDto.TaskId);
            }
            if (taskUpdateStatusDto.Status.IsValidEnum<UserTaskStatus>()){
                string errorMessage = $"Invalid status : {taskUpdateStatusDto.Status}";
                throw new BusinessException(errorMessage);
            }
            task.Status = taskUpdateStatusDto.Status.ToEnumOrDefault(UserTaskStatus.NotStarted);
            await _taskRepository.UpdateAsync(task);
        }

        private async void ValidateNoteToAdd(Note noteToAdd)
        {
          var userTask= await _taskRepository.GetByIdAsync(noteToAdd.TaskId);
          if (!userTask.ValidateEmployeeAbleToEdit(noteToAdd.AddedBy))
          {
             throw BusinessException.CreateEmployeeDoesNoteHaveAccessToAddNoteException(noteToAdd.AddedBy);
          }
        }

        public async Task UploadFileToTaskAsync(Guid taskId, UploadFileDto uploadFileDto)
        {
            if (uploadFileDto.File == null || uploadFileDto.File.Length == 0)
            {
                throw new ArgumentException("No file uploaded.");
            }

            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task == null)
            {
                throw new KeyNotFoundException("Task not found.");
            }

            using (var memoryStream = new MemoryStream())
            {
                await uploadFileDto.File.CopyToAsync(memoryStream);
                var document = new Document
                {
                    Id = Guid.NewGuid(),
                    TaskId = taskId,
                    FileName = uploadFileDto.File.FileName,
                    FileContent = memoryStream.ToArray(),
                    UploadedAt = DateTime.UtcNow
                };

                await _documentRepository.CreateAsync(document);
            }
        }

        public async Task<DocumentDto> GetDocumentByIdAsync(Guid documentId)
        {
            var document = await _documentRepository.GetDocumentByIdAsync(documentId);
            if (document == null)
            {
                throw new KeyNotFoundException("Document not found.");
            }

            return new DocumentDto
            {
                Id = document.Id,
                FileName = document.FileName,
                FileContent = document.FileContent // Avoid sending large binary data directly; handle it appropriately
            };
        }

        public async Task<IEnumerable<TaskBaseDto>> GetTasksDueByDateAsync(DateTime dueDate)
        {
            var tasks = await _taskRepository.GetTasksDueByDateAsync(dueDate);
            return _mapper.Map<IEnumerable<TaskBaseDto>>(tasks);
        }
    }
}

