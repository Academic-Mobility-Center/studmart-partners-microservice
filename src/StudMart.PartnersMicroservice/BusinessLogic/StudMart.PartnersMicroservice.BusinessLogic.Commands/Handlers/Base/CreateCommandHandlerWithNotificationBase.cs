using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using StudMart.PartnersMicroservice.Synchronization.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;

public class
    CreateCommandHandlerWithNotificationBase<TCreateCommand, TModel, TAddModel, TEntity, TId, TFactory, TContract>(
        IRepository<TEntity, TId> repository,
        IEntityFactory<TEntity, TId, TContract> factory,
        IMapper mapper, ISynchronizationService<TModel> synchronizationService)
    : CreateCommandHandlerBase<TCreateCommand, TModel, TAddModel, TEntity, TId, TFactory, TContract>(repository,
        factory, mapper) where TCreateCommand : class, ICreateCommand<TModel, TAddModel>
    where TModel : IModel
    where TEntity : class, IEntity<TId>
    where TId : struct
    where TContract : IFactoryContract
    where TAddModel : class, IAddModel
{
    public override async Task<TModel> Handle(TCreateCommand request, CancellationToken cancellationToken)
    {
        var result = await base.Handle(request, cancellationToken);
        await synchronizationService.SendAsync(result, cancellationToken);
        return result;
    }
}