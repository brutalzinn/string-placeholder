using System;
using System.Collections.Generic;
using System.Linq;

namespace StringPlaceholder.FluentPattern
{
    public class ExecutorCreator : IExecutorCreator
    {
        private List<StringExecutor> StringExecutorList;
        private List<OpenApiDescription> OpenApiDescriptionList;
        private string TextWithPlaceholders;
        public ExecutorCreator()
        {

        }
        public ExecutorCreator(List<StringExecutor> stringExecutors, List<OpenApiDescription> openApiDescriptions)
        {
            StringExecutorList = stringExecutors;
            OpenApiDescriptionList = openApiDescriptions;
            TextWithPlaceholders = "";
        }

        public IExecutorCreator Init()
        {
            var stringExecutors = new List<StringExecutor>();
            var openApiDescriptions = new List<OpenApiDescription>();
            return new ExecutorCreator(stringExecutors, openApiDescriptions);
        }

        public IExecutorCreator Add(StringExecutor stringExecutor)
        {
            StringExecutorList.Add(stringExecutor);
            return this;
        }
        public IExecutorCreator AddRange(IEnumerable<StringExecutor> stringExecutor)
        {
            StringExecutorList.AddRange(stringExecutor);
            return this;
        }
        public IExecutorCreator Build(string inputText, Action<string> resultCallback, string pattern)
        {
            var stringPlaceholder = new PlaceholderCreator();
            TextWithPlaceholders = stringPlaceholder.Creator(inputText, StringExecutorList, pattern);
            resultCallback(TextWithPlaceholders);
            return this;
        }
        public IExecutorCreator Build(string inputText, string pattern)
        {
            var stringPlaceholder = new PlaceholderCreator();
            TextWithPlaceholders = stringPlaceholder.Creator(inputText, StringExecutorList, pattern);
            return this;
        }
        public IEnumerable<OpenApiDescription> GetDescription()
        {
            return OpenApiDescriptionList;
        }
        public IExecutorCreator BuildDescription()
        {
            var openApiDescription = new List<OpenApiDescription>();
            foreach (var stringExecutor in StringExecutorList)
            {
                openApiDescription.Add(new OpenApiDescription(stringExecutor));
            }
            OpenApiDescriptionList = openApiDescription;
            return this;
        }

        public string Result()
        {
            return TextWithPlaceholders;
        }
    }
}
