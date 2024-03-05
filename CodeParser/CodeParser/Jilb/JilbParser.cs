
using CodeParser.Holsted;
using System.Diagnostics;

namespace CodeParser.Jilb
{
    public class JilbParser
    {
        public IDictionary<string, double> ParseCode(string code)
        {
            var count = 0; double operatorsAmount = AmountOfJavaOperators(code);
            var JilbMetrics = new Dictionary<string, double>();
            var lines = code.Split('\r');
            foreach (var line in lines)
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("//")) continue;
                if (trimmedLine.Contains("if") || trimmedLine.Contains("else if")) count++;
            }
            JilbMetrics["CL"] = count;
            JilbMetrics["cl"] = count / operatorsAmount;

            var depth = 0;
            var maxDepth = 0;
            JilbMetrics["CLI"] = CountMaxDepth(depth, maxDepth, 0, lines);
            Trace.WriteLine($"CLI{JilbMetrics["CLI"]}");
            Trace.WriteLine($"CL{JilbMetrics["CL"]}");
            Trace.WriteLine($"cl{JilbMetrics["cl"]}");
            return JilbMetrics;
        }

        private int CountMaxDepth(int curDepth, int maxDepth, int curLine, string[] code)
        {
            //should be added switch, while, for
            if (curLine >= code.Length) return maxDepth;
            string codeLine = code[curLine];
            if(codeLine.Contains("for") || codeLine.Contains("while") || codeLine.Contains("if") || codeLine.Contains("else if")) 
            {
                for (int i = 0; i < codeLine.Length; i++)
                {
                    if (codeLine[i] == '{')
                    {
                        curDepth++;
                        maxDepth = Math.Max(curDepth, maxDepth);
                    }
                    else if (codeLine[i] == '}')
                    {
                        curDepth--;
                    }
                }
            }
            return CountMaxDepth(curDepth, maxDepth, curLine + 1, code);
        }

        private int AmountOfJavaOperators(string code)
        {
            HolstedParser parser = new();
            Dictionary<string, int> dict = new();
            parser.ParseOperators(code, dict);

            var count = 0;
            foreach(var item in dict)
            {
                count += item.Value;
            }
            return count;
        }
    }
}
