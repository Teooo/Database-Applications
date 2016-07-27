using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace homework1
{
    class Program
    {
        public static void ProjecsBetween2001and2003(SoftUniEntities input)
        {
            var emps = input.Projects.Where(e => e.StartDate.Year >= 2001 && e.StartDate.Year <= 2003);
            foreach (var emp in emps)
            {
                Console.WriteLine("--------" + emp.Name + "---------");
                foreach (var e in emp.Employees)
                {
                    Console.WriteLine(e.FirstName + " " + e.LastName + " START : " + emp.StartDate + " END: " + emp.EndDate);
                }
            }

        }
        public static void groupByAddressName(SoftUniEntities input)
        {
            var results = input.Employees
                .GroupBy(e => e.Address.AddressText)
                .OrderByDescending(g => g.Count()).Take(10);
            foreach(var resutl in results)
            {
                string town = "";
                foreach(var townName in resutl)
                {
                    town = townName.Address.Town.Name;
                }
                Console.WriteLine("{0} ,{1} lives {2} employee", resutl.Key,town, resutl.Count());
            }
                
                
        }
        public static void findEmployeeProjects(SoftUniEntities input, int id)
        {
            var emp = input.Employees.Find(id)
                .Projects.OrderBy(e=>e.Name);
            var name = input.Employees.Find(id).FirstName;
            var lastname = input.Employees.Find(id).LastName;
            var jobtitle = input.Employees.Find(id).JobTitle;
            Console.WriteLine("{0} {1} in {2}  works on :", name, lastname, jobtitle);
            foreach(var projects in emp)
            {
                Console.WriteLine(projects.Name);
            }
        }
        public static void PrindDepWithMoreThan5Emps(SoftUniEntities input)
        {
            var results = (
                from emp in input.Employees
                join dep in input.Departments on emp.DepartmentID equals dep.DepartmentID
                join manager in input.Employees on dep.ManagerID equals manager.EmployeeID
                group emp by dep.Name into deps
                where deps.Count() > 5
                orderby deps.Count()
                select deps

                );
            foreach(var result in results)
                {
                string depName = "";
                string manName = " ";
                
                foreach(var dep in result)
                {
                    depName = dep.Department.Name;
                    manName = dep.Department.Employee.LastName;
                }
                Console.WriteLine("in Dep:{0}, Manager name: {1}, works {2} employees", depName,manName, result.Count());
                }
        }
        public static void printNamesNative(SoftUniEntities context)
        {
            string query = "select e.FirstName from Employees e join EmployeesProjects ep on ep.EmployeeID = e.EmployeeID join Projects p on p.ProjectID = ep.ProjectID  where YEAR(p.StartDate) = 2002";
            var result = context.Database.SqlQuery<string>(query).ToList();
           
            foreach(var emp in result)
            {
                //Console.WriteLine(emp);
            }
        }
        public static void PrintWithLinq(SoftUniEntities context)
        {
            var result = context.Projects.Where(e => e.StartDate.Year == 2002).ToList();
            foreach(var emps in result)
            {
                foreach(var emp in emps.Employees)
                {
                   // Console.WriteLine(emp.FirstName);
                }
            }

        }
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            //ProjecsBetween2001and2003(context);
            // groupByAddressName(context);
            //findEmployeeProjects(context, 4);
            //PrindDepWithMoreThan5Emps(context);
            //var totalcount = context.Employees.Count();
            //var sw = new Stopwatch();
            //sw.Start();
            //printNamesNative(context);
            //Console.WriteLine("{0}, native", sw.Elapsed);
            //sw.Restart();
            //PrintWithLinq(context);
            //Console.WriteLine("{0}, linq", sw.Elapsed);
            var storProc = context.usp_getProjectsByEmployee("Ruth", "Ellerbrock");
            foreach(var result in storProc)
            {
                Console.WriteLine("Project name: {0}, description:{1}, startDate:{2}", result.Name, result.Description, result.StartDate);
            }
            
        }  
    }
}
