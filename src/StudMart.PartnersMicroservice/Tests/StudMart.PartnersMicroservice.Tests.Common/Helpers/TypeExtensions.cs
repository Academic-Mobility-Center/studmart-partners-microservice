using System.Reflection;

namespace StudMart.PartnersMicroservice.Tests.Common.Helpers;

public static class TypeExtensions
{
    public static TInstance? GetInstance<TInstance>(this Type type, params IEnumerable<object> parameters)
        where TInstance : class
    {
        var constructor = type.GetConstructors().FirstOrDefault();
        var instance = constructor?.Invoke(parameters.ToArray()) as TInstance;
        return instance;
    }

    public static ConstructorInfo? GetConstructor(this Type type, params IEnumerable<Type> parameterTypes)
    {
        return type.GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic, null,
            parameterTypes.ToArray(), null);
    }
}