using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
               .NotNull()
               .GreaterThan(0).WithMessage("{PropertyValue} must be greater than {ComparisonValue}")
               .LessThan(100).WithMessage("{PropertyValue} must be less than {ComparisonValue}");

            RuleFor(p => p.Period)
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyValue} must be greater than {ComparisonValue}")
                .LessThan(10).WithMessage("{PropertyValue} must be less than {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return !leaveTypeExists;
                });
        }

       
    }
}
