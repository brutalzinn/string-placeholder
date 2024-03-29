﻿using System.Text.RegularExpressions;

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

        public string FindAndReplaceWithParams(string pattern, string text, StringExecutor stringExecutor, string paramPattern = @"\((.*?)\)")
        {
            string key = "";
            return Regex.Replace(text, pattern, match =>
            {
                var textFound = match.Groups[1].ToString().ToUpper();
                Regex r = new Regex(paramPattern);
                Match m = r.Match(textFound);
                key = textFound.Substring(0, m.Index);

                if (m.Success && stringExecutor.Key.Equals(key))
                {
                    var paramsSalinized = m.Groups[1].Value.Replace(" ", string.Empty).ToLower();
                    var paramsFound = paramsSalinized.Split(',');
                    return stringExecutor.MethodParametrized.Invoke(paramsFound);
                }

                return match.Value;
            });
        }
    }
}
