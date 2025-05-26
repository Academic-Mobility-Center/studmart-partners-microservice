using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.DescriptionRequest;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Models.DescriptionRequest;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.DescriptionRequest;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Handlers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;
using StudMart.PartnersMicroservice.Presentation.WebHost.Requests.DescriptionRequest;
using StudMart.PartnersMicroservice.Presentation.WebHost.Responses.DiscountDescription;

namespace StudMart.PartnersMicroservice.Presentation.WebHost.Controllers;

[ApiController]
[Route("[controller]")]
public class DescriptionRequestsController(
    IMediator mediator,
    IMapper mapper,
    ILogger<DescriptionRequestsController> logger) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync([FromQuery] DescriptionRequestQueryParameters parameters,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(parameters));
        if (parameters.Id is not null)
        {
            var result = await mediator.Send(new GetDescriptionRequestByIdRequest(parameters.Id.Value),
                cancellationToken);
            if (result is not null)
                return Ok(mapper.Map<DescriptionRequestResponse>(result));
            logger.LogWarning("Discount description with Id {ParametersId} was not found", parameters.Id);
            return NotFound($"Discount description with Id {parameters.Id} was not found");
        }

        var requests = await mediator.Send(new GetAllDescriptionRequestsRequest(), cancellationToken);
        return Ok(requests.Select(mapper.Map<DescriptionRequestResponse>));
    }

    [HttpPost]
    [ProducesResponseType(typeof(DescriptionRequestResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] DescriptionRequestAddRequest request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(request));
        var result =
            await mediator.Send(new CreateDescriptionRequestCommand(mapper.Map<DescriptionRequestAddModel>(request)),
                cancellationToken);
        switch (result)
        {
            case DescriptionRequestCreatedResult createdResult:
            {
                var model = createdResult.CreatedModel;
                await mediator.Publish(new DescriptionRequestCreatedNotification(model), cancellationToken);
                return CreatedAtAction("Get", new { model.Id}, mapper.Map<DescriptionRequestResponse>(model));
            }
            case PartnerNotFoundResult partnerNotFound:
                logger.LogWarning("Partner with Id {NotFoundId} was not found", partnerNotFound.NotFoundId);
                return NotFound($"Partner with Id {partnerNotFound.NotFoundId} was not found");
            default:
                logger.LogError("Error creating description request");
                return BadRequest();
        }
    }
    [HttpPost("{requestId:guid}/accept")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AcceptAsync(Guid requestId, CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(requestId));
        var result = await mediator.Send(new AcceptDescriptionRequestCommand(requestId), cancellationToken);
        switch (result)
        {
            case DescriptionRequestAcceptedResult acceptedResult:
                await mediator.Publish(new DescriptionRequestAcceptedNotification(new DescriptionRequestAcceptedModel(requestId, acceptedResult.Employee.Email)), cancellationToken);
                await mediator.Publish(new PartnerUpdatedNotification(acceptedResult.Partner), cancellationToken);
                return NoContent();
            case INotFoundResult<Guid> notFoundResult:
                logger.LogWarning("Request with Id {RequestId} was not found", requestId);
                return NotFound($"Request with Id {requestId} was not found");
            default:
                logger.LogError("Error while accepting request with Id {RequestId}", requestId);
                return BadRequest($"Error while accepting request with Id {requestId}");
        }
    }
    [HttpPost("{requestId:guid}/reject")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RejectAsync(Guid requestId, [FromBody]DescriptionRequestRejectRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(requestId));
        var result = await mediator.Send(new RejectDescriptionRequestCommand(requestId), cancellationToken);
        switch (result)
        {
            case DescriptionRequestAcceptedResult acceptedResult:
                await mediator.Publish(new DescriptionRequestRejectedNotification(new DescriptionRequestRejectedModel(requestId, acceptedResult.Employee.Email, request.Comment)), cancellationToken);
                return NoContent();
            case INotFoundResult<Guid> notFoundResult:
                logger.LogWarning("Request with Id {RequestId} was not found", requestId);
                return NotFound($"Request with Id {requestId} was not found");
            default:
                logger.LogError("Error while accepting request with Id {RequestId}", requestId);
                return BadRequest($"Error while accepting request with Id {requestId}");
        }
    }
}