using EmployeesSection.Application.Common.Exceptions;
using EmployeesSection.Application.Interfaces;
using MediatR;

namespace EmployeesSection.Application.SQs.Employee.Commands.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    private readonly IEmployeesSectionDbContext _employeesSectionDbContext;

    public DeleteEmployeeCommandHandler(IEmployeesSectionDbContext employeesSectionDbContext)
    {
        _employeesSectionDbContext = employeesSectionDbContext;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeesSectionDbContext.Employees
            .FindAsync(request.Id, cancellationToken);
        if (employee == null)
            throw new NotFoundException(nameof(Employee), request.Id);

        _employeesSectionDbContext.Employees.Remove(employee);
        await _employeesSectionDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}