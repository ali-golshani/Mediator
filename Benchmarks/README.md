Send:

| Method                        | Mean     | Error   | StdDev  | Gen0   | Allocated |
|------------------------------ |---------:|--------:|--------:|-------:|----------:|
| Mediator (Source-Generator) | 109.6 ns | 1.12 ns | 1.04 ns |      - |         - |
| Minimal Mediator            | 139.7 ns | 1.09 ns | 1.02 ns | 0.0560 |     352 B |
| MediatR                       | 334.4 ns | 6.71 ns | 6.27 ns | 0.1884 |    1184 B |

<br>

Publish:

| Method                                       | Mean      | Error    | StdDev   | Gen0   | Allocated |
|--------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| One Handlers - Mediator (Source-Generator) |  37.44 ns | 0.770 ns | 0.756 ns |      - |         - |
| One Handlers - Minimal Mediator            |  41.23 ns | 0.805 ns | 0.791 ns |      - |         - |
| One Handlers - MediatR                     | 105.37 ns | 2.089 ns | 2.051 ns | 0.0459 |     288 B |
| Two Handlers - Mediator (Source-Generator) |  50.44 ns | 0.134 ns | 0.119 ns |      - |         - |
| Two Handlers - Minimal Mediator            |  46.04 ns | 0.089 ns | 0.070 ns |      - |         - |
| Two Handlers - MediatR                     | 134.51 ns | 1.711 ns | 1.517 ns | 0.0701 |     440 B |
