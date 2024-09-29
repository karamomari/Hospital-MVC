using Hospital.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;

namespace Hospital.Controllers
{
    public class LoginController : Controller
    {
        readonly HospitallContext context;
        public LoginController(HospitallContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult Indexx()
		{
			return RedirectToAction("visitor","Home");
		}
		[HttpPost]
        public IActionResult Login([Bind("Email,Passward")] Employee employee,string JopType)
        {
            ViewBag.type = JopType;
            if (JopType == "Patient")
            {

                var patain = context.Patients.Where(y => y.Email == employee.Email && y.Passward == employee.Passward).FirstOrDefault();

                if (patain != null)
                {
                    if (patain.Enaple == "e" || patain.Enaple == "E")
                    {
                        string pat = JopType;
                        int id = patain.PatId;
                        return RedirectToAction(pat, "Patient", new { id = id });
                    }
                    else
                    {
						return RedirectToAction("Waitadmid");
					}
				}
            }
           
                employee.JopType = JopType;
                var empll = context.Employees.Where(op => op.JopType == employee.JopType).Where(y => y.Email == employee.Email && y.Passward == employee.Passward).FirstOrDefault();
                if (empll != null)
                {

                    if ( empll.Enaple != "D")
                    {
                        int id = empll.EmpId;
                        string empp = employee.JopType;
                        return RedirectToAction(empp, "Employee", new { id = id });
                    }
                    else
                    {
                        return RedirectToAction("Waitadmid");
                    }
                }
            return RedirectToAction("notfaound");

               
        }

		public IActionResult notfaound()
		{
			return View();
		}

		public IActionResult Waitadmid()
		{
			return View();
		}



		[HttpPost]
        public IActionResult register([Bind("Fname,Lname,Email,Passward,Address,JopType")] Employee employee,string JopType) 
        {
            if (JopType == "Patient")
            {
                Patient patient = new Patient();
                patient.Fname = employee.Fname;
                patient.Lname = employee.Lname;
                patient.Email = employee.Email;
                patient.Passward = employee.Passward;
                //return RedirectToAction(registerpation(patient);
                patient.Enaple = "D";
                context.Patients.Add(patient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {

                //inital
                employee.DepId = 1;
                //employee.enaple ="d";
                employee.Enaple = "D";
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }





    }
}
