using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class AccountTypeBUS
    {
        public static List<AccountTypeDTO> GetDSAccountTypes()
        {
            return DAO.AccountTypeDAO.GetDSAccountTypes();
        }
    }
}
