using System.Collections.Generic;

namespace StringPlaceholder
{
    public class OpenApiDescription
    {
        public string Key { get; }
        public IEnumerable<string> Args { get; }
        public bool MultipleParams { get; }
        public string Description { get;}
 
        public OpenApiDescription(StringExecutor stringExecutor)
        {
            Description = stringExecutor.Description;
            Key = stringExecutor.Key;
            MultipleParams = stringExecutor.EnabledMultipleParams;
            Args = stringExecutor.Args ?? new List<string>();
        }
    }
}
