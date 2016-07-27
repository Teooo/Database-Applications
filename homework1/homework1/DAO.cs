using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace homework1
{
    /* ------- problem 1 ----- */
    class DAO
    {
        public static void addEmp(Employee emp)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Add(emp);
                context.SaveChanges();
            }
        }
        public static List<Employee> findByKey(object key)
        {

            using (var context = new SoftUniEntities())
            {
                var output = new List<Employee>();
                var emps = context.Employees.ToList();
                foreach (var emp in emps)
                {
                    if (emp.FirstName == key.ToString() || emp.LastName == key.ToString() || emp.JobTitle == key.ToString()
                      || emp.HireDate.ToString() == key.ToString())
                    {
                        output.Add(emp);
                    }
                }
                return output;
            }
        }
        public static void deleteEmp(Employee emp)
        {
            using (var context = new SoftUniEntities())
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
        }

    }
}