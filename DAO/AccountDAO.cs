using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class AccountDAO
    {
        public static bool Login(string user, string pass)
        {
            using(DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Accounts
                            where ca.UserName == user && ca.PassWord == pass
                            select ca;
                if (query.Count() > 0)
                    return true;
                return false;
            }    
        }

        public static bool Admin(string User)
        {
            using(DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Accounts
                            where ca.UserName == User && ca.Type == 1
                            select ca;
                if (query.Count() > 0)
                    return true;
                return false;
            }    
        }
        public static AccountDTO Account(string User)
        {
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Accounts
                            where ca.UserName == User
                            select ca;
                if (query.Count() > 0)
                {
                    AccountDTO acc = new AccountDTO();
                    acc.User = query.FirstOrDefault().UserName;
                    acc.Password = query.FirstOrDefault().PassWord;
                    acc.Name = query.FirstOrDefault().DisplayName;
                    acc.idType = query.FirstOrDefault().Type;

                    return acc;
                }
                return null;
            }
        }
        public static bool TestAccount(string user)
        {
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Accounts
                            where ca.UserName == user
                            select ca;
                if (query.Count() > 0)
                    return true;
                return false;
            }
        }
        public static void UpdateAccount(string user, string name, string pass, int type)
        {
            using(DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Accounts
                            where ca.UserName == user
                            select ca;

                query.FirstOrDefault().UserName = user;
                query.FirstOrDefault().PassWord = pass;
                query.FirstOrDefault().DisplayName = name;
                query.FirstOrDefault().Type = type;

                data.SubmitChanges();
            }  
        }
        public static List<AccountDTO> GetDSAccounts()
        {
            List<AccountDTO> dsAccount = new List<AccountDTO>();
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Accounts
                            select ca;
                foreach(var row in query)
                {
                    AccountDTO c = new AccountDTO();
                    c.User = row.UserName;
                    c.Password = row.PassWord;
                    c.Name = row.DisplayName;
                    c.idType = row.Type;
                    dsAccount.Add(c);
                }    
            }
            return dsAccount;
        }
        public static void InsertAccount(string user, string name, string pass, int type)
        {
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                Account acc = new Account();
                acc.UserName = user;
                acc.DisplayName = name;
                acc.PassWord = pass;
                acc.Type = type;

                data.Accounts.InsertOnSubmit(acc);
                data.SubmitChanges();
            }    
        }
        public static void DeleteAccount(string user)
        {
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Accounts
                            where ca.UserName == user
                            select ca;

                data.Accounts.DeleteOnSubmit(query.FirstOrDefault());
                data.SubmitChanges();
            }    
        }
    }
}
