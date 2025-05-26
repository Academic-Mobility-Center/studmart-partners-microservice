using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.Entities.Enums;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities;

public class DescriptionRequest : GuidIdentifierEntity
{
    public Employee Employee { get; init; }
    public Description Description { get; init; }
    public DescriptionRequestState State { get; private set; } = DescriptionRequestState.UnderVerification;
    protected DescriptionRequest(Guid id, Employee employee, Description description) : base(id)
    {
        Employee = employee;
        Description = description;
    }

    public DescriptionRequest(Employee employee, Description description) : this(Guid.NewGuid(), employee, description)
    {
        
    }

    protected DescriptionRequest(Guid id) : base(id)
    {
        
    }

    public bool Accept()
    {
        if (State == DescriptionRequestState.Rejected)
            return false;
        State = DescriptionRequestState.Accepted;
        return true;
    }

    public bool Reject()
    {
        if (State == DescriptionRequestState.Accepted)
            return false;
        State = DescriptionRequestState.Rejected;
        return true;
    }
}