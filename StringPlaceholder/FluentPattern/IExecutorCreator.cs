using StringPlaceholder.Models;
using System;
using System.Collections.Generic;

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
        IEnumerable<DescriptionModel> GetDescription();
        IExecutorCreator BuildDescription();
    }
}
