using StringPlaceholder;
using StringPlaceholder.FluentPattern;
using Xunit;
using Xunit.Abstractions;

namespace Testes
{
    public class Program
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Program(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void FindAndReplaceParametrized_IfContainsResults_ReturnTrue()
        {
            var text = "Hello, word [TEST1(http://google.com.br)], [TEST2(teste1,teste2, abacate)]";
            var stringPlaceholder = new PlaceholderCreator();
            var listaExecutors = new List<StringExecutor>()
            {
                new StringExecutor("TEST1",  TestOne, "teste", new List<string>()
                {
                    "arg1",
                    "arg2"
                }),
                new StringExecutor("TEST2",  TestTwo),
            };
            var result = stringPlaceholder.Creator(text, listaExecutors);

            _testOutputHelper.WriteLine($"RESULTADO: {result}");

            Assert.Contains("TestOne! http://google.com.br", result);
            Assert.Contains("TestTwo! teste1, teste2, abacate", result);


            string TestOne(string[] objParams)
            {
                return "TestOne! " + objParams[0];
            }
            string TestTwo(string[] objParams)
            {
                var result = string.Join(", ", objParams);
                return "TestTwo! " + result;
            }
        }

        [Fact]
        public void FindAndReplace_IfContainsResults_ReturnTrue()
        {
            var text = "Hello, word [TEST1], [TEST2]";
            var stringPlaceholder = new PlaceholderCreator();
            var listaExecutors = new List<StringExecutor>()
            {
                new StringExecutor("TEST1", TestOne),
                new StringExecutor("TEST2", TestTwo),
            };
            var result = stringPlaceholder.Creator(text, listaExecutors);
            Assert.Contains("TestOne!", result);
            Assert.Contains("TestTwo!", result);
            string TestOne()
            {
                return "TestOne!";
            }
            string TestTwo()
            {
                return "TestTwo!";
            }
        }
        [Fact]
        public void Depuration()
        {
            var text = "Hello, word [RANDOM], [RANDOM] [RANDOM]";
            var stringPlaceholder = new PlaceholderCreator();
            var listaExecutors = new List<StringExecutor>()
            {
                new StringExecutor("RANDOM", RandomString),

            };
            var result = stringPlaceholder.Creator(text, listaExecutors);
            _testOutputHelper.WriteLine($"RESULTADO: {result}");
            Assert.True(true);
            string RandomString()
            {
                var texts = new List<string>() { "abacate", "mamao", "pera", "banana" };
                var randomIndex = new Random().Next(0, texts.Count());
                return texts[randomIndex];
            }
        }

        [Fact]
        public void FindAndReplaceMultipleTags_IfContainsResults_ReturnTrue()
        {
            var text = "Hello, word [TEST1], [TEST2] [TEST2]";
            var stringPlaceholder = new PlaceholderCreator();
            var listaExecutors = new List<StringExecutor>()
            {
                new StringExecutor("TEST1", TestOne),
                new StringExecutor("TEST2", TestTwo),
            };
            var result = stringPlaceholder.Creator(text, listaExecutors);
            Assert.Contains("TestOne!", result);
            Assert.Contains("TestTwo!", result);
            string TestOne()
            {
                return "TestOne!";
            }
            string TestTwo()
            {
                return "TestTwo!";
            }
        }

        [Fact]
        public void FindAndReplaceWithCustomPattern_IfContainsResults_ReturnTrue()
        {
            var pattern = @"\%(.*?)\%";
            var text = "Hello, word %TEST1%, %TEST2%";
            var stringPlaceholder = new PlaceholderCreator();
            var listaExecutors = new List<StringExecutor>()
            {
                new StringExecutor("TEST1", TestOne),
                new StringExecutor("TEST2", TestTwo),
            };
            var result = stringPlaceholder.Creator(text, listaExecutors, pattern);
            Assert.Contains("TestOne!", result);
            Assert.Contains("TestTwo!", result);
            string TestOne()
            {
                return "TestOne!";
            }
            string TestTwo()
            {
                return "TestTwo!";
            }
        }
  

        [Fact]
        public void FindAndReplaceWithFluentPattern_BuildExecutorsWithCallback_ReturnTrue()
        {
            var pattern = @"\%(.*?)\%";
            var inputText = "Hello, word %TEST1%, %TEST2%";
            var executorCreator = new ExecutorCreator();
            executorCreator.Create()
                .Add(new StringExecutor("TEST1", TestOne))
                .Add(new StringExecutor("TEST2", TestTwo))
            .Build(pattern, inputText, (result) =>
            {
                Assert.Contains("TestOne!", result);
                Assert.Contains("TestTwo!", result);
            });
            string TestOne()
            {
                return "TestOne!";
            }
            string TestTwo()
            {
                return "TestTwo!";
            }
        }

        [Fact]
        public void FindAndReplaceWithFluentPattern_BuildExecutors_ReturnTrue()
        {
            var pattern = @"\%(.*?)\%";
            var inputText = "Hello, word %TEST1%, %TEST2%";
            var executorCreator = new ExecutorCreator();
            var result = executorCreator.Create()
                .Add(new StringExecutor("TEST1", TestOne))
                .Add(new StringExecutor("TEST2", TestTwo))
            .Build(pattern, inputText);
           
            Assert.Contains("TestOne!", result);
            Assert.Contains("TestTwo!", result);
            string TestOne()
            {
                return "TestOne!";
            }
            string TestTwo()
            {
                return "TestTwo!";
            }
        }
    }
}