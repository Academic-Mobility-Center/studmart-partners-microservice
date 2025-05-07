using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class DeleteCategoryCommand(int id) : IRequest<IResult>
{
    public int Id => id;
}