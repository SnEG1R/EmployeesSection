using EmployeesSection.Application.Interfaces;
using EmployeesSection.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Persistence.Contexts;

public sealed class EmployeesSectionDbContext : DbContext, IEmployeesSectionDbContext
{
    public DbSet<Employee> Employees { get; set; }

    public EmployeesSectionDbContext(DbContextOptions<EmployeesSectionDbContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }
}