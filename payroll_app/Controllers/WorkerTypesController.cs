using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using payroll_app.Data;
using payroll_app.Models.repository;

namespace payroll_app.Controllers
{
    public class WorkerTypesController : Controller
    {
        private readonly payroll_app_context _context;

        public WorkerTypesController(payroll_app_context context)
        {
            _context = context;
        }

        // GET: WorkerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkerType.ToListAsync());
        }

        // GET: WorkerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerType = await _context.WorkerType
                .FirstOrDefaultAsync(m => m.WorkerTypeId == id);
            if (workerType == null)
            {
                return NotFound();
            }

            return View(workerType);
        }

        // GET: WorkerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkerTypeId,WorkerTypeName,WorkerTypeCode,ArrangeOrder")] WorkerType workerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workerType);
        }

        // GET: WorkerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerType = await _context.WorkerType.FindAsync(id);
            if (workerType == null)
            {
                return NotFound();
            }
            return View(workerType);
        }

        // POST: WorkerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkerTypeId,WorkerTypeName,WorkerTypeCode,ArrangeOrder")] WorkerType workerType)
        {
            if (id != workerType.WorkerTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerTypeExists(workerType.WorkerTypeId))
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
            return View(workerType);
        }

        // GET: WorkerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerType = await _context.WorkerType
                .FirstOrDefaultAsync(m => m.WorkerTypeId == id);
            if (workerType == null)
            {
                return NotFound();
            }

            return View(workerType);
        }

        // POST: WorkerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workerType = await _context.WorkerType.FindAsync(id);
            _context.WorkerType.Remove(workerType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerTypeExists(int id)
        {
            return _context.WorkerType.Any(e => e.WorkerTypeId == id);
        }
    }
}
