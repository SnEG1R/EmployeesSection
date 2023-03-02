using AutoMapper;
using EmployeesSection.Application.Common.Mappings;

namespace EmployeesSection.Application.SQs.Employee.Queries.GetListEmployee;

public class GetListEmployeeDto : IMapWith
{
    public string FullName { get; set; }
    public string Position { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<Domain.Employee, GetListEmployeeDto>();
}