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
            MatchCollection matches = Regex.Matches(text, pattern);
            var replaceDict = new Dictionary<string, string>();
            foreach (Match m in matches)
            {
                var chave = m.Groups[1].ToString().ToUpper();

                if (stringExecutor.Key.Equals(chave) && replaceDict.ContainsKey(chave) == false)
                {
                    replaceDict.Add(chave, stringExecutor.Method.Invoke());
                }
            }

            return Regex.Replace(text, pattern, match =>
            {
                string resultado = "";
                var valorEncontrado = match.Groups[1].ToString().ToUpper();
                var existeSubstituicao = replaceDict.TryGetValue(valorEncontrado, out resultado);
                if (existeSubstituicao)
                {
                    return resultado;
                }
                return match.Value;
            });

        }
    }
}
