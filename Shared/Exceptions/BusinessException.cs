using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() : base("Unauthorized access.")
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public static BusinessException CreateEmployeeDoesNoteHaveAccessToAddNoteException(Guid employeeId)
        {
            return new BusinessException($"Employee with the following id does not have access to add a note: {employeeId}");
        }

        public static BusinessException CreateInvalidTaskStatus(string messsage)
        {
            return new BusinessException(messsage);
        }
    }
}
