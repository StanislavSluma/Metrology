
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
            var codezero = code;
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
            JilbMetrics["CLI"] = CountMaxDepth(depth, maxDepth, codezero.IndexOf("if"), codezero);
            Trace.WriteLine($"CLI{JilbMetrics["CLI"]}");
            Trace.WriteLine($"CL{JilbMetrics["CL"]}");
            Trace.WriteLine($"cl{JilbMetrics["cl"]}");
            return JilbMetrics;
        }

        private int CountMaxDepth(int curDepth, int maxDepth, int curPos, string code)
        {
            int index = 0;
            try
            {
                if (curPos >= code.Length || curPos < 0)
                {
                    //Trace.WriteLine(maxDepth);
                    return maxDepth;
                }

                index = code.IndexOf("if", curPos+1);
                if (index == -1 && curDepth == 0)
                    return maxDepth;
                if (index == -1) index = code.Length;

                for (; curPos < index; curPos++)
                {
                    if (code[curPos] == '{')
                    {
                        curDepth++;
                        maxDepth = Math.Max(curDepth, maxDepth);
                    }
                    else if (code[curPos] == '}')
                    {
                        curDepth--;
                        if (curDepth == 0 && (index == code.Length || index == -1))
                        {
                            //Trace.WriteLine(maxDepth);
                            return maxDepth;
                        }
                    }
                }
            }
            catch(Exception e) 
            {
                var mama = e.Message;
                mama += " ";
            }

            return CountMaxDepth(curDepth, maxDepth, index, code);
            /*if ()
            {
                if ()
                {
                    if ()
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
                if ()
                {
                }
            }*/
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
