using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Country;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Region;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;

public class RegionErrorsResultProcessor : IErrorsResultProcessor
{
    public IErrorResult ProcessErrorResult(Domain.Factories.Abstractions.Results.IErrorResult errorResult)
        => errorResult switch
        {
            CountryNotFoundResult countryNotFound => new Results.Region.CountryNotFoundResult(
                countryNotFound.NotFoundId),
            RegionAlreadyExistsResult countryAlreadyExists => new Results.Region.RegionAlreadyExistsResult(
                countryAlreadyExists.Entity.Name.Name),
            _ => new InternalErrorResult()
        };
}