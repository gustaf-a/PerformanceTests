using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace PerformanceTests.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class GetSubsetOfCollectionInt
{
    private const int _collectionSize = 1000;
    private const int _start = 0;
    private const int _subsetSize = 100;

    [Benchmark]
    public void GetSubsetOfCollectionList()
    {
        var source = Enumerable.Range(0, _collectionSize).ToList();

        var result = new List<int>();

        for (int i = _start; i < _subsetSize; i++)
            result.Add(source[i]);

        var resultSize = result.Count;
    }

    [Benchmark]
    public void GetSubsetOfCollectionArray()
    {
        var source = Enumerable.Range(0, _collectionSize).ToArray();

        var result = new int[_subsetSize];

        for (int i = _start; i < _subsetSize; i++)
            result[i] = (source[i]);

        var resultSize = result.Length;
    }

    [Benchmark]
    public void GetSubsetOfCollectionHashSet()
    {
        var source = Enumerable.Range(0, _collectionSize).ToHashSet<int>();

        var result = new HashSet<int>(_subsetSize);

        for (int i = _start; i < _subsetSize; i++)
        {
            source.TryGetValue(i, out var value);
            result.Add(value);
        }

        var resultSize = result.Count;
    }
}
