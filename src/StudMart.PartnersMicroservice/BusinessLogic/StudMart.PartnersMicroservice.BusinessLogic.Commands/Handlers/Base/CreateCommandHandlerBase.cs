using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using IResult = StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base.IResult;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;

public abstract class CreateCommandHandlerBase<TCreateCommand, TModel, TAddModel, TEntity, TId, TFactory, TContract, TCreatedResult>(
    IRepository<TEntity, TId> repository,
    IEntityFactory<TContract> factory,
    IMapper mapper,
    IErrorsResultProcessor? processor) : IRequestHandler<TCreateCommand, IResult>, IDisposable, IAsyncDisposable
    where TCreateCommand : class, ICreateCommand<TAddModel>
    where TModel : class, IModel
    where TEntity : class, IEntity<TId>
    where TId : struct
    where TContract : IFactoryContract
    where TAddModel : class, IAddModel
    where TCreatedResult: CreatedResultBase<TModel>, new()

{
    public virtual async Task<IResult> Handle(TCreateCommand request, CancellationToken cancellationToken)
    {
        var contract = mapper.Map<TContract>(request.Model);
        var entityResult = await factory.Create(contract, cancellationToken);
        switch (entityResult)
        {
            case Domain.Factories.Abstractions.Results.IErrorResult errorFoundResult when processor is not null:
                return processor.ProcessErrorResult(errorFoundResult);
            case ICreatedResult<TEntity, TId> createdResult:
            {
                var entity = createdResult.CreatedEntity;
                var result = await repository.AddAsync(entity, cancellationToken);
                if (result is null)
                    return new InternalErrorResult();
                var model = mapper.Map<TModel>(entity);
                return new TCreatedResult
                {
                    CreatedModel = model
                };
            }
            default:
                return new InternalErrorResult();
        }
    }

    public void Dispose()
    {
        repository.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await repository.DisposeAsync();
    }
}