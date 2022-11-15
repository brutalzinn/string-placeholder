using StringPlaceholder;
using Xunit;

namespace Testes
{
    public class Program
    {
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
        public void FindAndReplaceWithCustomPattern_IfTextWithWrongFormatNoContainsResults_ReturnTrue()
        {
            var pattern = @"\%(.*?)\%";
            var text = "Hello, word @TEST1@, @TEST@%";
            var stringPlaceholder = new PlaceholderCreator();
            var listaExecutors = new List<StringExecutor>()
            {
                new StringExecutor("TEST1", TestOne),
                new StringExecutor("TEST2", TestTwo),
            };
            var result = stringPlaceholder.Creator(text, listaExecutors, pattern);
            Assert.DoesNotContain("TestOne!", result);
            Assert.DoesNotContain("TestTwo!", result);
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