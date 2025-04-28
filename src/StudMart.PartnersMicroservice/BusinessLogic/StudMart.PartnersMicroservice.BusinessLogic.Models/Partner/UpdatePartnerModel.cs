using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

public record UpdatePartnerModel(    
    Guid Id,
    string Name,
    string Subtitle,
    string Description,
    int Priority,
    string Email,
    string Phone,
    long Inn,
    int CountryId,
    string Site,
    int CategoryId,
    PaymentInformationModel PaymentInformation,
    bool HasAllRegions,
    IEnumerable<int> RegionIds) : UpdateModelBase(Id);