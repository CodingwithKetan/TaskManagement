using Microsoft.AspNetCore.Http;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class UploadFileDto
    {
        public IFormFile File { get; set; }

        public void Validate()
        {
            if (File == null || File.Length == 0)
            {
                throw new ValidationFailedException("Invalid file data.");
            }
        }
    }
}
