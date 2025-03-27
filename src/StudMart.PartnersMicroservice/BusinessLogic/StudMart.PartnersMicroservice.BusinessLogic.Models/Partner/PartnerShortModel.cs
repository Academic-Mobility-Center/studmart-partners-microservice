using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

public record PartnerShortModel(
    Guid Id,
    string CompanyName,
    string Email,
    string Phone,
    long Inn,
    string Site,
    CountryShortModel Country,
    PaymentInformationModel PaymentInformation) : IModel;