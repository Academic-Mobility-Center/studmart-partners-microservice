using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;

public class UpdateEmployeeCommand(UpdateEmployeeModel model) : IRequest<IResult>
{
    public UpdateEmployeeModel Model => model;
}