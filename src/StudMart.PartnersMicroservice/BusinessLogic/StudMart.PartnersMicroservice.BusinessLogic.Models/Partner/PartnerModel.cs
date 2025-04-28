using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

public record PartnerModel(
    Guid Id,
    string Name,
    string Subtitle,
    string Description,
    int Priority,
    string Email,
    string Phone,
    long Inn,
    string Site,
    CountryShortModel Country,
    CategoryModel Category,
    PaymentInformationModel PaymentInformation,
    bool HasAllRegions,
    IEnumerable<RegionModel> Regions,
    IEnumerable<EmployeeModel> Employees) : IModel;
