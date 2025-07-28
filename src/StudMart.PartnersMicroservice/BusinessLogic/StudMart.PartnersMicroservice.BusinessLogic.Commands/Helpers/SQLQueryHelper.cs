namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Helpers;

public static class SQLQueryHelper
{
    public static string DeletePartnersRegionsQuery => "DELETE FROM \"PartnerRegion\" WHERE \"PartnerId\" = {0}";
}