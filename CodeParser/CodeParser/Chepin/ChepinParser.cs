using CodeParser.Holsted;
using System.Text.RegularExpressions;

namespace CodeParser.Chepin
{
    public class ChepinParser
    {
       // Классификация переменных
       // 1. Р – вводимые переменные, содержащие исходную информацию, но не модифицируемые в программе и не являющиеся управляющими переменными;
       // 2. М – модифицируемые переменные и создаваемые внутри программы константы и переменные, не являющиеся управляющими переменными;
       // 3. С – переменные, участвующие в управлении работой программного модуля(управляющие переменные);
       // 4. Т – не используемые в программе(«паразитные») переменные, например, вычисленные переменные,
       // значения которых не выводятся и не участвуют в дальнейших вычислениях.

        HolstedParser operandParser;
        public ChepinParser() 
        { 
            operandParser = new HolstedParser();
        }
        public Dictionary<string, string[]> ParseCode(string code)
        {
            var dict = new Dictionary<string, string[]>();
            return dict;
        } 

        public Dictionary<string, int> CalculateSpan(string code)
        {
            var dict = new Dictionary<string, int>();
            operandParser.ParseOperands(code, dict);
            foreach(var item in  dict) 
            {
                Console.WriteLine(item.Key, item.Value);
            }
            return dict;
        }

        private Dictionary<string,int> ParseIOOperands(string code)
        {
            var op_dict = new Dictionary<string, int>();
            Regex regexp = new Regex("System\\b\\.(out\\b|in\\b|err\\b)\\.(println\\b|read\\b)\\(([^)\"\"]*)\\)");
            MatchCollection matches = regexp.Matches(code);
            if(matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if(!op_dict.ContainsKey(match.Value)) 
                    {
                        op_dict.Add(match.Value, 0);
                    }
                }
            }
            return op_dict;
        } 
    }
}
