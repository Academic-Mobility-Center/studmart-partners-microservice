namespace StudMart.PartnersMicroservice.Tests.Common.Attributes;

public class GenericClassDataAttribute<TData>() : ClassDataAttribute(typeof(TData));