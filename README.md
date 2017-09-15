Api client using [Refit](http://paulcbetts.github.io/refit/)

(The consumed api is my own [ToDo list Api](https://github.com/alexphi/nancy-core-todolist))

## Setup

```
dotnet new console
dotnet add package Refit
```

## Notes

The ToDo item model uses the same property names as the Api. However, this could be customized using the `[JsonProperty]` attribute.

Nice surprise: Refit adds its own build warnings when the interface attributes are not correctly defined!:

```
C:\Users\Alejandro Figueroa\.nuget\packages\refit\4.0.1\build\netstandard1.4\refit.targets(29,5): warning : warning RF0
01: Method ITodoService.Create either has no Refit HTTP method attribute or you've used something other than a string l
iteral for the 'path' argument. [C:\Users\Alejandro Figueroa\Documents\Projects\TodoClient\TodoClient.csproj]
```

