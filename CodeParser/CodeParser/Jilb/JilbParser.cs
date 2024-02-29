
using System.Diagnostics;

namespace CodeParser.Jilb
{
    public class JilbParser
    {
        public IDictionary<string, int> ParseCode(string code)
        {
            var count = 0; var operatorsAmount = 1;
            var JilbMetrics = new Dictionary<string, int>();
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
            JilbMetrics["CLI"] = CountMaxDepth(depth, maxDepth, 0, lines) - 1;
            Trace.WriteLine(JilbMetrics["CLI"]);
            int a = 0;
            return JilbMetrics;
        }

        private int CountMaxDepth(int curDepth, int maxDepth, int curLine, string[] code)
        {
            if (curLine >= code.Length) return maxDepth;
            string codeLine = code[curLine];
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
            return CountMaxDepth(curDepth, maxDepth, curLine + 1, code);
        }


    }
}
