namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

public interface INotFoundResult<out TId> : IErrorResult where TId : struct
{
    TId NotFoundId { get; }
}