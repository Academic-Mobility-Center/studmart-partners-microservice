namespace StudMart.PartnersMicroservice.Infrastructure.RabbitMq.Helpers;

public class RabbitSettings
{
   public required string User {get; set;}
   public required string Password {get; set;}
   public required string Server {get; set;}
   public required string VirtualHost {get; set;}
   public required int Port {get; set;}
}