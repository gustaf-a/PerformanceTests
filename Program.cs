
using BenchmarkDotNet.Running;
using PerformanceTests.Collections;

//var summary = BenchmarkRunner.Run<SubstringParser>();
//var summary = BenchmarkRunner.Run<SplitStringParser>();

//var summary = BenchmarkRunner.Run<GetSubsetOfCollectionInt>();
var summary = BenchmarkRunner.Run<GetValueFromCollectionStrings>();

Console.ReadKey();
