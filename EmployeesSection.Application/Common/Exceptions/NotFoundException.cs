using System.Net;
using EmployeesSection.Application.Common.Attributes;

namespace EmployeesSection.Application.Common.Exceptions;

[StatusCodeException(HttpStatusCode.NotFound)]
public class NotFoundException : Exception
{
    public NotFoundException(string entityName, object? key)
        : base($"Entity '{entityName}' ({key ?? "null"}) not found.")
    {
    }
}