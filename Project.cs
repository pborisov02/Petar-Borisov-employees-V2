using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaSolutionsProblemV2
{
    public class Project
    {
        List<Employee> employees = new List<Employee>();

        public Project(string id)
        {
            ProjId = id;
        }
        private string projId;

        public string ProjId
        {
            get { return projId; }
            set { projId = value; }
        }

        public List<Employee> Employees
        {
            get { return employees; }
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            employees = employees.OrderBy(e => e.StartDate).ToList();
        }

    }
}
