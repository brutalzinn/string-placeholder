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
        public ExecutorCreator()
        {

        }
        public ExecutorCreator(List<StringExecutor> stringExecutors, List<OpenApiDescription> openApiDescriptions)
        {
            StringExecutorList = stringExecutors;
            OpenApiDescriptionList = openApiDescriptions;
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
            var result = stringPlaceholder.Creator(inputText, StringExecutorList, pattern);
            resultCallback(result);
            return this;
        }
        public string Build(string pattern, string inputText)
        {
            OpenApiDescriptionList = CreateOpenApiDescription(StringExecutorList);
            var stringPlaceholder = new PlaceholderCreator();
            var result = stringPlaceholder.Creator(inputText, StringExecutorList, pattern);
            return result;
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
    }
}
