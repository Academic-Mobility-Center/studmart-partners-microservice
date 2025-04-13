using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.Synchronization.Abstractions;

public interface ISynchronizationService<in T> where T: IModel
{
    Task SendAsync(T entity, CancellationToken cancellationToken = default);
}