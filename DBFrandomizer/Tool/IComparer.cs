using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DBFrandomizer.Tool
{
    public class CustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int xVal, yVal;
            int.TryParse(Regex.Match(x, @"\d+").Value, out xVal);
            int.TryParse(Regex.Match(y, @"\d+").Value, out yVal);

            string xString = Regex.Replace(x, @"[^A-Z]+", String.Empty);
            string yString = Regex.Replace(y, @"[^A-Z]+", String.Empty);

            if (xVal != yVal)
                return xVal.CompareTo(yVal);
            else
                return xString.CompareTo(yString);
        }
    }
}
