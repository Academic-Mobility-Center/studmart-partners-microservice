using StudMart.PartnersMicroservice.Domain.Entities.Exceptions;

namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

public class SoftDeletableGuidIdentifierEntity(Guid id) : GuidIdentifierEntity(id), ISoftDeletable
{
    public bool IsDeleted { get; private set; } = false;
    public void Delete()
    {
        if (IsDeleted)
            throw new DeletedObjectDeletingException(this);
        IsDeleted = true;
    }
}