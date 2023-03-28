[![Deploy Nuget com testes](https://github.com/brutalzinn/string-placeholder/actions/workflows/deploy.yml/badge.svg)](https://github.com/brutalzinn/string-placeholder/actions/workflows/deploy.yml)

# String Placeholder 2.0.0

https://www.nuget.org/packages/StringPlaceholder/

```
dotnet add package StringPlaceholder
```

# Description

Nuget package to loop through text by a specific especify pattern. Replacing the found part with the return 

#  Easy use example

```
///Create your methods that return string
string TestOne()
{
    return "TestOne!";
}
string TestTwo()
{
    return "TestTwo!";
}

/// Create a pattern to find your placeholder in string
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

#  Placeholders with params

```

///Create your methods that return string and accept array of string as params
string TestOne(string[] objParams)
{
    return "TestOne! " + objParams[0];
}
string TestTwo(string[] objParams)
{
    var result = string.Join(", ", objParams);
    return "TestTwo! " + result;
}

/// The string to perform the task.
var text = "Hello, word [TEST1(http://google.com.br)], [TEST2(teste1,teste2, abacate)]";

/// Create PlaceholderCreator instance
var stringPlaceholder = new PlaceholderCreator();

/// Create StringExecutor List with keys and the methods to be called.
var listaExecutors = new List<StringExecutor>()
{
    new StringExecutor("TEST1",  TestOne, "teste", new List<string>()
    {
        "arg1",
        "arg2"
    }),
    new StringExecutor("TEST2",  TestTwo),
};
/// Call Creator method
var result = stringPlaceholder.Creator(text, listaExecutors);

///Assert that return variable is builded with placeholders
Assert.Contains("TestOne! http://google.com.br", result);
Assert.Contains("TestTwo! teste1, teste2, abacate", result);

Result: 
    true
    true

```

#  Fluent simple example

```
///Create your methods that return string
string TestOne()
{
    return "TestOne!";
}
string TestTwo()
{
    return "TestTwo!";
}

/// Create a pattern to find your placeholder in string
var pattern = @"\%(.*?)\%";

/// The string to perform the task.
var inputText = "Hello, word %TEST1%, %TEST2%";

/// Create ExecutorCreator instance
var executorCreator = new ExecutorCreator();

/// call create method
///finalize with build method to build the placeholders
///get string with palceholders
var result = executorCreator.Create()
    .Add(new StringExecutor("TEST1", TestOne))
    .Add(new StringExecutor("TEST2", TestTwo))
.Build(pattern, inputText);
.Result();

///Assert that return variable is builded with placeholders
Assert.Contains("TestOne!", result);
Assert.Contains("TestTwo!", result);

Result: 
    true
    true

```

#  Fluent example with callback on build

```
///Create your methods that return string
string TestOne()
{
    return "TestOne!";
}
string TestTwo()
{
    return "TestTwo!";
}

/// Create a pattern to find your placeholder in string
var pattern = @"\%(.*?)\%";

/// The string to perform the task.
var inputText = "Hello, word %TEST1%, %TEST2%";

/// Create ExecutorCreator instance
var executorCreator = new ExecutorCreator();

/// call create method
executorCreator.Create()
    .Add(new StringExecutor("TEST1", TestOne))
    .Add(new StringExecutor("TEST2", TestTwo))
//finalize with build method to build the placeholders and return into callback
.Build(pattern, inputText, (result) =>
{
    ///Assert that result variable is builded with placeholders
    Assert.Contains("TestOne!", result);
    Assert.Contains("TestTwo!", result);
});

Result: 
    true
    true

```



# Api Usages

StringPlaceholder can create the OpenApi description foreach placeholder you create.

```
/// Create a pattern to find your placeholder in string
var pattern = @"\%(.*?)\%";

/// The string to perform the task.
var inputText = "Hello, word %TEST1%, %TEST2%";

var result = new ExecutorCreator().Create()
.Add(new StringExecutor("TEST1", TestOne))
.Add(new StringExecutor("TEST2", TestTwo))
.Build(pattern, inputText);


///create a list of OpenApiDescription object with the schema

key string
Args IEnumerable<string>
MultipleParams bool
Description string

var openApiDescription = result.GetOpenApiDescription();

Assert.True(openApiDescription.Count() == 2);

string TestOne()
{
return "TestOne!";
}
string TestTwo()
{
return "TestTwo!";
}

Result: 
    true
```

# Projects using placeholder

[brutalzinn/gerador-de-dados](https://github.com/brutalzinn/gerador-de-dados)