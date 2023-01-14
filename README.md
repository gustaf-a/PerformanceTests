# Performance Tests Project

## Strings

### Get substring based on index and length from "Hello, World!"

|                      Method |       Mean |     Error |    StdDev |     Median |   Gen0 | Allocated |
|---------------------------- |-----------:|----------:|----------:|-----------:|-------:|----------:|
|    SubstringParserSubstring | 10.2682 ns | 0.0917 ns | 0.0765 ns | 10.2807 ns | 0.0204 |      32 B |
| SubstringParserReadOnlySpan |  0.0122 ns | 0.0271 ns | 0.0226 ns |  0.0000 ns |      - |         - |

### Splitting small string "2 5" 

|                               Method |      Mean |     Error |    StdDev |   Gen0 |   Gen1 | Allocated |
|------------------------------------- |----------:|----------:|----------:|-------:|-------:|----------:|
|             SplitAsSpanSeparateCalls |  7.804 ns | 0.0866 ns | 0.0810 ns |      - |      - |         - |
| SplitWithSubstringIndexSeparateCalls | 26.519 ns | 0.4493 ns | 0.3983 ns | 0.0306 | 0.0000 |      48 B |
|              SplitWithSubstringIndex | 37.452 ns | 0.4895 ns | 0.4579 ns | 0.0561 |      - |      88 B |
|                          SliceAsSpan | 41.248 ns | 0.8541 ns | 1.1105 ns | 0.0561 |      - |      88 B |
|                          SplitString | 57.442 ns | 1.0533 ns | 0.8796 ns | 0.0560 |      - |      88 B |

## Collections

### Get subset 

|                       Method |        Mean |     Error |    StdDev |    Gen0 | Allocated |
|----------------------------- |------------:|----------:|----------:|--------:|----------:|
|   GetSubsetOfCollectionArray |    929.6 ns |  18.35 ns |  16.27 ns |  2.8563 |   4.38 KB |
|    GetSubsetOfCollectionList |  2,473.6 ns |  25.95 ns |  20.26 ns |  3.3646 |   5.16 KB |
| GetSubsetOfCollectionHashSet | 21,587.1 ns | 254.37 ns | 225.49 ns | 38.4521 |  59.12 KB |

### Get value from collection

|                       Method |        Mean |     Error |    StdDev | Allocated |
|----------------------------- |------------:|----------:|----------:|----------:|
| GetSubsetOfCollectionHashSet |    16.98 ns |  0.201 ns |  0.178 ns |         - |
|    GetSubsetOfCollectionList | 2,607.97 ns | 30.873 ns | 25.781 ns |         - |
|   GetSubsetOfCollectionArray | 3,500.46 ns | 25.856 ns | 22.921 ns |         - |