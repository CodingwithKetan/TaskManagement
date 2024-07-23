using Domain.Models;
using Repository.Context;
using Repository.Contracts;


namespace Repository
{
    public class TaskRepository : RepositoryBase<UserTask>, ITaskRepository
    {
        public TaskRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<UserTask>> GetTasksAssignedTo(Guid employeeId)
        {
            return await GetAll(_ => _.AssignedTo == employeeId);
        }

        public async Task<IEnumerable<UserTask>> GetTasksCreatedBy(Guid employeeId)
        {
            return await GetAll(_ => _.CreatedBy == employeeId);
        }

        public async Task<IEnumerable<UserTask>> GetTasksDueByDateAsync(DateTime dueDate)
        {
            return await GetAll(_ => _.DueDate <= dueDate && _.Status != UserTaskStatus.Completed);
        }

        public Task<IEnumerable<UserTask>> GetTasksWithDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserTask> GetTaskWithDetailsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
