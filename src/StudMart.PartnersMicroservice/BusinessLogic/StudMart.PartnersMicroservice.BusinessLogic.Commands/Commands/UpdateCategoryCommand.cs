using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class UpdateCategoryCommand(UpdateCategoryModel model) : IRequest<IResult>
{
    public UpdateCategoryModel Model => model;
}