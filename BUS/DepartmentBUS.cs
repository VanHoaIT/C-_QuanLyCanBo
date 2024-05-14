using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class DepartmentBUS
    {
        public static List<DepartmentDTO> GetDepartments()
        {
            return DAO.DepartmentDAO.GetDepartments();
        }
        public static bool TestDepartment(int id)
        {
            return DAO.DepartmentDAO.TestDepartment(id);
        }
        public static void InsertDepartment(int id, string name)
        {
            DAO.DepartmentDAO.InsertDepartment(id,name);
        }
        public static void DeleteDepartment(int id)
        {
            DAO.DepartmentDAO.DeleteDepartment(id);
        }
        public static void UpdateDepartment(int id, string name)
        {
            DAO.DepartmentDAO.UpdateDepartment(id,name);
        }
         

    }
}
