using AutoMapper;
using EmployeesSection.Application.Common.Exceptions;
using EmployeesSection.Application.Interfaces;
using EmployeesSection.Application.SQs.Employee.Commands.Save;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Application.SQs.Employee.Commands.Create;

public class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeCommand, long>
{
    private readonly IMapper _mapper;
    private readonly IEmployeesSectionDbContext _employeesSectionDbContext;
    private readonly IMediator _mediator;

    public CreateEmployeeCommandHandler(IMapper mapper, 
        IEmployeesSectionDbContext employeesSectionDbContext, IMediator mediator)
    {
        _mapper = mapper;
        _employeesSectionDbContext = employeesSectionDbContext;
        _mediator = mediator;
    }

    public async Task<long> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Domain.Employee>(request);
        await _employeesSectionDbContext.Employees.AddAsync(employee, cancellationToken);

        var saveEmployeeCommand = new SaveEmployeeCommand(employee);
        await _mediator.Send(saveEmployeeCommand, cancellationToken);

        return employee.Id;
    }
}