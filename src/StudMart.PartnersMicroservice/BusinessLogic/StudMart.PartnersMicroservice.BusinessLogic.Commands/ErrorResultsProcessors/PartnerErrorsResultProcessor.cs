using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Partner;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Region;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;

public class PartnerErrorsResultProcessor : IErrorsResultProcessor
{
    public IErrorResult ProcessErrorResult(Domain.Factories.Abstractions.Results.IErrorResult errorResult)
        => errorResult switch
        {
            CountryNotFoundResult countryNotFound => new Results.Region.CountryNotFoundResult(
                countryNotFound.NotFoundId),
            CategoryNotFoundResult categoryNotFound => new Results.Partner.CategoryNotFoundResult(categoryNotFound.NotFoundId),
            PartnerAlreadyRegisteredResult partnerAlreadyRegistered => new Results.Partner.PartnerAlreadyRegisteredResult(partnerAlreadyRegistered.Inn),
            PartnerEmailAlreadyRegisteredResult partnerEmailAlreadyRegistered => new Results.Partner.PartnerEmailAlreadyRegisteredResult(partnerEmailAlreadyRegistered.Email),
            PartnerPhoneAlreadyRegisteredResult partnerPhoneAlreadyRegistered => new Results.Partner.PartnerPhoneAlreadyRegisteredResult(partnerPhoneAlreadyRegistered.Phone),
            _ => new InternalErrorResult()

        };
}