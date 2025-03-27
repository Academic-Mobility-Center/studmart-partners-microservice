using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities;

public class Employee : GuidIdentifierEntity
{
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public Email Email { get; set; }
    public Partner Partner { get; set; }

    protected Employee(Guid id, FirstName firstName, LastName lastName, Email email, Partner partner) : base(id)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Partner = partner ?? throw new ArgumentNullException(nameof(partner));
    }
    public Employee(FirstName firstName, LastName lastName, Email email, Partner partner) : this(Guid.NewGuid(), firstName, lastName, email, partner)
    {

    }

    protected Employee(Guid id) : base(id)
    {
        
    }
}