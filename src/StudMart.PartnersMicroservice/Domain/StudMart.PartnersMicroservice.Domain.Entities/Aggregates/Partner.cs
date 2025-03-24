using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities.Aggregates;

public class Partner : GuidIdentifierEntity
{
    public Country Country { get; set; }
    public Site Site { get; set; }
    public Inn Inn { get; set; }
    public CompanyName CompanyName { get; set; }
    public Phone Phone { get; set; }
    public Email Email { get; set; }
    private readonly ICollection<Employee> _employees;
    public IReadOnlyCollection<Employee> Employees => _employees.ToList().AsReadOnly();
    

    public Partner(Guid id, CompanyName companyName, Phone phone, Email email, Country country, Site site, Inn inn, ICollection<Employee> employees) : base(id)
    {
        CompanyName = companyName ?? throw new ArgumentNullException(nameof(companyName));
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        Site = site ?? throw new ArgumentNullException(nameof(site));
        Inn = inn ?? throw new ArgumentNullException(nameof(inn));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        _employees = employees ?? throw new ArgumentNullException(nameof(employees));
    }
    
    
}