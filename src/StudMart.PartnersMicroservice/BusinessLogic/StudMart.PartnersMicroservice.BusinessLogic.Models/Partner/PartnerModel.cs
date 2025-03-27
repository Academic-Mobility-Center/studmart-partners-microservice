using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

public record PartnerModel(
    Guid Id,
    string CompanyName,
    string Email,
    string Phone,
    long Inn,
    string Site,
    CountryShortModel Country,
    PaymentInformationModel PaymentInformation,
    IEnumerable<EmployeeModel> Employees) : IModel;
