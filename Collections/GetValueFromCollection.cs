using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace PerformanceTests.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class GetValueFromCollectionStrings
{
    private const int _collectionSize = 1000;
    private const string _valueToGet = "500";

    private List<string> _list;
    private string[] _array;
    private HashSet<string> _hashset;

    [GlobalSetup]
    public void Setup()
    {
        _list = Enumerable.Range(0, _collectionSize).Select(x => x.ToString()).ToList();
        _array = Enumerable.Range(0, _collectionSize).Select(x => x.ToString()).ToArray();
        _hashset = Enumerable.Range(0, _collectionSize).Select(x => x.ToString()).ToHashSet<string>();
    }

    [Benchmark]
    public void GetSubsetOfCollectionList()
    {
        var result = _list[_list.IndexOf(_valueToGet)];

        var resultSize = result.Length;
    }

    [Benchmark]
    public void GetSubsetOfCollectionArray()
    {
        for (int i = 0; i < _array.Length; i++)
            if (_array[i] == _valueToGet)
            {
                var result = _array[i];

                var resultSize = result.Length;
            }        
    }

    [Benchmark]
    public void GetSubsetOfCollectionHashSet()
    {
        _hashset.TryGetValue(_valueToGet, out var result);
        
        var resultSize = result.Length;
    }
}
