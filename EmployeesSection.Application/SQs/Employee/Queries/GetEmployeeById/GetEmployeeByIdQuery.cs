using MediatR;

namespace EmployeesSection.Application.SQs.Employee.Queries.GetEmployeeById;

public class GetEmployeeByIdQuery : IRequest<GetEmployeeByIdDto>
{
    public long Id { get; set; }

    public GetEmployeeByIdQuery(long id)
    {
        Id = id;
    }
}