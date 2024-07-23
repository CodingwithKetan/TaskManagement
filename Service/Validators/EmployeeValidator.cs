using Repository.Contracts;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class EmployeeValidator
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeValidator(IEmployeeRepository employeeRepository)
        {
            _repository = employeeRepository;
        }

        public async Task ValidateEmployeesExists(List<Guid> employeeIds)
        {
            var fetchedEmployee =  await _repository.GetAll(_ => employeeIds.Contains(_.EmployeeId));
            var invalidEmployeeIds = employeeIds.Except(fetchedEmployee.Select(_ => _.EmployeeId)).ToList();
            if (invalidEmployeeIds.Any())
            {
                throw EntityNotFoundException.CreateEmployeesNotFoundException(invalidEmployeeIds);
            }
        }
    }
}
