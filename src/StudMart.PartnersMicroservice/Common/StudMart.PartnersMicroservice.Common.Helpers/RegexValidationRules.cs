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
    public const string PhoneValidationRegex = @"^(?:\+7|8)?[\s-]?\(?\d{3,5}\)?[\s-]?\d{1,3}[\s-]?\d{2}[\s-]?\d{2}$";

    /// <summary>
    /// Regex rule for company names with english and russian letters
    /// </summary>
    public const string CompanyNameValidationRegex = @"^[a-zA-Zа-яА-Я0-9№\s\'\-«»""]+$";
    
    /// <summary>
    /// Regex rule for country names with english and russian letters
    /// </summary>
    public const string CountryNameValidationRegex = @"^[а-яА-Я\s\'’\-]+$";
    /// <summary>
    /// Regex rule for person last name
    /// </summary>
    public const string NamePartValidationRegex = @"^[а-яА-Я\s\'’-]+$";
    /// <summary>
    /// Regex rule for region of country
    /// </summary>
    public const string RegionNameValidationRegex = @"^[а-яА-Я\s\'’-]+$";
    /// <summary>
    /// Regex rule for site path
    /// </summary>
    public const string SiteValidationRegex = @"^(https?:\/\/)?(www\.)?(([\w-]+\.)+[\w-]+|localhost)(\.\w{2,})?(:[0-9]{1,5})?(\/[^\s<>]*)?(\?[^\s<>]*)?$";
    /// <summary>
    /// Regex rule for account number
    /// </summary>
    public const string AccountNumberValidationRegex = @"^\d{20}$";
    /// <summary>
    /// Regex rule for account number
    /// </summary>
    public const string BikValidationRegex = @"^\d{9}$";
    /// <summary>
    /// Regex rule for category name
    /// </summary>
    public const string CategoryNameValidationRegex = @"^[А-Яа-яЁёA-Za-z\s\-]+$";
    /// <summary>
    /// Regex rule for subtitle
    /// </summary>
    public const string SubtitleValidationRegex = @"^[А-Яа-яЁёA-Za-z\s\-,]+$";
    /// <summary>
    /// Regex rule for company description
    /// </summary>
    public const string DescriptionValidationRegex = @"^[\w\sА-Яа-яЁё.,!?:;""'«»–—\-()\[\]{}<>*@#%+=/\\|&~`^$№_]+$";


}