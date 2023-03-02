using EmployeesSection.Application.Interfaces;
using EmployeesSection.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesSection.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<IEmployeesSectionDbContext, EmployeesSectionDbContext>(config =>
            config.UseSqlServer(configuration["ConnectionStrings:EmployeesSectionDb"]));

        return services;
    }
}