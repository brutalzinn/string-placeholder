[![Deploy Nuget com testes](https://github.com/brutalzinn/string-placeholder/actions/workflows/deploy.yml/badge.svg)](https://github.com/brutalzinn/string-placeholder/actions/workflows/deploy.yml)

# String Placeholder 2.0.0

https://www.nuget.org/packages/StringPlaceholder/

```
dotnet add package StringPlaceholder
```

# [EN - Description]

Nuget package to loop through text by a specific especify pattern. Replacing the found part with the return of a list of methods.

# [EN - Example]

```
///Create your string methods.
string TestOne()
{
    return "TestOne!";
}
string TestTwo()
{
    return "TestTwo!";
}

/// Pattern to find. This is optional.
var pattern = @"\%(.*?)\%";

/// The string to perform the task.
var text = "Hello, word %TEST1%, %TEST2%";

/// Create PlaceholderCreator instance
var stringPlaceholder = new PlaceholderCreator();

/// Create StringExecutor List with keys and the methods to be called.
var listaExecutors = new List<StringExecutor>()
{
  	///KEY, STRING METHOD
    new StringExecutor("TEST1", TestOne),
    new StringExecutor("TEST2", TestTwo),
};

/// Call Creator method
var result = stringPlaceholder.Creator(text, listaExecutors, pattern);

///Result: "Hello, word TestOne!, TestTwo!"
```