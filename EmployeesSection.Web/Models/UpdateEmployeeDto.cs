using AutoMapper;
using EmployeesSection.Application.Common.Mappings;
using EmployeesSection.Application.SQs.Employee.Commands.Update;

namespace EmployeesSection.Web.Models;

public class UpdateEmployeeDto : IMapWith
{
    public string FullName { get; set; }
    public string Position { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<UpdateEmployeeDto, UpdateEmployeeCommand>();
}