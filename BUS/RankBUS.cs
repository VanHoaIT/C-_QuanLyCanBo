using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class RankBUS
    {
        public static List<RankDTO> GetRanks()
        {
            return DAO.RankDAO.GetRanks();  
        }
    }
}
