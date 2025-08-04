using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;

public record PartnerDeleteModel(Guid PartnerId, IEnumerable<Guid> EmployeesIds) : IModel;
