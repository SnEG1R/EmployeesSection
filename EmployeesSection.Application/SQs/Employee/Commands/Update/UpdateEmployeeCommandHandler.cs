using AutoMapper;
using EmployeesSection.Application.Common.Exceptions;
using EmployeesSection.Application.Interfaces;
using EmployeesSection.Application.SQs.Employee.Commands.Save;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Application.SQs.Employee.Commands.Update;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
{
    private readonly IEmployeesSectionDbContext _employeesSectionDbContext;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UpdateEmployeeCommandHandler(IMapper mapper,
        IEmployeesSectionDbContext employeesSectionDbContext, IMediator mediator)
    {
        _mapper = mapper;
        _employeesSectionDbContext = employeesSectionDbContext;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var updatedEmployee = _mapper.Map<Domain.Employee>(request);
        var employee = await _employeesSectionDbContext.Employees
            .FindAsync(updatedEmployee.Id, cancellationToken);

        if (employee == null)
            throw new NotFoundException(nameof(Domain.Employee), request.Id);

        _employeesSectionDbContext.Entry(employee).CurrentValues.SetValues(updatedEmployee);
        
        var saveEmployeeCommand = new SaveEmployeeCommand(employee);
        await _mediator.Send(saveEmployeeCommand, cancellationToken);

        return Unit.Value;
    }
}