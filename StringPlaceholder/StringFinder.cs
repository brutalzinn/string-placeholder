using System.Text.RegularExpressions;

namespace StringPlaceholder
{
    public class StringFinder
    {
        /// <summary>
        /// Try to find a pattern in a text with regex pattern
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="text"></param>
        /// <param name="stringExecutor"></param>
        /// <returns></returns>
        public string FindAndReplace(string pattern, string text, StringExecutor stringExecutor)
        {
            return Regex.Replace(text, pattern, match =>
            {
                var chave = match.Groups[1].ToString().ToUpper();
                if (stringExecutor.Key.Equals(chave))
                {
                    return stringExecutor.Method.Invoke();
                }
                return match.Value;
            });
        }
    }
}
