using StudMart.PartnersMicroservice.WebHost.Responses.Base;

namespace StudMart.PartnersMicroservice.WebHost.Responses.Country;

public record CountryShortResponse(int Id, string Name) : IResponse;
