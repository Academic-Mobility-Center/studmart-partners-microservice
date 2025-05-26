using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.DescriptionRequest;

public class GetDescriptionRequestByIdRequest(Guid id) : GetByIdRequestBase<DescriptionRequestModel, Guid>(id)
{
    
}