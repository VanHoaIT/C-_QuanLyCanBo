using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class StaffBUS
    {
        public static List<StaffDTO> GetDSStaffs()
        {
            return DAO.StaffDAO.GetDSStaffs();
        }
        public static bool TestStaff(string id)
        {
            return DAO.StaffDAO.TestStaff(id);
        }
        public static List<StaffDTO> SearchDSStaffs(string id)
        {
            return DAO.StaffDAO.SearchDSStaffs(id);
        }
        public static void InsertStaff(string id, string name, DateTime birthday, 
            string gender, string address, int idDepartment, int idRank)
        {
            DAO.StaffDAO.InsertStaff(id, name, birthday, gender, address, idDepartment, idRank);
        }    
        
        public static void DeleteStaff(string id)
        {
            DAO.StaffDAO.DeleteStaff(id);
        }
        public static void UpdateStaff(string id, string name, DateTime birthday, string gender, string address, int idDepartment, int idRank)
        {
            DAO.StaffDAO.UpdateStaff(id, name, birthday, gender, address, idDepartment,idRank);
        }    
    }
}
