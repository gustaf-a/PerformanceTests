# Performance Tests Project



## Get substring based on index and length from "Hello, World!"

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