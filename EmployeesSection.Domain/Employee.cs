using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Domain;

[Index(nameof(FullName), IsUnique = true)]
public class Employee
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Position { get; set; }
}