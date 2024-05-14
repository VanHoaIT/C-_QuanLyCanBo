using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DepartmentDAO
    {
        //load CSDL phòng ban lên
        public static List<DepartmentDTO> GetDepartments()
        {
            List<DepartmentDTO> dsDepartments = new List<DepartmentDTO>();
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Departments
                            select ca;
                foreach(var row in query)
                {
                    DepartmentDTO c = new DepartmentDTO();
                    c.id = row.IDDepartment;
                    c.name = row.DepartmentName;
                    dsDepartments.Add(c);
                }    
                return dsDepartments;
            }    
        }
        public static bool TestDepartment(int ID)
        {
            using (DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Departments
                            where ca.IDDepartment == ID
                            select ca;
                if (query.Count() > 0)
                    return true;
                return false;
            }    
        }
        public static void InsertDepartment(int id, string name)
        {
            using(DataClasses1DataContext data = new DataClasses1DataContext())
            {
                Department c = new Department();
                c.IDDepartment = id;
                c.DepartmentName = name;

                data.Departments.InsertOnSubmit(c);
                data.SubmitChanges();
            } 
        }
        public static void DeleteDepartment(int id)
        {
            using(DataClasses1DataContext data = new DataClasses1DataContext())
            {
                var query = from ca in data.Departments
                            where ca.IDDepartment == id
                            select ca;

                data.Departments.DeleteOnSubmit(query.FirstOrDefault());
                data.SubmitChanges();
            } 
        }
        public static void UpdateDepartment(int id, string name)
        {
            using(DataClasses1DataContext data =new DataClasses1DataContext())
            {
                var query = from ca in data.Departments
                            where ca.IDDepartment == id
                            select ca;

                query.FirstOrDefault().IDDepartment = id;
                query.FirstOrDefault().DepartmentName = name;
                data.SubmitChanges();
            }    
        }    
    }
}
