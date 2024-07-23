using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedTo { get; set; }
        public Guid CreatedBy { get; set; }  
        public UserTaskStatus Status { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Document> Documents { get; set; }
        public Employee AssignedEmployee { get; set; }
        public Employee Creator { get; set; }

        public List<Guid> GetAssociatedEmployeeIds()
        {
            return new List<Guid> { AssignedTo, CreatedBy };
        }

        public bool ValidateEmployeeAbleToEdit(Guid employeeId)
        {
            return employeeId == AssignedTo || employeeId == CreatedBy;
        }
    }
}
