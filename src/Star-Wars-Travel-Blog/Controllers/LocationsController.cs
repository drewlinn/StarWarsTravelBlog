﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWarsTravelBlog.Models;
using Microsoft.EntityFrameworkCore;


namespace StarWarsTravelBlog.Controllers
{
    public class LocationsController : Controller
    {
        private StarWarsTravelBlogContext db = new StarWarsTravelBlogContext();
        public IActionResult Index()
        {
            return View(db.Locations.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(locations => locations.id == id);
            return View(thisLocation);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(locations => locations.id == id);
            return View(thisLocation);
        }

        [HttpPost]
        public IActionResult Edit(Location location)
        {
            db.Entry(location).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(locations => locations.id == id);
            return View(thisLocation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(locations => locations.id == id);
            db.Locations.Remove(thisLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
