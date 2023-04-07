using StringPlaceholder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringPlaceholder.FluentPattern
{
    public class ExecutorCreator : IExecutorCreator
    {
        private List<StringExecutor> StringExecutorList;
        private List<DescriptionModel> Descriptions;
        private string TextWithPlaceholders;
        public ExecutorCreator()
        {

        }
        public ExecutorCreator(List<StringExecutor> stringExecutors, List<DescriptionModel> descriptions)
        {
            StringExecutorList = stringExecutors;
            Descriptions = descriptions;
            TextWithPlaceholders = "";
        }

        public IExecutorCreator Init()
        {
            var stringExecutors = new List<StringExecutor>();
            var descriptions = new List<DescriptionModel>();
            return new ExecutorCreator(stringExecutors, descriptions);
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
        public IEnumerable<DescriptionModel> GetDescription()
        {
            return Descriptions;
        }
        public IExecutorCreator BuildDescription()
        {
            var descriptions = DescriptionModel.BuildDescriptionList(StringExecutorList);
            Descriptions = descriptions;
            return this;
        }

        public string Result()
        {
            return TextWithPlaceholders;
        }
    }
}
