using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Category;

public record CategoryModel(int Id, string Name, int Priority) : IModel;