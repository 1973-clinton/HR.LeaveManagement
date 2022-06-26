using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        ILeaveRequestRepository _leaveRequestRepository;
        public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(r => r.StartDate)
                .NotEmpty()
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} should be before {ComparisonValue}");

            RuleFor(r => r.EndDate)
                .NotEmpty()
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyValue} should be after {ComparisonValue}");

            RuleFor(r => r.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveRequestRepository.Exists(id);
                    return !leaveTypeExists;
                })
                .WithMessage("{PropertyName} does not exist");

        }
    }
}
