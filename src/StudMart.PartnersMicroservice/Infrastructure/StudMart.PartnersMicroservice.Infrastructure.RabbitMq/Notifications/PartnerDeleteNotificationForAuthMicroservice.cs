using StudMart.PartnersMicroservice.BusinessLogic.Models.Partner;
using StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications.Base;

namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Notifications;

public class PartnerDeleteNotificationForAuthMicroservice(PartnerDeleteModel model) : NotificationBase<PartnerDeleteModel>(model);