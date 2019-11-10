using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Channel_A_Doctor.BusinessLayer;
using Channel_A_Doctor_MVC_App.Models;
using Microsoft.AspNetCore.Authorization;

namespace Channel_A_Doctor_MVC_App.Controllers
{
    //Authorized patientns management.
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly Channel_A_Doctor_MVC_DatabaseContext _context;

        public PatientsController(Channel_A_Doctor_MVC_DatabaseContext context)
        {
            _context = context;
        }

        // GET: Patients
        //Gets all patients records using a linq query
        public IActionResult Index()
        {
            return View((from patient in _context.Patient select patient).ToList());
        }

        // GET: Patients/Details/5
        //Get  patient details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _context.Patient
                .FirstOrDefault(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        //Get create patient form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Creates the patient .
        public IActionResult Create([Bind("Id,Name,IDNumber,Phone")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
               _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        //Gets the patient records to edit . Uses a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = (from patients in _context.Patient
                           where patients.Id == id
                           select patients).FirstOrDefault();
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the patient.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,IDNumber,Phone")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        //Gets patient details for delete.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _context.Patient
                .FirstOrDefault(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        //Delete the patient details uses a linq query to get the pateint.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient = (from patients in _context.Patient
                           where patients.Id == id
                           select patients).FirstOrDefault();
            _context.Patient.Remove(patient);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the patent existance.
        private bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.Id == id);
        }
    }
}
