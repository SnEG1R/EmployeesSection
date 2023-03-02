using EmployeesSection.Application.Common.Exceptions;
using EmployeesSection.Application.Interfaces;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Application.SQs.Employee.Commands.Save;

public class SaveEmployeeCommandHandler : IRequestHandler<SaveEmployeeCommand, Unit>
{
    private readonly IEmployeesSectionDbContext _employeesSectionDbContext;
    private const int UniqueIndexViolationCode = 2601;

    public SaveEmployeeCommandHandler(IEmployeesSectionDbContext employeesSectionDbContext)
    {
        _employeesSectionDbContext = employeesSectionDbContext;
    }

    public async Task<Unit> Handle(SaveEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _employeesSectionDbContext.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            if (e.InnerException is SqlException { Number: UniqueIndexViolationCode })
                throw new DataUniqueException($"Property '{nameof(Domain.Employee.FullName)}' must be unique. " +
                                              $"Value '{request.Employee.FullName}' already exists", e);
            throw;
        }
        
        return Unit.Value;
    }
}