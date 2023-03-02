using System.Net;

namespace EmployeesSection.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class StatusCodeExceptionAttribute : Attribute
{
    public HttpStatusCode StatusCode { get; }

    public StatusCodeExceptionAttribute(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }
}