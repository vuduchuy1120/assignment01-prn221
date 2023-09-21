using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace _17_VuDucHuy_SalesWPFApp
{
    public class Validate
    {
        private Validate() { }

        public static bool GetInt(string errorMsg, string input)
        {
            int n;
            while (true)
            {
                try
                {
                    n = Int32.Parse(input);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(errorMsg);
                }

            }
        }

        public static double GetDouble(string errorMsg, string input)
        {
            double n;
            while (true)
            {
                try
                {
                    n = Double.Parse(input);
                    return n;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(errorMsg);
                }

            }
        }

        public static decimal GetDecimal(string errorMsg, string input)
        {
            decimal n;
            while (true)
            {
                try
                {
                    n = Decimal.Parse(input);
                    return n;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(errorMsg);
                }
            }
        }

        public static string GetString(string messageError,string input, string REGEX)
        {
            do
            {
                string str = input;
                if (Regex.IsMatch(str,REGEX))
                {
                    return str;
                }
                MessageBox.Show(messageError);
            } while (true);
        }


    }
}
