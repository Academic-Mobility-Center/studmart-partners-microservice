namespace StudMart.PartnersMicroservice.Presentation.WebHost.Helpers;

public class DatabaseSettings
{
    public required string Host { get; set; }
    public required int Port { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Db { get; set; }
    public required bool UseSsl { get; set; }

}