using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Queries
{
    public class LeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; } 
    }
}
