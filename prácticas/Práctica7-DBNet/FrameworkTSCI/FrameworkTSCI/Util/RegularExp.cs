using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FrameworkTSCI.Util
{
    public class RegularExp
    {
        //@"\b(\w+?\b";
      
        private RegularExp()
        {
       
        }


        public static bool Match(String pattern, String input)
        {
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }
    }
}
