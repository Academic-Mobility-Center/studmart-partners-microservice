using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;

namespace StudMart.PartnersMicroservice.Domain.Entities.Exceptions;

public class DeletedObjectDeletingException(ISoftDeletable deletable) : InvalidOperationException("Object was deleted yet")
{
    public ISoftDeletable Deletable => deletable;
}