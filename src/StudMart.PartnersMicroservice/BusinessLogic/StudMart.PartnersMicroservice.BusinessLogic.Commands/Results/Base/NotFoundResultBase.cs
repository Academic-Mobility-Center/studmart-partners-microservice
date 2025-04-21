namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

public abstract class NotFoundResultBase<TId>(TId notFoundId): INotFoundResult<TId>
    where TId : struct
{
    public TId NotFoundId { get; } = notFoundId;
}