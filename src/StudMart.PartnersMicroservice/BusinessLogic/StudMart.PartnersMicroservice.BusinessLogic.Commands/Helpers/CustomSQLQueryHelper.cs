namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Helpers;

public static class CustomSQLQueryHelper
{
    public static string DeletePartnersRegionsQuery => "DELETE FROM \"PartnerRegion\" WHERE \"PartnerId\" = {0}";
    public static string DeletePartnerEmployeesByPartnerIdQuery => "DELETE FROM \"Employees\" WHERE \"PartnerId\" = {0}";
    
}