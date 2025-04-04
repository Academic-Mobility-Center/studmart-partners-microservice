using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

public record PartnerModel(
    Guid Id,
    string CompanyName,
    string Subtitle,
    int Priority,
    string Email,
    string Phone,
    long Inn,
    string Site,
    CountryShortModel Country,
    CategoryModel Category,
    PaymentInformationModel PaymentInformation,
    IEnumerable<EmployeeModel> Employees) : IModel;
