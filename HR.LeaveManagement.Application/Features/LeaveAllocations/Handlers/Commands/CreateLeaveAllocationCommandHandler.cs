using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public CreateLeaveAllocationCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            //perform validations
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var results = await validator.ValidateAsync(request.LeaveAllocation);
            if (results.IsValid == false)
                throw new Exception();

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocation);
            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
