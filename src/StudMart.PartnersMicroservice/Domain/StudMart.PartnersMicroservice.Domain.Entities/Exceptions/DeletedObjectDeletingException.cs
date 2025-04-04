using StudMart.PartnersMicroservice.Domain.Entities.Base;

namespace StudMart.PartnersMicroservice.Domain.Entities.Exceptions;

public class DeletedObjectDeletingException(ISoftDeletable deletable) : InvalidOperationException("Object was deleted yet")
{
    public ISoftDeletable Deletable => deletable;
}