using MediatR;

namespace EmployeesSection.Application.SQs.Employee.Commands.Save;

public class SaveEmployeeCommand : IRequest<Unit>
{
    public Domain.Employee Employee { get; set; }

    public SaveEmployeeCommand(Domain.Employee employee)
    {
        Employee = employee;
    }
}