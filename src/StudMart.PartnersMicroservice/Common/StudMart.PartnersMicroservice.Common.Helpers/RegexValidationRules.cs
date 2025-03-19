namespace StudMart.PartnersMicroservice.Common.Helpers;

/// <summary>
/// Class that contains regex expressions to validate ValueObjects
/// </summary>
public  static class RegexValidationRules
{
    /// <summary>
    /// Regex rule for email validation
    /// </summary>
    public const string EmailValidationRegex =
        @"^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$";
    /// <summary>
    /// Regex rule for Russian mobile phone number validation
    /// </summary>
    public const string PhoneValidationRegex = @"^(\+7|8)?[\s-]?\(?9\d{2}\)?[\s-]?\d{3}[\s-]?\d{2}[\s-]?\d{2}$";
    /// <summary>
    /// Regex rule for Telegram nickname validation
    /// </summary>
    public const string TelegramUsernameValidationRegex =
        @"^(?=.{5,32}$)(?!.*__)(?!^(telegram|admin|support))[a-z][a-z0-9_]*[a-z0-9]$";

}