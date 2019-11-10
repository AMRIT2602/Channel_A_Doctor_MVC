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
    //Authorized Doctor record management
    [Authorize]
    public class DoctorsController : Controller
    {
        private readonly Channel_A_Doctor_MVC_DatabaseContext _context;

        public DoctorsController(Channel_A_Doctor_MVC_DatabaseContext context)
        {
            _context = context;
        }

        // GET: Doctors
        //Gets all the doctors using a lamda query.
        public IActionResult Index()
        {
            var channel_A_Doctor_MVC_DatabaseContext = _context.Doctor.Include(d => d.MedicalCentre);
            return View( channel_A_Doctor_MVC_DatabaseContext.ToList());
        }

        // GET: Doctors/Details/5
        //Gets doctor  details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor =  _context.Doctor
                .Include(d => d.MedicalCentre)
                .FirstOrDefault(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        //Gets Cretae doctor form.
        public IActionResult Create()
        {
            ViewData["MedicalCentreId"] = new SelectList(_context.MedicalCentre, "Id", "Name");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates a Doctor.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Charge,MedicalCentreId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicalCentreId"] = new SelectList(_context.MedicalCentre, "Id", "Name", doctor.MedicalCentreId);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        //Gets doctor for update. Uses a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = (from doctors in _context.Doctor
                          where doctors.Id == id
                          select doctors).FirstOrDefault();
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["MedicalCentreId"] = new SelectList(_context.MedicalCentre, "Id", "Name", doctor.MedicalCentreId);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Update the doctor 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Charge,MedicalCentreId")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            ViewData["MedicalCentreId"] = new SelectList(_context.MedicalCentre, "Id", "Name", doctor.MedicalCentreId);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        //Gets the doctor for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor =  _context.Doctor
                .Include(d => d.MedicalCentre)
                .FirstOrDefault(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        //Deletes a doctor.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doctor = (from doctors in _context.Doctor
                          where doctors.Id == id
                          select doctors).FirstOrDefault();
            _context.Doctor.Remove(doctor);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the doctor exists using a lamda query.
        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.Id == id);
        }
    }
}
