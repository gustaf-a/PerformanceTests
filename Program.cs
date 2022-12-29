
using BenchmarkDotNet.Running;
using PerformanceTests.Strings;

//var summary = BenchmarkRunner.Run<SubstringParser>();

var summary = BenchmarkRunner.Run<SplitStringParser>();

Console.ReadKey();
