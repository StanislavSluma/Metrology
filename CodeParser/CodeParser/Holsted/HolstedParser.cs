using System.Text.RegularExpressions;


namespace CodeParser.Holsted
{
    public class HolstedParser
    {
        List<string> spec_s = new List<string>() { "int", "double", "String", "float", "boolean", "byte", "short", "long", "char"};
        public (IDictionary<string, int>, IDictionary<string, int>) ParseCode(string code)
        {
            Dictionary<string, int> op_map = new ();
            Dictionary<string, int> opnd_map = new();
            ParseOperators(code, op_map);
            ParseOperands(code, opnd_map);
            return (op_map, opnd_map);
        }

        public void ParseOperators(string input, Dictionary<string, int> map)
        {
            ParseBasicOperators(input, map);
            ParseDifficultOperators(input, map);
        }

        public void ParseBasicOperators(string input, Dictionary<string, int> map)
        {
            Regex regex = new Regex("(\\?(?=(.*:)))|([+\\-*%/><&|^=!]*=)|(\\+{1,2}|-{1,2}|\\*|/|%|>{1,3}|<{1,2}|\\|\\||&&|!|\\||\\^|&|~|\\.|;)");
            MatchCollection matches = regex.Matches(input);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    string val = match.Value;
                    if (val == "?")
                        val += ":";
                    if (map.ContainsKey(val))
                    {
                        map[val] += 1;
                    }
                    else
                    {
                        map.Add(val, 1);
                    }

                }
            }
        }

        public void ParseDifficultOperators(string allinput, Dictionary<string, int> map)
        {
            Regex regex = new Regex(@"([\w\d]* ?\(.*\))|(do|case|default|break|continue)");
            var splitstr = allinput.Split('\r');
            foreach (var input in splitstr)
            {
                MatchCollection matches = regex.Matches(input);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        string str = match.Value;
                        int k = 0;
                        if (str.Contains('('))
                        {
                            string substr = str.Substring(str.IndexOf('(') + 1);
                            substr = substr.Remove(substr.Length - 1);
                            foreach (char c in substr)
                            {
                                if (c == '(')
                                    k++;
                            }
                            //ParseDifficultOperators(substr, map);
                            if (str.IndexOf('(') != 0)
                                str = str.Remove(str.IndexOf('('));
                            else
                                str = " ";
                            if (str.Last() == ' ')
                            {
                                str.Remove(str.Length - 1);
                            }
                            str += "()";
                        }
                        if (map.ContainsKey(str))
                        {
                            map[str] += 1 + k;
                        }
                        else
                        {
                            map.Add(str, 1 + k);
                        }
                    }
                }
            }
        }

        public void ParseOperands(string input, Dictionary<string, int> map)
        {
            Regex regex = new Regex(@"(((?<=(=|\+|-|\*|/|%|>{1,3}|<{1,2}|\|\||&&|!|\||\^|&|~|:|\(|,)\s*)[\d\w]+)|([\d\w]+(?=\s*(([+\-*%/><&|^=!]*=)|>|<|\+\+|--|\)))))");
            MatchCollection matches = regex.Matches(input);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (spec_s.Contains(match.Value))
                        continue;
                    if (map.ContainsKey(match.Value))
                    {
                        map[match.Value] += 1;
                    }
                    else
                    {
                        map.Add(match.Value, 1);
                    }

                }
            }
        }
    }
}
