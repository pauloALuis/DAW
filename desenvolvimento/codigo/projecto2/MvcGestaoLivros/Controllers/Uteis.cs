using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projecto2.Controllers
{
    public class Uteis
    {
        
        public static int ConvertStringToInt(String str)
        {
            string[] subs = str.Split('-');
           

            if (int.TryParse(subs[1].TrimEnd().TrimStart(), out int j))
            {
                return j;//https://www.youtube.com/watch?v=_qIYBgWTlTo&t=54s&ab_channel=CodAffection
                         //https://www.youtube.com/watch?v=3zsN1cBNsew&ab_channel=BRIGHTSIDEPROGRAMMING
                         // Console.WriteLine($"'{str}' --> '{numericString}' --> {j}");
            }

            return j;

        }

       
    }
}