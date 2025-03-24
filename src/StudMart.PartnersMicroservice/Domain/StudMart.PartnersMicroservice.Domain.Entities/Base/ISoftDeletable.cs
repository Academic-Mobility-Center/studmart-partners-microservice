namespace StudMart.PartnersMicroservice.Domain.Entities.Base;

public interface ISoftDeletable
{
    public bool IsDeleted { get; }
    public void Delete();
}