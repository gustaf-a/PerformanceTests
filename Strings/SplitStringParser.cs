using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace PerformanceTests.Strings;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class SplitStringParser
{
    private const string _input = "2 5";
    private const char _separator = ' ';

    [Benchmark]
    public void SplitString()
    {
        SplitStringSplit(_input, _separator);
    }

    public string[] SplitStringSplit(string input, char separator)
    {
        return input.Split(separator);
    }

    [Benchmark]
    public void SliceAsSpan()
    {
        SliceAsSpan(_input.AsSpan(), _separator);
    }

    public string[] SliceAsSpan(ReadOnlySpan<char> input, char separator)
    {
        var index = input.IndexOf(separator);
        
        return new[] { input.Slice(0, index).ToString(), input.Slice(index + 1).ToString() };
    }

    [Benchmark]
    public void SplitWithSubstringIndex()
    {
        SplitStringSubstring(_input, _separator);
    }

    public string[] SplitStringSubstring(string input, char separator)
    {
        return new[] { input.Substring(0, input.IndexOf(separator)), input.Substring(input.IndexOf(separator) + 1) };
    }

    [Benchmark]
    public void SplitWithSubstringIndexSeparateCalls()
    {
        var first = SplitStringSubstring(_input, _separator, 0);
        var second = SplitStringSubstring(_input, _separator, 1);
    }

    public string SplitStringSubstring(string input, char separator, int index)
    {
        if (index == 0)
            return input.Substring(0, input.IndexOf(separator));

        return input.Substring(input.IndexOf(separator) + 1);
    }

    [Benchmark]
    public void SplitAsSpanSeparateCalls()
    {
        var first = SplitStringAsSpanSubstring(_input, _separator, 0);
        var second = SplitStringAsSpanSubstring(_input, _separator, 1);
    }

    public ReadOnlySpan<char> SplitStringAsSpanSubstring(ReadOnlySpan<char> input, char separator, int index)
    {
        if (index == 0)
            return input.Slice(0, input.IndexOf(separator));

        return input.Slice(input.IndexOf(separator) + 1);
    }
}
