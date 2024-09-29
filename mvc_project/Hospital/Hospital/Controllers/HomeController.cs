using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
     readonly  HospitallContext context;
        public HomeController(HospitallContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(visitor));
        }

        public IActionResult visitor()
        {
            return View();
        }



        public IActionResult Appointment()
        {
            ViewBag.doctorr = context.Employees.Where(op => op.JopType == "Doctor").ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Appointment([Bind("Date")] Appointment appointment,string email, string pass,DateOnly day,DateOnly Houer,string namedoc)
        {
            var pat = context.Patients.Where(p => p.Email == email && p.Passward == pass).FirstOrDefault();
            if(pat != null)
            {

                var doc = context.Employees.Where(op => op.Fname == namedoc).FirstOrDefault();

                //to view appointment in doctor page
                appointment.Iddoctor = doc.EmpId;


                //id appointment same pation id
                appointment.PatId = pat.PatId;
                context.Appointments.Add(appointment);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
          
            return Redirect(nameof(notfaound));
        }


        public IActionResult notfaound()
        {
            return View();
        }
    }
}
