﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteWarehouse.Data;
using GraniteWarehouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraniteWarehouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagsController : Controller
    {
        public readonly ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.Add(specialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _db.SpecialTags.FindAsync(id);
            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialTags specialTags)
        {
            if (id != specialTags.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(specialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialTags);
        }

        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _db.SpecialTags.FindAsync(id);
            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialTags = await _db.SpecialTags.FindAsync(id);
            if (specialTags == null)
            {
                return NotFound();
            }

            return View(specialTags);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialTags = await _db.SpecialTags.FindAsync(id);
            _db.SpecialTags.Remove(specialTags);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}