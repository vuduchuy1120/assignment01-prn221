using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_VuDucHuy_SalesWPFApp
{
    public interface IConstant
    {

        public static string REGEX_NUMBER = "^\\d+$";
        public static string REGEX_DECIMAL = "^\\d+(\\.\\d+)?$";

        public static string REGEX_EMAIL = "^[\\w-\\.+]*[\\w-_\\.]\\@([\\w]+\\.)+[\\w]+[\\w]$";
        public static string REGEX_TEXT = "^[a-z A-Z]*$";
        public static string REGEX_DATE =
                "^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|"
                        + "(?:(?:29|30)(\\/|-|\\.)"
                        + "(?:0?[1,3-9]|1[0-2])\\2))"
                        + "(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$"
                        + "|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)"
                        + "?(?:0[48]|[2468][048]|[13579][26])|"
                        + "(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]"
                        + "|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])"
                        + "|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$";
    }
}
