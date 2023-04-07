using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPlaceholder.FluentPattern
{
    public interface IExecutorCreator
    {
        IExecutorCreator Init();
        string Result();
        IExecutorCreator Build(string inputText, Action<string> result, string pattern = @"\[(.*?)\]");
        IExecutorCreator Build(string inputText, string pattern = @"\[(.*?)\]");
        IExecutorCreator Add(StringExecutor stringExecutor);
        IExecutorCreator AddRange(IEnumerable<StringExecutor> stringExecutor);
        IEnumerable<OpenApiDescription> GetDescription();
        IExecutorCreator BuildDescription();
    }
}
