using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace Hospital.Controllers
{
    public class PatientController : Controller
    {

        HospitallContext context;
      static  int idd;
        public PatientController(HospitallContext context)             {
            this.context = context;

       }

         public IActionResult Index()
        {
            return View();
        }

        public IActionResult Patient(int id)
        {
            //var a = context.Patients.Where(p => p.PatId == id).ToList();  
           idd = id;
            var a = context.Patients.Where(p => p.PatId == id).ToList();

            return View(a);
        }



        public IActionResult viewrecord_topa()
        {
            var rec = context.Records.Where(op => op.PatId == idd).ToList();
            return View(rec);
        }
        public IActionResult ret()
        {
            return RedirectToAction("Patient", new { id = idd });

        }


        public IActionResult viewappo()
        {
            var appo = context.Appointments.Where(op => op.PatId == idd).ToList();
            return View(appo);
        }

        public IActionResult Editapp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Editapp(DateOnly date,int id)
        {
            var a = context.Appointments.Where(op => op.PatId == idd).FirstOrDefault();

            //var a = context.Appointments.Where(op => op.AppId == id).FirstOrDefault();
            a.Date = date;
            context.SaveChanges();
            return RedirectToAction("Patient", new { id = idd });


        }


        public IActionResult Deleteapp(int id)
        {
            var a = context.Appointments.Where(op => op.PatId == idd).FirstOrDefault();

            //var a = context.Appointments.Where(op => op.AppId == id).FirstOrDefault();
            context.Appointments.Remove(a);
            context.SaveChanges();
            return RedirectToAction("Patient", new { id = idd });


        }




        public IActionResult Communicate()
        {
            return View();
        }


    }
}
