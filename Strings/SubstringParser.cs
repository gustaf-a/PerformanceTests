
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace PerformanceTests.Strings;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class SubstringParser
{
    private const string _input = "Hello, World!";
    private const int _startIndex = 6;
    private const int _length = 5;

    [Benchmark]
    public void SubstringParserSubstring()
    {
        SubstringParserSubstring(_input, _startIndex, _length);
    }

    public string SubstringParserSubstring(string input, int startIndex, int length)
    {
        return input.Substring(startIndex, length);
    }
    
    [Benchmark]
    public void SubstringParserReadOnlySpan()
    {
        SubstringParserSpan(_input.AsSpan(), _startIndex, _length);
    }

    public ReadOnlySpan<char> SubstringParserSpan(ReadOnlySpan<char> input, int startIndex, int length)
    {
        return input.Slice(startIndex, length);
    }
}
