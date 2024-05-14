using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class AccountTypeDAO
    {
        public static List<AccountTypeDTO> GetDSAccountTypes()
        {
            List<AccountTypeDTO> dsAccountType = new List<AccountTypeDTO>();
            using(DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.AccountTypes
                            select ca;
                foreach(var row in query)
                {
                    AccountTypeDTO c = new AccountTypeDTO();
                    c.id = row.IDType;
                    c.name = row.TypeName;

                    dsAccountType.Add(c);
                }    
            }
            return dsAccountType;
        }
    }
}
