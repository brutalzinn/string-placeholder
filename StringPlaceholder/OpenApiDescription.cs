using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPlaceholder
{
    public class OpenApiDescription
    {
        private string Key { get; }
        private IEnumerable<string> Args { get; }
        private bool MultipleParams { get; }
        private string Description { get;}
  
        public OpenApiDescription(StringExecutor stringExecutor)
        {
            Description = stringExecutor.Description;
            Key = stringExecutor.Key;
            MultipleParams = stringExecutor.EnabledMultipleParams;
            Args = stringExecutor.Args ?? new List<string>();

        }
    }
}
