using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeesSection.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Application.SQs.Employee.Queries.GetListEmployee;

public class GetListEmployeeQueryHandler : IRequestHandler<GetListEmployeeQuery, GetListEmployeeVm>
{
    private readonly IEmployeesSectionDbContext _employeesSectionDbContext;
    private readonly IMapper _mapper;

    public GetListEmployeeQueryHandler(IEmployeesSectionDbContext employeesSectionDbContext,
        IMapper mapper)
    {
        _employeesSectionDbContext = employeesSectionDbContext;
        _mapper = mapper;
    }

    public async Task<GetListEmployeeVm> Handle(GetListEmployeeQuery request,
        CancellationToken cancellationToken)
    {
        
        var employeeDtos = await _employeesSectionDbContext.Employees
            .ProjectTo<GetListEmployeeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new GetListEmployeeVm(employeeDtos);
    }
}