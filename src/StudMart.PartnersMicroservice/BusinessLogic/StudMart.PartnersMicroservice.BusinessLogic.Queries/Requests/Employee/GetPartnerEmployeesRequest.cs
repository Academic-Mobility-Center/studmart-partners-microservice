using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Employee;

public class GetPartnerEmployeesRequest(Guid partnerId) : IRequest<IEnumerable<EmployeeModel>>
{
    public Guid PartnerId => partnerId;
}