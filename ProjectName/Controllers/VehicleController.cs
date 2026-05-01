using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;

namespace ProjectName
{
    [Authorize]

    public class VehicleController : Controller
    {
        private static VehicleContext db = new VehicleContext();

        // GET: Vehiclecontroller
        public ActionResult Index()
        {
            return View(db.Vehicles.Where(Vehicle => Vehicle.UserID == User.Identity.Name));
        }

        // GET: Vehiclecontroller/Details/5
        [HttpGet("Vehicle/Details/{VIN}")]
        public ActionResult Details([FromRoute] string VIN)
        {
            return View(db.Vehicles.Where(Vehicle => Vehicle.UserID == User.Identity.Name).ToList().Find(x => x.VIN == VIN));
        }

        // GET: Vehiclecontroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiclecontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("VIN,ModelYear,Colour,Manufacturer,Model,PurchaseDate,SaleDate")] Vehicle Vehicle)
        {
            try
            {
                Vehicle.UserID = User.Identity.Name;
                db.Vehicles.Add(Vehicle);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiclecontroller/Edit/5
        [HttpGet("Vehicle/Edit/{VIN}")]
        public ActionResult Edit([FromRoute] string VIN)
        {
            try
            {
                return View(db.Vehicles.Where(Vehicle => Vehicle.UserID == User.Identity.Name).ToList().Find(x => x.VIN == VIN));
            }
            catch
            {
                return NotFound();
            }

        }

        // POST: Vehiclecontroller/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost("Vehicle/Edit/{VIN}")]
        public ActionResult Edit([FromRoute] string VIN, [Bind("VIN,ModelYear,Colour,Manufacturer,Model,PurchaseDate,SaleDate")] Vehicle Vehicle)
        {
            try
            {
                Vehicle target = db.Vehicles.Where(Vehicle => Vehicle.UserID == User.Identity.Name).ToList().Find(x => x.VIN == VIN);
                target.VIN = Vehicle.VIN;
                target.ModelYear = Vehicle.ModelYear;
                target.Colour = Vehicle.Colour;
                target.Manufacturer = Vehicle.Manufacturer;
                target.Model = Vehicle.Model;
                target.PurchaseDate = Vehicle.PurchaseDate;
                target.SaleDate = Vehicle.SaleDate;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        // GET: Vehiclecontroller/Delete/5\
        [HttpGet("Vehicle/Delete/{VIN}")]
        public ActionResult Delete([FromRoute] string VIN)
        {
            try
            {
                return View(db.Vehicles.Where(Vehicle => Vehicle.UserID == User.Identity.Name).ToList().Find(x => x.VIN == VIN));
            }
            catch
            {
                return NotFound();
            }

        }

        // POST: Vehiclecontroller/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost("Vehicle/Delete/{VIN}")]
        public ActionResult Delete([FromRoute] string VIN, IFormCollection collection)
        {
            try
            {
                Vehicle target = db.Vehicles.Where(Vehicle => Vehicle.UserID == User.Identity.Name).ToList().Find(x => x.VIN == VIN);
                db.Vehicles.Remove(target);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}