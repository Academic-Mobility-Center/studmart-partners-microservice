using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class DeleteEmployeeCommand(Guid Id) :  IRequest<IResult>
{
    public Guid Id => Id;
}