using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Employee;

public class GetEmployeeByIdRequest(Guid id) : GetByIdRequestBase<EmployeeModel, Guid>(id)
{
    
}