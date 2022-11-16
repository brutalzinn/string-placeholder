# String Placeholder 1.0.0

# [PT - Descrição]

Pacote nuget para percorrer um texto por um padrão específico de busca. Substituindo a parte encontrada pelo retorno de uma lista de métodos.


# [PT - Exemplo]

```
///Crie seu método string

string TestOne()
{
    return "TestOne!";
}
string TestTwo()
{
    return "TestTwo!";
}

/// Padrão para busca. Isso é opcional.
var pattern = @"\%(.*?)\%";

/// A cadeia de caracteres para executar a tarefa.
var text = "Hello, word %TEST1%, %TEST2%";

/// Crie instância de PlaceholderCreator
var stringPlaceholder = new PlaceholderCreator();

/// Crie a lista StringExecutor com as chaves e os métodos a serem chamados.
var listaExecutors = new List<StringExecutor>()
{
  	///CHAVE, MÉTODO STRING
    new StringExecutor("TEST1", TestOne),
    new StringExecutor("TEST2", TestTwo),
};

/// Chame o método Creator
var result = stringPlaceholder.Creator(text, listaExecutors, pattern);

///Result: "Hello, word TestOne!, TestTwo!"
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