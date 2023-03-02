using AutoMapper;
using EmployeesSection.Application.Common.Mappings;
using EmployeesSection.Application.SQs.Employee.Commands.Create;

namespace EmployeesSection.Web.Models;

public class CreateEmployeeDto : IMapWith
{
    public string FullName { get; set; }
    public string Position { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>();
    }
}