using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dist.Models;

namespace test_dist
{
    public class Database
    {
        private Database() {}
        public static Database st = new Database();

        public List<Students> students
        {
            get
            {
                List<Students> students = new List<Students>();
                students.Add(new Students("Mirzhan","08", "12","1999", "CSSE1703K"));//M01173K
                students.Add(new Students("Aza","29","02","1999", "CSSE1702K"));//A92972K
                students.Add(new Students("Belgi","15","10","2000", "CSSE1701K"));//B50071K
                students.Add(new Students("Zabyl","09","04","2001", "CSSE1704K"));//Z94174K
                students.Add(new Students("Nonames","31","06","1998", "CSSE1705K"));//N16875K
                students.Add(new Students("Nurbek","14","07","1999", "CSSE1706K"));//N47976K
                students.Add(new Students("Ilka","07","09","1997", "CSSE1707R"));//I79777R
                students.Add(new Students("Meir","03","01","1998", "CSSE1708R"));//M31878R
                students.Add(new Students("Nur","28","03","1999", "CSSE1709R"));//N83979R
                students.Add(new Students("Anel","07","11","2000", "CSSE1710R"));//A71070R
                return students;
            }
        }



    }
}
