using AutoMapper;
using EmployeesSection.Application.Common.Exceptions;
using EmployeesSection.Application.Interfaces;
using MediatR;

namespace EmployeesSection.Application.SQs.Employee.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdDto>
{
    private readonly IEmployeesSectionDbContext _employeesSectionDbContext;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IEmployeesSectionDbContext employeesSectionDbContext, IMapper mapper)
    {
        _employeesSectionDbContext = employeesSectionDbContext;
        _mapper = mapper;
    }

    public async Task<GetEmployeeByIdDto> Handle(GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var employee = await _employeesSectionDbContext.Employees
            .FindAsync(request.Id, cancellationToken);
        if (employee == null)
            throw new NotFoundException(nameof(Employee), request.Id);

        return _mapper.Map<GetEmployeeByIdDto>(employee);
    }
}