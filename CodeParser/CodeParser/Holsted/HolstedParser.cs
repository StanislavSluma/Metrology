using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeParser.Holsted
{
    public class HolstedParser
    {
        public ObservableCollection<HolstedInfo> HolstedInfo { get; set; } = new();

        public HolstedParser()
        {
            HolstedInfo.Add(new HolstedInfo(1, "+", 32));
            HolstedInfo.Add(new HolstedInfo(2, "if", 3));
            HolstedInfo.Add(new HolstedInfo(3, "()", 3));
            HolstedInfo.Add(new HolstedInfo(4, "$5%", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
            HolstedInfo.Add(new HolstedInfo(5, "+-", 2));
        }

        public IDictionary<string, int> ParseCode(string code)
        {
            var dict = new Dictionary<string, int>();
            dict.Add("Mama", 3);
            return dict;
        }
    }
}
