using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Partner;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Partner;

public class GetPartnerByPhoneRequestHandler(IPartnersRepository repository, IMapper mapper) : IRequestHandler<GetPartnerByPhoneRequest, PartnerModel?>
{
    public async Task<PartnerModel?> Handle(GetPartnerByPhoneRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByPhoneNumberAsync(new Phone(request.Phone), cancellationToken);
        return entity is null ? null : mapper.Map<PartnerModel>(entity);
    }
}