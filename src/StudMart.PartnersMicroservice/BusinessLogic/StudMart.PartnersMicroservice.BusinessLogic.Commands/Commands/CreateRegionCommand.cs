using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Region;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class CreateRegionCommand(RegionAddModel model) : ICreateCommand<RegionModel,RegionAddModel>
{
    public RegionAddModel Model { get; } = model;
}