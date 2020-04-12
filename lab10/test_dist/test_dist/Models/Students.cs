using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_dist.Models
{
    public class Students
    {
        public string Name { get; set; }
        public string Day {get; set;}
        public string Month {get; set;}
        public string Year {get; set;}
        public string Group {get; set;}

        public Students(string Name, string Day, string Month, string Year, string Group)
        {
            this.Name = Name;
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
            this.Group = Group;
        }
    }
}
