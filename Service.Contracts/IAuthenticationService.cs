using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(EmployeeRegistrationDto userForRegistration);
        Task<bool> ValidateUser(EmployeeAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
