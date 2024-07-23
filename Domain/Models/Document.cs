using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Document
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public DateTime UploadedAt { get; set; }

        public UserTask Task { get; set; }
    }
}
