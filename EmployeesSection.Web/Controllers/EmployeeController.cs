using AutoMapper;
using EmployeesSection.Application.SQs.Employee.Commands.Create;
using EmployeesSection.Application.SQs.Employee.Commands.Delete;
using EmployeesSection.Application.SQs.Employee.Commands.Update;
using EmployeesSection.Application.SQs.Employee.Queries.GetEmployeeById;
using EmployeesSection.Application.SQs.Employee.Queries.GetListEmployee;
using EmployeesSection.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesSection.Web.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EmployeeController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var getListEmployeeQuery = new GetListEmployeeQuery();
        var listEmployeeVm = await _mediator.Send(getListEmployeeQuery);

        return Ok(listEmployeeVm.Employees);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult> GetById(long id)
    {
        var getEmployeeByIdQuery = new GetEmployeeByIdQuery(id);
        var employeeDto = await _mediator.Send(getEmployeeByIdQuery);

        return Ok(employeeDto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateEmployeeDto employeeDto)
    {
        var createEmployeeCommand = _mapper.Map<CreateEmployeeCommand>(employeeDto);
        var employeeId = await _mediator.Send(createEmployeeCommand);

        return Created($"api/employees/{employeeId}", employeeDto);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult> Update(long id, [FromBody] UpdateEmployeeDto employeeDto)
    {
        var updateEmployeeCommand = _mapper.Map<UpdateEmployeeCommand>(employeeDto);
        updateEmployeeCommand.Id = id;
        await _mediator.Send(updateEmployeeCommand);

        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult> Delete(long id)
    {
        var deleteEmployeeCommand = new DeleteEmployeeCommand(id);
        await _mediator.Send(deleteEmployeeCommand);

        return NoContent();
    }
}