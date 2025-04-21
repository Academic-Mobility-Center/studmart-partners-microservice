namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;

public interface INotFoundResult<out TId> : IErrorResult where TId: struct
{
    TId NotFoundId { get; }
}