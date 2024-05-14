using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCanBoCA
{
    public class AccountGUI
    {
        public static string id;
        public static string pass;
        public static void setUserAccount(string idAcc)
        {
            id = idAcc;
        }
        public static string getUserAccount()
        {
            return id;
        }
        public static void setPassAccount(string passAcc)
        {
            pass = passAcc;
        }
        public static string getPassAccount()
        {
            return pass;
        }
    }
}
