using MediatR;

namespace EmployeesSection.Application.SQs.Employee.Commands.Delete;

public class DeleteEmployeeCommand : IRequest<Unit>
{
    public long Id { get; set; }

    public DeleteEmployeeCommand(long id)
    {
        Id = id;
    }
}