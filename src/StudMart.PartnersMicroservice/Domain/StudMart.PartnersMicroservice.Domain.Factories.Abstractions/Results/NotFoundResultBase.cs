namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

public abstract class NotFoundResultBase<TId>(TId id) : INotFoundResult<TId>
    where TId : struct
{
    public TId NotFoundId { get; } = id;
}