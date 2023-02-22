using System.Collections.Generic;

namespace SirmaSolutionsProblemV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Project> projects = new List<Project>();
            List<EmpPairs> empPairs = new List<EmpPairs>();
            using (var reader = new StreamReader(@"C:\Users\Go6o\Desktop\sirma2.csv"))
            {
                while (true)
                {
                    bool projectExist = false;
                    string input = reader.ReadLine();
                    if (input == null)
                        break;
                    string[] arguments = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    string empId = arguments[0];
                    string projId = arguments[1];
                    string startDate = arguments[2];
                    string endDate = arguments[3];
                    if (endDate == "NULL")
                        endDate = DateTime.Today.ToShortDateString();
                    foreach (var project in projects)
                    {
                        if (project.ProjId == projId)
                        {
                            project.AddEmployee(new Employee(empId, startDate, endDate));
                            projectExist = true;
                        }
                    }
                    if (!projectExist)
                    {
                        Project p = new Project(projId);
                        p.AddEmployee(new Employee(empId, startDate, endDate));
                        projects.Add(p);
                    }
                }

            }

            foreach (var project in projects)
            {
                if (project.Employees.Count >= 2)
                {
                    for (int i = 0; i < project.Employees.Count; i++)
                    {

                        for (int j = i + 1; j < project.Employees.Count; j++)
                        {
                            bool contains = false;
                            int daysWorked = 0;
                            if (project.Employees[i].EndDate > project.Employees[j].StartDate)
                            {
                                if (project.Employees[i].EndDate <= project.Employees[j].EndDate)
                                {
                                    daysWorked = Math.Abs(project.Employees[j].StartDate.DayNumber - project.Employees[i].EndDate.DayNumber);
                                }
                                else
                                {
                                    daysWorked = Math.Abs(project.Employees[j].StartDate.DayNumber - project.Employees[j].EndDate.DayNumber);
                                }
                                foreach (var pair in empPairs)
                                {
                                    if (pair.Contains(project.Employees[i].Id, project.Employees[j].Id))
                                    {
                                        pair.DaysWorked += daysWorked;
                                        pair.projectsIds.Add(project.ProjId);
                                        contains = true;
                                    }
                                }
                                if (!contains)
                                {
                                    var pair = new EmpPairs(project.Employees[i].Id, project.Employees[j].Id, daysWorked, project.ProjId);
                                    empPairs.Add(pair);
                                }
                            }
                            
                        }
                    }
                }
            }

            empPairs = empPairs.OrderByDescending(ep => ep.DaysWorked).ToList();

            for (int i = 0; i < empPairs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Employees: {empPairs[i].Emp1Id} and {empPairs[i].Emp2Id} have worked together for {empPairs[i].DaysWorked} days on project/s: {string.Join(", ", empPairs[i].projectsIds)}");
            }
        }
    }
}