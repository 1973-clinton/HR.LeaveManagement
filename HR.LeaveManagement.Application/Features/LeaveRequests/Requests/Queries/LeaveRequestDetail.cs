﻿using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class LeaveRequestDetail : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; } 
    }
}
