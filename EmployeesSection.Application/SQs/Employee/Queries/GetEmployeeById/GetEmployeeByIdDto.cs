using AutoMapper;
using EmployeesSection.Application.Common.Mappings;

namespace EmployeesSection.Application.SQs.Employee.Queries.GetEmployeeById;

public class GetEmployeeByIdDto : IMapWith
{
    public string FullName { get; set; }
    public string Position { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<Domain.Employee, GetEmployeeByIdDto>();
}