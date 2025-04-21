using StudMart.PartnersMicroservice.Common.Helpers;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Exceptions.AccountNumber;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;

public class AccountNumberValidator()
    : StringValidatorBase<InvalidAccountNumberException, InvalidAccountNumberLengthException,
        EmptyAccountNumberException>(RegexValidationRules
            .AccountNumberValidationRegex, ValueObjectsLengthRules.MinAccountNumberLength,
        ValueObjectsLengthRules.MaxAccountNumberLength);