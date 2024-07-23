using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface ITaskRepository : IRepositoryBase<UserTask>
    {
        Task<IEnumerable<UserTask>> GetTasksWithDetailsAsync();
        Task<UserTask> GetTaskWithDetailsAsync(Guid id);
        Task<IEnumerable<UserTask>> GetTasksAssignedTo(Guid employeeId);
        Task<IEnumerable<UserTask>> GetTasksCreatedBy(Guid employeeId);
        Task<IEnumerable<UserTask>> GetTasksDueByDateAsync(DateTime dueDate);
    }
}
