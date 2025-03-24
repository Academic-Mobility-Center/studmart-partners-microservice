using System.Collections;

namespace StudMart.PartnersMicroservice.Tests.Common.Base;

public abstract class TestsDataBase<TValue> : IEnumerable<object[]>
{
    private readonly IEnumerable<object[]> _data;

    protected TestsDataBase(params IEnumerable<TValue> values)
    {
        _data = values.Select(value => new object[] { value! });
    }
    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();


    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}