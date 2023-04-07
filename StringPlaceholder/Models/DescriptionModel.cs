using System.Collections.Generic;

namespace StringPlaceholder.Models
{
    public class DescriptionModel
    {
        public string Key { get; }
        public IEnumerable<string> Args { get; }
        public bool MultipleParams { get; }
        public string Description { get; }

        public DescriptionModel(StringExecutor stringExecutor)
        {
            Description = stringExecutor.Description;
            Key = stringExecutor.Key;
            MultipleParams = stringExecutor.EnabledMultipleParams;
            Args = stringExecutor.Args ?? new List<string>();
        }

        public static List<DescriptionModel> BuildDescriptionList(List<StringExecutor> listStringExecutor)
        {
            var description = new List<DescriptionModel>();
            foreach (var stringExecutor in listStringExecutor)
            {
                description.Add(new DescriptionModel(stringExecutor));
            }
            return description;
        }
    }
}
