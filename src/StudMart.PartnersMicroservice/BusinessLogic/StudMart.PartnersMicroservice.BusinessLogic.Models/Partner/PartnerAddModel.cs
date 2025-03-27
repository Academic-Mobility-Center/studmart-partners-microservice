using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

public record PartnerAddModel(
    string CompanyName,
    string Email,
    string Phone,
    long Inn,
    int CountryId,
    string Site,
    PaymentInformationModel PaymentInformation) : IAddModel;
