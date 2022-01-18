﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Areas.admin.Controllers
{
    [Area("admin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Settings.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Setting model)
        {
            if (ModelState.IsValid)
            {
                _context.Settings.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "nuldur ha!");
                return View(model);
            }
            
        }



        public IActionResult Update(int id)
        {
            return View(_context.Settings.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Setting model)
        {
            if (ModelState.IsValid)
            {
                _context.Settings.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
               
                return View(model);
            }

        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Setting setting = _context.Settings.Find(id);
            if (setting == null)
            {
                return NotFound();
            }

            _context.Settings.Remove(setting);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
