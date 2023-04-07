using System.Collections.Generic;

namespace StringPlaceholder
{
    public class PlaceholderCreator : StringFinder
    {
        /// <summary>
        /// Nuget package to loop through text by a specific placeholder pattern. Replacing the found part with the return of a list of methods.
        /// </summary>
        /// <param name="text">The text to operate</param>
        /// <param name="listExecutors">List of executors with the function that returns a new string</param>
        /// <param name="pattern">The pattern to find the placeholder. This is optional</param>
        /// <returns>new text</returns>
        public string Creator(string text, List<StringExecutor> listExecutors, string pattern = @"\[(.*?)\]")
        {
            var newText = text;
            foreach (var executor in listExecutors)
            {
                var enabledMultipleParams = executor.EnabledMultipleParams;
                if (enabledMultipleParams)
                {
                    newText = FindAndReplaceWithParams(pattern, newText, executor);
                    continue;
                }
                newText = FindAndReplace(pattern, newText, executor);
            }
            return newText;
        }
    }
}