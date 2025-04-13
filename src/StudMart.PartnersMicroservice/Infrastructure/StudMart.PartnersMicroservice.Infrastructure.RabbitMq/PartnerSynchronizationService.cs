using AutoMapper;
using Microsoft.Extensions.Options;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Base;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Models;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq;

public class PartnerSynchronizationService(IOptions<RabbitSettings> options, IMapper mapper)
    : SynchronizationServiceBase<PartnerModel, PartnerServiceModel>(options, mapper, "AddPartner");