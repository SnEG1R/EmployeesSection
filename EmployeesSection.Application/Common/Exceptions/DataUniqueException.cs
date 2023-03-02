using System.Net;
using EmployeesSection.Application.Common.Attributes;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.Application.Common.Exceptions;

[StatusCodeException(HttpStatusCode.Conflict)]
public class DataUniqueException : DbUpdateException
{
    public DataUniqueException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}