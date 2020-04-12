using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dist.Models;
using Microsoft.AspNetCore.Mvc;

namespace test_dist.Controllers
{

    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(string code)
        {
            if(Database.st?.students != null)
            {
                foreach (var s in Database.st.students)
                {
                    string alphanum = "", a,b,c,d,e,e2,e3; 
                    char[] x1 = s.Name.ToCharArray();
                    char[] x2 = s.Day.ToCharArray();
                    char[] x3 = s.Month.ToCharArray();
                    char[] x4 = s.Year.ToCharArray();
                    char[] x5 = s.Group.ToCharArray();
                    a = x1[0].ToString(); 
                    b = x2[1].ToString();
                    c = x3[1].ToString();
                    d = x4[3].ToString();
                    e = x5[5].ToString();
                    e2 = x5[7].ToString();
                    e3 = x5[8].ToString();
                    alphanum = a + b + c + d + e + e2 + e3;
                    if (alphanum.Equals(code))
                    {
                        return Content("Student's name: " + s.Name+"\nDate of birthday: "+s.Day+"."+s.Month+"."+s.Year+"\nGroup"+s.Group);
                    }
                }
            }
            return Content("No such student");
        }
    }
}