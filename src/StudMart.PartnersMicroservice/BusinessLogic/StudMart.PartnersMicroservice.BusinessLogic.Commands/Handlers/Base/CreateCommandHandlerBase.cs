using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;

public abstract class CreateCommandHandlerBase<TCreateCommand, TModel, TAddModel, TEntity, TId, TFactory, TContract>(
    IRepository<TEntity, TId> repository,
    IEntityFactory<TEntity, TId, TContract> factory,
    IMapper mapper) : IRequestHandler<TCreateCommand, TModel>
    where TCreateCommand : class, ICreateCommand<TModel, TAddModel> 
    where TModel : IModel
    where TEntity : class, IEntity<TId>
    where TId : struct
    where TContract : IFactoryContract
    where TAddModel : class, IAddModel

{
    public virtual async Task<TModel> Handle(TCreateCommand request, CancellationToken cancellationToken)
    {
        var contract = mapper.Map<TContract>(request.Model);
        var entity = await factory.Create(contract);
        var result = await repository.AddAsync(entity, cancellationToken);
        if (result is null)
            throw new NullReferenceException();
        return mapper.Map<TModel>(result);

    }
}