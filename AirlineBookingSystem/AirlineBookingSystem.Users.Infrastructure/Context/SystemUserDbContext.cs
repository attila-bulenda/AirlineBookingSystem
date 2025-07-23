using AirlineBookingSystem.Users.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AirlineBookingSystem.Users.Infrastructure.Context
{
    public class SystemUserDbContext: IdentityDbContext<SystemUser>
    {
        public SystemUserDbContext(DbContextOptions<SystemUserDbContext> options) : base(options)
        {
               
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
