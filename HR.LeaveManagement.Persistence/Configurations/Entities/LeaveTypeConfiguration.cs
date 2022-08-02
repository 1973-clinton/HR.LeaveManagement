using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Persistence.Configurations.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType() { Id = 1, Name = "Sick", DefaultDays = 10},
                new LeaveType() { Id = 2, Name = "Vacation", DefaultDays = 15},
                new LeaveType() { Id = 3, Name = "Study", DefaultDays = 25 }
                );
        }
    }
}
