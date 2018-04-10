using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace HolidayBooking.Vacation.Storage
{
    public class VacationDbContext : DbContext
    {
        public VacationDbContext(DbContextOptions<VacationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Holidaybooking.Vacation.Domain.Vacation.Vacation> Vacations { get; set; }
    }
}