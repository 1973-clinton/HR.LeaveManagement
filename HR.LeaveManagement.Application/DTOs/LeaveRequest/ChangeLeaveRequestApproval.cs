﻿using HR.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApproval : BaseDto
    {
        public bool Approved { get; set; } 
    }
}
