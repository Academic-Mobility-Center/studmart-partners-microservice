using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;

public class GetPartnerByInnRequest(long inn) : IRequest<PartnerModel?>
{
    public long Inn => inn;
}