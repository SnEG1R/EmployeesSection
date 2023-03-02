using AutoMapper;
using EmployeesSection.Application.Common.Mappings;
using MediatR;

namespace EmployeesSection.Application.SQs.Employee.Commands.Update;

public class UpdateEmployeeCommand : IRequest<Unit>, IMapWith
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Position { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<UpdateEmployeeCommand, Domain.Employee>();
}