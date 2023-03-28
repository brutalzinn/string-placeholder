using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPlaceholder.FluentPattern
{
    public interface IExecutorCreator
    {
        IExecutorCreator Create();
        string Result();
        IExecutorCreator Build(string pattern, string inputText, Action<string> result);
        IExecutorCreator Build(string pattern, string inputText);
        IExecutorCreator Add(StringExecutor stringExecutor);
        IEnumerable<OpenApiDescription> GetOpenApiDescription();
    }
}
