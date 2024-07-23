using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Employee : IdentityUser
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public ICollection<UserTask> Tasks { get; set; }
    }
}
