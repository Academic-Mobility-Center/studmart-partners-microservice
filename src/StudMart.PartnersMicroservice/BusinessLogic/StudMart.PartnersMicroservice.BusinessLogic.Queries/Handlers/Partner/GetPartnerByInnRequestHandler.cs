using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Partner;

public class GetPartnerByInnRequestHandler(IPartnersRepository repository, IMapper mapper) : IRequestHandler<GetPartnerByInnRequest, PartnerModel?>
{
    public async Task<PartnerModel?> Handle(GetPartnerByInnRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByInnAsync(new Inn(request.Inn), cancellationToken);
        return entity is null ? null : mapper.Map<PartnerModel>(entity);
    }
}