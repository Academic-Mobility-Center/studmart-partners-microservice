namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;

public class InvalidCompanyNameException(string name) : FormatException
{
    public string Name { get; } = name;
    public override string Message => $"Company name {Name} is incorrect";
}