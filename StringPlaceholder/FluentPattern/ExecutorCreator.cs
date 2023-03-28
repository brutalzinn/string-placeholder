using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        public IExecutorCreator Create()
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
        public IExecutorCreator Build(string pattern, string inputText, Action<string> resultCallback)
        {
            OpenApiDescriptionList = CreateOpenApiDescription(StringExecutorList);
            var stringPlaceholder = new PlaceholderCreator();
            TextWithPlaceholders = stringPlaceholder.Creator(inputText, StringExecutorList, pattern);
            resultCallback(TextWithPlaceholders);
            return this;
        }
        public IExecutorCreator Build(string pattern, string inputText)
        {
            OpenApiDescriptionList = CreateOpenApiDescription(StringExecutorList);
            var stringPlaceholder = new PlaceholderCreator();
            TextWithPlaceholders = stringPlaceholder.Creator(inputText, StringExecutorList, pattern);
            return this;
        }
        public IEnumerable<OpenApiDescription> GetOpenApiDescription()
        {
            return OpenApiDescriptionList;
        }
        private List<OpenApiDescription> CreateOpenApiDescription(List<StringExecutor> stringExecutors)
        {
            var openApiDescription = new List<OpenApiDescription>();
            foreach (var stringExecutor in stringExecutors)
            {
                openApiDescription.Add(new OpenApiDescription(stringExecutor));
            }
            return openApiDescription;
        }

        public string Result()
        {
            return TextWithPlaceholders;
        }
    }
}
