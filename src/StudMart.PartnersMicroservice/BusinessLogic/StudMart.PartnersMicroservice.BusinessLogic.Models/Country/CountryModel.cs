using StudMart.PartnersMicroservice.BusinessLogic.Models.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;

namespace StudMart.PartnersMicroservice.BusinessLogic.Models.Country;

public record CountryModel(int Id, string Name, IEnumerable<RegionModel> Regions) : IModel;