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
        /// [Key] String normalized with upperCase.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// [Method]. The method to be called after a pattern is found. This needs be a method that returns string.
        /// </summary>
        public Func<string[], string> MethodParametrized { get; private set; }

        /// <summary>
        /// [Method]. The method to be called after a pattern is found. This needs be a method that returns string.
        /// </summary>
        public Func<string> Method { get; private set; }

        public StringExecutor(string key, Func<string> method)
        {
            Key = key;
            Method = method;
        }

        public StringExecutor(string key, Func<string[], string> method)
        {
            Key = key;
            MethodParametrized = method;
            MultipleParams = true;
        }
    }
}
