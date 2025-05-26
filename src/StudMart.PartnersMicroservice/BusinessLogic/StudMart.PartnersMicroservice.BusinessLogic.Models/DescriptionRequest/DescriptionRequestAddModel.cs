using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;

public record DescriptionRequestAddModel(string Description, Guid EmployeeId) : IAddModel;