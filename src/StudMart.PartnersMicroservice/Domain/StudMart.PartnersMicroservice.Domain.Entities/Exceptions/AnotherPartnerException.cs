using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;

namespace StudMart.PartnersMicroservice.Domain.Entities.Exceptions;

public class AnotherPartnerException(Employee employee, Partner partner) : InvalidOperationException($"Can employee '{employee.FirstName} {employee.LastName}' does not work in partner {partner.Name}")
{
    public Partner Partner => partner;
    public Employee Employee => employee;
}