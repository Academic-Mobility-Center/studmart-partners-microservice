using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;

public class GetPartnerByPhoneRequest(string phone) : IRequest<PartnerModel?>
{
    public string Phone => phone;
}