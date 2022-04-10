using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarMaintainer.Data;
using CarMaintainer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarMaintainer.Utility;

namespace CarMaintainer.Controllers
{
    [Authorize(Roles = StaticDetails.AdminEndUser)]
    public class ServiceTypesController : Controller
    {
        //database object
        private readonly ApplicationDbContext _db;

        public ServiceTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get : ServiceTypes
        public IActionResult Index()
        {
            return View(_db.ServiceTypes.ToList());
            //retrieve everything from database wich exists in the ServiceTypes convert them to list and return them to the view
        }
        //index action method
        //Get: ServiceTypes/create
        public IActionResult Create()
        {
            return View();
        }

        //post: services/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                _db.Add(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

        //Edit : serviceTypes/Edit/1
        //Edit method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceType serviceType)
        {
            //if the id not matches service type return not found (nothing found)
            if (id != serviceType.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(serviceType);
                await _db.SaveChangesAsync();
                //redirect to index if valid
                return RedirectToAction(nameof(Index));
            }
            //if model state is not valid return to view
            return View(serviceType);
        }

        //Details : serviceTypes/Details/1
        //Details method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //check from database
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }

        //Delete : serviceTypes/Delete/1
        //Delete method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();
            }
            return View(serviceType);
        }

        [HttpPost, ActionName("Delete")]//name this action as delete in order to use it later
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveServiceType(int id)
        {
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            _db.ServiceTypes.Remove(serviceType);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}