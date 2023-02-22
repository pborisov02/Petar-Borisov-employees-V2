using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaSolutionsProblemV2
{
    public class EmpPairs
    {
        public EmpPairs(string id1, string id2, int daysWorked, string projId)
        {
            Emp1Id = id1;
            Emp2Id = id2;
            DaysWorked = daysWorked;
            projectsIds = new List<string>() { projId };
        }
        public string Emp1Id;
        public string Emp2Id;
        public int DaysWorked;
        public List<string> projectsIds;

        public bool Contains(string id1, string id2)
        {
            if ((this.Emp1Id == id1 && this.Emp2Id == id2) || (this.Emp1Id == id2 && this.Emp2Id == id1))
                return true;
            return false;
        }
    }
}
