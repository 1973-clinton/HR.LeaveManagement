using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyValue} must be greater than {ComparisonValue}")
                .LessThan(100).WithMessage("{PropertyValue} must be less than {ComparisonValue}");

            RuleFor(p => p.Period)
                .NotNull();

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .NotNull()
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return !leaveTypeExists;

                }).WithMessage("{PropertyValue} does not exist!");
        }
    }
}
