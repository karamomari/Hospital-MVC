using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NuGet.Packaging.Signing;
using System.IO;

namespace Hospital.Controllers
{
  //  other Administrator Nurse Receptionist  Patient Doctor 
    public class EmployeeController : Controller
    {
         static int id_doctor,Id_Res;
        static int id_nurse;
         IWebHostEnvironment env;
         HospitallContext context;
        public EmployeeController(HospitallContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Administrator(int id)
        {
          
            return RedirectToAction("Index", "Administrator");
        }
        //Doctor
        public IActionResult Doctorr()
        {
            return RedirectToAction("Doctor", "Employee", new { id = id_doctor });      
        }
        public IActionResult Doctor(int id)
        {
            id_doctor = id;
            ViewBag.Id = id;
            var doctor=context.Employees.Where(op=> op.EmpId==id).ToList();
            //var text= context.Employees.Where(op => op.EmpId == 7).ToList();
            return View(doctor);
        }
        [HttpPost]
        public IActionResult viewrecord(string Lname,string Fname)
        {
            var p = context.Patients.Where(op => op.Fname == Fname && op.Lname == Lname).FirstOrDefault();
            int id = p.PatId;
            var rec = context.Records.Where(op => op.PatId == id).ToList();
            return View(rec);
        }

        public IActionResult updatetreatment(int? id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult updatetreatment(IFormFile ImageFile, int id)
        {
            var recd = context.Records.Where(op => op.PatId == id).FirstOrDefault();
            string wwwRoot = env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
            string path = Path.Combine(wwwRoot + "/imge_treatment_plans", fileName);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                ImageFile.CopyTo(fileStream);
            }

            recd.TreatmentPlans = fileName;
        
            context.Records.Update(recd);
            context.SaveChangesAsync();
            return View();
        }

        [HttpPost]
        public IActionResult viewrecorviewapp(DateOnly date)
        {
         
            var app = context.Appointments.Where(op => op.Iddoctor == id_doctor).Where(l=>l.Date==date).ToList();
            ViewBag.app = app;
            return View(app);
            
        }
        [HttpPost]
         public IActionResult Deleteappointment(int id)
        {
            var appo = context.Appointments.Where(op => op.AppId == id).FirstOrDefault();
            context.Appointments.Remove(appo);
            context.SaveChanges();
            return RedirectToAction(nameof(viewrecorviewapp));
        }

        public IActionResult Editappointment(int? id)
        {
            return View();
        }

       [HttpPost]
        public IActionResult Editappointment(int id,DateOnly date)
        {

            //var a = context.Patients.Where(op => op.PatId == appointment.PatId).FirstOrDefault();
            var a=context.Appointments.Where(op=>op.AppId==id).FirstOrDefault();
            a.Date = date;
            context.Update(a);
            context.SaveChanges();
            return RedirectToAction("Doctor", new { id= id_doctor });
        }







		public IActionResult Nurse(int id)
		{
            id_nurse = id;
            var Nurse = context.Employees.Where(op => op.EmpId == id).ToList();
			return View(Nurse);
		}

        public IActionResult NUpdaterecord(string Fname,string Lname)
        {
            var Patient=context.Patients.Where(op => op.Fname==Fname&&op.Lname==Lname).FirstOrDefault();
            int id = Patient.PatId;
            var rec = context.Records.Where(op => op.PatId == id).FirstOrDefault();
            return RedirectToAction("addrec", rec);

        }
        public IActionResult addrec(Record rec)
        {
            return View(rec);
        }
        public IActionResult saveupdat(int id, string pv, string me, string tr)
        {
            var s = id;
            var record = context.Records.Where(op => op.Rid== s).FirstOrDefault();
            record.TreatmentPlans = tr;
            record.Medications = me;
            record.PatientMedical = pv;
            context.Records.Update(record);
            context.SaveChanges();
            return RedirectToAction("Nurse", new { id = id_nurse });
        }
        public IActionResult Receptionist(int id) 
        {
            Id_Res = id;
            var R = context.Employees.Where(op => op.EmpId == id).ToList();
            return View(R);
        }
        public IActionResult AddPP() 
        {
            return View("AddPat");
        }
        public IActionResult AddPat(int id, string Fname, string Lname , string Email,string Password)
        {
            var P=new Patient();
            P.Fname = Fname;
            P.Lname = Lname;
            P.Email = Email;
            P.Passward = Password;
            context.Patients.Add(P);
            context.SaveChanges();
            return RedirectToAction("Receptionist", new { id = Id_Res});
        }
    }
}
