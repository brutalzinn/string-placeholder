namespace StringPlaceholder
{
    /// <summary>
    /// The schema of StringExecutor.
    /// This class is based a constructor with Key/Method 
    /// The [Key] is a string normalized with upperCase and the [Method] is the method to be called.
    /// The method needs be a string return.
    /// </summary>
    public class StringExecutor
    {
        public bool EnabledMultipleParams { get => MultipleParams; }
        private bool MultipleParams;

        /// <summary>
        /// Description of this StringExecutor. Usefull to document placeholder params. This is cool when you use with openapi description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Custom param string array
        /// </summary>
        public IEnumerable<string>? Args { get; private set; }

        /// <summary>
        /// [Key] String normalized with upperCase.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// [Method]. The method to be called after a pattern is found. This needs be a method that returns string and receive a string[] as param
        /// </summary>
        public Func<string[], string> MethodParametrized { get; private set; }

        /// <summary>
        /// [Method]. The method to be called after a pattern is found. This needs be a method that returns string.
        /// </summary>
        public Func<string> Method { get; private set; }

        /// <summary>
        /// Create default string executor. 
        /// </summary>
        /// <param name="key">Unique identifier</param>
        /// <param name="method">Method callback</param>
        /// <param name="description">Description ( cna be used with OpenApi support to auto description )</param>
        public StringExecutor(string key, Func<string> method, string description = "")
        {
            Key = key;
            Method = method;
            Description = description;
        }
        /// <summary>
        ///  Create String Executor
        /// </summary>
        /// <param name="key">Unique identifier</param>
        /// <param name="method">Method callback with multiple arguments support</param>
        /// <param name="description">Description ( cna be used with OpenApi support to auto description )</param>
        /// <param name="args">Create string executor that accept arguments</param>
        public StringExecutor(string key, Func<string[], string> method, string description = "", IEnumerable<string>? args = null)
        {
            Key = key;
            MethodParametrized = method;
            MultipleParams = true;
            Description = description;
            Args = args;
        }
    }
}
