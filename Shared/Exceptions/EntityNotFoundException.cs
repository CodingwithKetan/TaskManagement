using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("Entity Not Found")
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public static EntityNotFoundException CreateEmployeesNotFoundException(List<Guid> invalidEmployeeIds)
        {
            return new EntityNotFoundException($"Employees with the following ids were not found: {string.Join(", ", invalidEmployeeIds)}");
        }

        public static EntityNotFoundException CreateTaskNotFoundException(Guid invalidTaskId)
        {
            return new EntityNotFoundException($"Task with the following id was not found: {invalidTaskId}");
        }
    }
}
