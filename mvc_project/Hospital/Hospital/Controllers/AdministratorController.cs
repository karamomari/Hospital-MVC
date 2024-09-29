using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
	public class AdministratorController : Controller
	{
		HospitallContext context;
		public AdministratorController(HospitallContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			return View();
		}


        //to list Patient accounts latest
        public IActionResult Patientt()
		{
			var pat = context.Patients.Where(op => op.Enaple == "d").ToList();
			return View(pat);
		}

		public IActionResult consentpat(int id)
		{
			var consen = context.Patients.Where(op => op.PatId == id).FirstOrDefault();
			consen.Enaple = "E";
        
            context.SaveChanges();
            /*

             methoed to sent massege to Patient
             */

            return RedirectToAction(nameof(Patientt));
		}

        public IActionResult rejectpat(int id)
        {
            var consen = context.Patients.Where(op => op.PatId == id).FirstOrDefault();
			context.Patients.Remove(consen);
            context.SaveChanges();
            /*

             methoed to sent massege to Patient
             */

            return RedirectToAction(nameof(Patientt));
        }






        //_________________________________________________



        //to list Patient accounts latest
        public IActionResult employee()
        {
            var emp = context.Employees.Where(op => op.Enaple == "d").ToList();
            return View(emp);
        }


        public IActionResult consentempl(int id)
        {
            var consen = context.Employees.Where(op => op.EmpId == id).FirstOrDefault();
            consen.Enaple = "E";
            context.SaveChanges();
            /*

             methoed to sent massege to Patient
             */

            return RedirectToAction(nameof(employee));
        }


        public IActionResult rejectempl(int id)
        {
            var consen = context.Employees.Where(op => op.EmpId == id).FirstOrDefault();
            context.Employees.Remove(consen);
            context.SaveChanges();
            /*

             methoed to sent massege to Patient
             */

            return RedirectToAction(nameof(employee));
        }


        public IActionResult Editdepart()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Editdepart(int id,int DepId,string ShiftWork,float Salary)
        {
            var emoll=context.Employees.Where(op=>op.EmpId == id).FirstOrDefault();
            emoll.DepId = DepId;
            emoll.ShiftWork = ShiftWork;
            emoll.Salary = Salary;
            context.SaveChanges();
            return RedirectToAction(nameof(employee));
         
        }





        public IActionResult Report()
        { 
            var employees = context.Employees.ToList();

            var departments = context.Departments.ToList();
            var joinTables = from e in employees
                             join d in departments
                             on e.EmpId equals d.DepId                         
                             select new employeesdepartmentsjoin {employee  = e, department = d };

            var employeesMode = context.Employees.Include("Dep").ToList();

            ViewBag.emplo = context.Employees.Count();

            var tuple = Tuple.Create<IEnumerable<employeesdepartmentsjoin>, IEnumerable<Employee>>(joinTables, employeesMode);
            return View(tuple);

        }





        public IActionResult SearchEmp()
        {

            return View();
        }


        [HttpPost]
        public IActionResult SearchEmpp(string JopType,string Fname,string Lname)
        {
            var emp = context.Employees.Where(op => op.JopType == JopType && op.Fname==Fname && op.Lname==Lname).ToList();
            return View(emp);
        }





        public IActionResult Searchpat()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Searchpatt(string Fname, string Lname)
        {
            var pat = context.Patients.Where(op=> op.Fname == Fname && op.Lname == Lname).ToList();
            return View(pat);
        }




    }
}
