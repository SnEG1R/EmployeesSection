using AutoMapper;
using EmployeesSection.Application.Common.Mappings;
using MediatR;

namespace EmployeesSection.Application.SQs.Employee.Commands.Create;

public class CreateEmployeeCommand : IRequest<long>, IMapWith
{
    public string FullName { get; set; }
    public string Position { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<CreateEmployeeCommand, Domain.Employee>();
}