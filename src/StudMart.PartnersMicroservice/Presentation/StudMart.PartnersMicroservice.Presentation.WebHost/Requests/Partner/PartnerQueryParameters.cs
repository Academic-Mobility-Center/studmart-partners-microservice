namespace StudMart.PartnersMicroservice.Presentation.WebHost.Requests.Partner;

public record PartnerQueryParameters(Guid? id, long? inn, string? name, string? email, string? phone);