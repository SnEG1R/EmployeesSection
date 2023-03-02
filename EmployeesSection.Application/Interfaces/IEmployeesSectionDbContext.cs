using EmployeesSection.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeesSection.Application.Interfaces;

public interface IEmployeesSectionDbContext
{
    DbSet<Employee> Employees { get; set; }

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}