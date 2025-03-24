using System.Linq.Expressions;

namespace StudMart.PartnersMicroservice.Tests.Common.Helpers;

public static class GetPropertyValueExtensions
{
    public static TPropertyType? GetPropertyValue<TObjectType, TPropertyType>(this TObjectType exception,
        Expression<Func<TObjectType, TPropertyType>> propertyExpression)
    {
        switch (propertyExpression.Body)
        {
            case MemberExpression memberExpression:
            {
                var name =  memberExpression.Member.Name;
                return (TPropertyType)typeof(TObjectType).GetProperty(name)?.GetValue(exception)!;
            }
            case UnaryExpression { Operand: MemberExpression unaryMemberExpression }:
            {
                var name = unaryMemberExpression.Member.Name;
                return (TPropertyType)typeof(TObjectType).GetProperty(name)?.GetValue(exception)!;
            }
            default:
                throw new ArgumentException("Expression is not a valid property access", nameof(propertyExpression));
        }
    }
}