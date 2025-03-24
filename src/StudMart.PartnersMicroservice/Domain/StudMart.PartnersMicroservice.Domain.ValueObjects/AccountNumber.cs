using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Validators.Base;

namespace StudMart.PartnersMicroservice.Domain.ValueObjects;

public class AccountNumber : SingleParameterValueObjectBase<string>
{
    private AccountNumber(string value, IValidator<string> validator) : base(value, validator)
    {
    }

    public AccountNumber(string number) : this(number, new AccountNumberValidator())
    {
        
    }
}