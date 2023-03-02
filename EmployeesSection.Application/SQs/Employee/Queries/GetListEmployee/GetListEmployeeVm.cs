namespace EmployeesSection.Application.SQs.Employee.Queries.GetListEmployee;

public class GetListEmployeeVm
{
    public IEnumerable<GetListEmployeeDto> Employees { get; set; }

    public GetListEmployeeVm(IEnumerable<GetListEmployeeDto> employees)
    {
        Employees = employees;
    }
}