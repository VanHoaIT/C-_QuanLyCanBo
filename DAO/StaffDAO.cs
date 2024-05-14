using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class StaffDAO
    {
        //lấy danh sách cán bộ từ CSDL
        public static List<StaffDTO> GetDSStaffs()
        {
            List<StaffDTO> dsStaff = new List<StaffDTO>();
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.StaffInfos
                            select ca;
                foreach (var row in query)
                {
                    StaffDTO c = new StaffDTO();
                    c.MaCA = row.ID;
                    c.Name = row.Name;
                    c.Birthday = (DateTime)row.Birthday;
                    c.Gender = row.Gender;
                    c.Address = row.Address;
                    c.IDDepartment = (int)row.IDDepartment;
                    c.IDRank = (int)row.IDRank;
                    dsStaff.Add(c);
                }
            }
            return dsStaff;
        }
        public static bool TestStaff(string ID)
        {
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.StaffInfos
                            where ca.ID == ID
                            select ca;
                if (query.Count() > 0)
                    return true;
                return false;
            }
        }
        public static List<StaffDTO> SearchDSStaffs(string id)
        {
            List<StaffDTO> dsStaff = new List<StaffDTO>();
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.StaffInfos
                            where ca.ID == id
                            select ca;
                foreach (var row in query)
                {
                    StaffDTO c = new StaffDTO();
                    c.MaCA = row.ID;
                    c.Name = row.Name;
                    c.Birthday = (DateTime)row.Birthday;
                    c.Gender = row.Gender;
                    c.Address = row.Address;
                    c.IDDepartment = (int)row.IDDepartment;
                    c.IDRank = (int)row.IDRank;
                    dsStaff.Add(c);
                }
            }
            return dsStaff;
        }
        public static void InsertStaff(string id, string name, DateTime birthday, 
            string gender, string address, int idDepartment,int idRank)
        {
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                StaffInfo c = new StaffInfo();
                c.ID = id;
                c.Name = name;
                c.Birthday = birthday;
                c.Gender = gender;
                c.Address = address;
                c.IDDepartment = idDepartment;
                c.IDRank = idRank;

                data.StaffInfos.InsertOnSubmit(c);
                data.SubmitChanges();
            }    
        }
        public static void DeleteStaff(string id)
        {
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.StaffInfos
                            where ca.ID == id
                            select ca;

                data.StaffInfos.DeleteOnSubmit(query.FirstOrDefault());
                data.SubmitChanges();
            }
        }
        public static void UpdateStaff(string id, string name, DateTime birthday, string gender, string address, int idDepartment, int idRank)
        {
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.StaffInfos
                            where ca.ID == id
                            select ca;

                query.FirstOrDefault().ID = id;
                query.FirstOrDefault().Name = name;
                query.FirstOrDefault().Birthday = birthday;
                query.FirstOrDefault().Gender = gender;
                query.FirstOrDefault().Address = address;
                query.FirstOrDefault().IDDepartment = idDepartment;
                query.FirstOrDefault().IDRank = idRank;
                data.SubmitChanges();
            }
        }
    }
}
