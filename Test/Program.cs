namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sFixedValue = "TAO%,%BAO,%HKTV%,TMALL,WATSONS+FORTRESS (LTD)";
            string[] list = sFixedValue.Split(',',StringSplitOptions.RemoveEmptyEntries);

            string specialRegEx = "^$*+?.|[](){}\\";

            for (int item = 0; item < list.Length; item++)
            {
                //ii.
                string editedString = SpecialRegExFix(list[item], specialRegEx);
                
                list[item] = editedString;

                // iii.
                editedString = RegularExpressionConverter(editedString);
                
                list[item] = editedString;

                Console.WriteLine(list[item]);
            }
        }

        public static string SpecialRegExFix(string listItem, string specialRegEx)
        {
            string editedString = "";
            for (int itemCharIndex = 0; itemCharIndex < listItem.Length; itemCharIndex++)
            {
                for (int specialCharIndex = 0; specialCharIndex < specialRegEx.Length; specialCharIndex++)
                {

                    if (listItem[itemCharIndex].Equals(specialRegEx[specialCharIndex]))
                    {
                        editedString += "\\";
                        break;
                    }
                }
                editedString += listItem[itemCharIndex];
                
            }
            return editedString;
        }
        public static string RegularExpressionConverter(string s)
        {
            if (s[0].Equals('%') && s[s.Length - 1].Equals('%')) // %WATSONS%
            {
                s = s.Substring(1, s.Length - 2);
            }
            else if (s[0].Equals('%') && !s[s.Length - 1].Equals('%')) //%WATSONS
            {
                s = s.Substring(1, s.Length - 1) + "$";
            }
            else if (!s[0].Equals('%') && s[s.Length - 1].Equals('%')) // WATSONS%
            {
                s = "^" + s.Substring(0, s.Length - 1);
            }
            else if (!s[0].Equals('%') && !s[s.Length - 1].Equals('%')) // WATSONS
            {
                s = "^" + s + "$";
            }
            return s;
        }
    }
}