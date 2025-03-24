namespace StudMart.PartnersMicroservice.Domain.Entities.Exceptions;

/// <summary>
/// Represents Exception that occurs if Id is incorrect
/// </summary>
/// <param name="id">Identifier of Entity</param>
public class InvalidEntityIdentifierException(int id) : FormatException
{
    /// <summary>
    /// Incorrect Id that was presented;
    /// </summary>
    public int Id { get; } = id;
    /// <summary>
    /// Exception message information
    /// </summary>
    public override string Message => $"Id {Id} is incorrect";
}