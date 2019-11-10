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
    //Authorised Appointments Management controller.
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly Channel_A_Doctor_MVC_DatabaseContext _context;

        public AppointmentsController(Channel_A_Doctor_MVC_DatabaseContext context)
        {
            _context = context;
        }

        // GET: Appointments
        //Gets all applointments using a lamda query.
        public IActionResult Index()
        {
            var channel_A_Doctor_MVC_DatabaseContext = _context.Appointment.Include(a => a.Doctor).Include(a => a.Patient);
            return View( channel_A_Doctor_MVC_DatabaseContext.ToList());
        }

        // GET: Appointments/Details/5
        //Gets appointment details using a lamda query
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment =  _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefault(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        //Create appointment form 
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name");
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds an appointment to database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,DoctorId,PatientId,AppointmentDate")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5

       //Get the appointment update form. Uses a lamda query to get the appointment.
       
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = (from appintmnents in _context.Appointment
                               where appintmnents.Id == id
                               select appintmnents).FirstOrDefault();
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Name", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Name", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the appointment.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,DoctorId,PatientId,AppointmentDate")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Id", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id", appointment.PatientId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        //Gets  the appointment to delete. uses lamda query to display the appointment.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment =  _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefault(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        //Removes the appointment. Uses linq query to get the appointment.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var appointment = (from appintmnents in _context.Appointment
                               where appintmnents.Id == id
                               select appintmnents).FirstOrDefault();
            _context.Appointment.Remove(appointment);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the appointment record.
        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
