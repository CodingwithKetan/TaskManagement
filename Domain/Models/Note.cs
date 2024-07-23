using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid TaskId { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserTask Task { get; set; }
        public Guid AddedBy { get; set; }
    }
}
