using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Base;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Responses.Country;

public record CountryShortResponse(int Id, string Name) : IResponse;
