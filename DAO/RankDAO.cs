using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class RankDAO
    {
        //load CSDL Cấp bậc lên
        public static List<RankDTO> GetRanks()
        {
            List<RankDTO> dsRanks = new List<RankDTO>();
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Ranks
                            select ca;
                foreach (var row in query)
                {
                    RankDTO c = new RankDTO();
                    c.id = row.IDRank;
                    c.name = row.RankName;
                    dsRanks.Add(c);
                }
                return dsRanks;
            }
        }
    }
}
