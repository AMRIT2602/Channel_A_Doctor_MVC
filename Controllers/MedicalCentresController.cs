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
    //Authorized Medicat center mamanegement.
    [Authorize]
    public class MedicalCentresController : Controller
    {
        private readonly Channel_A_Doctor_MVC_DatabaseContext _context;

        public MedicalCentresController(Channel_A_Doctor_MVC_DatabaseContext context)
        {
            _context = context;
        }

        // GET: MedicalCentres
        //Get All medical center information using a linq query.
        public IActionResult Index()
        {
            return View( (from medical in _context.MedicalCentre select medical).ToList());
        }

        // GET: MedicalCentres/Details/5
        //Get the medical centre details. using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalCentre = _context.MedicalCentre
                .FirstOrDefault(m => m.Id == id);
            if (medicalCentre == null)
            {
                return NotFound();
            }

            return View(medicalCentre);
        }

        // GET: MedicalCentres/Create
        //Gets medical centre create form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalCentres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates a medical centre.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Phone")] MedicalCentre medicalCentre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalCentre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalCentre);
        }

        // GET: MedicalCentres/Edit/5
        //Gets Medical centre edit form uses a linq query to get the information.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalCentre = (from medical in _context.MedicalCentre
                                 where medical.Id == id
                                 select medical).FirstOrDefault();
            if (medicalCentre == null)
            {
                return NotFound();
            }
            return View(medicalCentre);
        }

        // POST: MedicalCentres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the medical centre info.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Phone")] MedicalCentre medicalCentre)
        {
            if (id != medicalCentre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalCentre);
                   _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalCentreExists(medicalCentre.Id))
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
            return View(medicalCentre);
        }

        // GET: MedicalCentres/Delete/5
        //Gets medical centre for delete uses a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalCentre =  _context.MedicalCentre
                .FirstOrDefault(m => m.Id == id);
            if (medicalCentre == null)
            {
                return NotFound();
            }

            return View(medicalCentre);
        }

        // POST: MedicalCentres/Delete/5
        //Deletes the medical centre Uses a lamda query to get the medical centre details.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var medicalCentre = (from medical in _context.MedicalCentre
                                 where medical.Id == id
                                 select medical).FirstOrDefault();
            _context.MedicalCentre.Remove(medicalCentre);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Check medical centre using lamda query.
        private bool MedicalCentreExists(int id)
        {
            return _context.MedicalCentre.Any(e => e.Id == id);
        }
    }
}
