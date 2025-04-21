using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.Entities.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Entities.Aggregates;

public class Partner : SoftDeletableGuidIdentifierEntity, INamedEntity<Guid, CompanyName>
{
    public Country Country { get; set; }
    public Site Site { get; set; }
    public Inn Inn { get; set; }
    public CompanyName Name { get; set; }
    public Phone Phone { get; set; }
    public Email Email { get; set; }
    public Subtitle Subtitle { get; set; }
    public Priority Priority { get; set; }
    public Category Category { get; set; }
    public Description Description { get; set; }
    public PaymentInformation PaymentInformation { get; set; }
    private readonly ICollection<Employee> _employees = [];
    public IReadOnlyCollection<Employee> Employees => [.._employees];
    public bool HasAllRegions { get; set; }
    private readonly ICollection<Region> _regions = [];
    public IReadOnlyCollection<Region> Regions => [.._regions];


    public Partner(Guid id, CompanyName companyName, Category category, Subtitle subtitle, Description description,
        Priority priority,
        Phone phone, Email email,
        Country country, Site site, Inn inn, PaymentInformation paymentInformation,
        ICollection<Employee> employees, bool hasAllRegions, ICollection<Region> regions) : base(id)
    {
        Name = companyName ?? throw new ArgumentNullException(nameof(companyName));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        Country = country ?? throw new ArgumentNullException(nameof(country));
        Site = site ?? throw new ArgumentNullException(nameof(site));
        Inn = inn ?? throw new ArgumentNullException(nameof(inn));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        PaymentInformation = paymentInformation ?? throw new ArgumentNullException(nameof(paymentInformation));
        Subtitle = subtitle ?? throw new ArgumentNullException(nameof(subtitle));
        Priority = priority ?? throw new ArgumentNullException(nameof(priority));
        Category = category ?? throw new ArgumentNullException(nameof(category));
        HasAllRegions = hasAllRegions;
        _regions = regions ?? throw new ArgumentNullException(nameof(regions));
        _employees = employees ?? throw new ArgumentNullException(nameof(employees));
    }

    internal Partner(CompanyName companyName, Category category, Subtitle subtitle, Description description, Priority priority, Phone phone,
        Email email,
        Country country, Site site, Inn inn, PaymentInformation paymentInformation, bool hasAllRegions,
        ICollection<Region> regions) : this(Guid.NewGuid(), companyName,
        category,
        subtitle, description, priority,
        phone, email, country, site, inn, paymentInformation, new List<Employee>(), hasAllRegions, regions)
    {
    }

    protected Partner(Guid id) : base(id)
    {
    }

    public bool Hire(Employee employee)
    {
        if (employee.Partner.Equals(this) == false)
            throw new AnotherPartnerException(employee, this);
        if (_employees.Contains(employee))
            return false;
        _employees.Add(employee);
        return true;
    }

    public bool Fire(Employee employee)
    {
        if (employee.Partner.Equals(this) == false)
            throw new AnotherPartnerException(employee, this);
        if (!_employees.Contains(employee))
            return false;
        _employees.Remove(employee);
        return true;
    }
    
}