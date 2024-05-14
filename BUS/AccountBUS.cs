using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class AccountBUS
    {
        public static bool Login(string user, string pass)
        {
            return DAO.AccountDAO.Login(user, pass);
        }
        public static bool Admin(string user)
        {
            return DAO.AccountDAO.Admin(user);
        }
        public static AccountDTO account(string user)
        {
            return DAO.AccountDAO.Account(user);
        }
        public static bool TestAccount(string user)
        {
            return DAO.AccountDAO.TestAccount(user);
        }
        public static void UpdateAccount(string user, string name, string pass, int type)
        {
            DAO.AccountDAO.UpdateAccount(user, name, pass, type);
        }
        public static List<AccountDTO> GetDSAccount()
        {
            return DAO.AccountDAO.GetDSAccounts();
        }
        public static void InsertAccount(string user, string name, string pass, int type)
        {
             DAO.AccountDAO.InsertAccount(user, name, pass, type);
        }
        public static void DeleteAccount(string user)
        {
            DAO.AccountDAO.DeleteAccount(user);
        }
    }
}
