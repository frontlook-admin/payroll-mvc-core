/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using _varimg=payroll_app.codeHelper.RandomImage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using payroll_app.Data;
using payroll_app.Models.repository;

namespace payroll_app.Controllers
{
    public class Employees1Controller : Controller
    {
        private readonly payroll_app_context _context;
        private readonly IHostingEnvironment _hosting_environment;

        public Employees1Controller(payroll_app_context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hosting_environment = hostingEnvironment;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var payroll_app_context = _context.Employee.Include(e => e.Department).Include(e => e.Grade).Include(e => e.WorkerType);
            //if (_context.Employee.Include(e => e.EmployeePhoto).Equals(null))
            //{
              //  _context.Employee.Include(e => e.EmployeePhoto).
            //}

            byte[] b = System.IO.File.ReadAllBytes(_varimg.userimgchooser(_hosting_environment.WebRootPath));
            foreach (var employee in payroll_app_context)
            {
                try
                {
                    var base64String = Convert.ToBase64String(employee.EmployeePhoto);
                }
                catch (Exception)
                {
                    employee.EmployeePhoto = System.IO.File.ReadAllBytes(_varimg.userimgchooser(_hosting_environment.WebRootPath,employee.Gender)); ;
                }
            }
            return View(await payroll_app_context.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Grade)
                .Include(e => e.WorkerType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            byte[] b = System.IO.File.ReadAllBytes(_varimg.userimgchooser(_hosting_environment.WebRootPath,employee.Gender));
            try
            {
                var base64String = Convert.ToBase64String(employee.EmployeePhoto);
            }
            catch (Exception)
            {
                employee.EmployeePhoto = b;
            }
            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            byte[] b = System.IO.File.ReadAllBytes(_varimg.userimgchooser(_hosting_environment.WebRootPath));
            ViewBag.photo = Convert.ToBase64String(b);
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentCode");
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeCode");
            ViewData["WorkerTypeId"] = new SelectList(_context.WorkerType, "WorkerTypeId", "WorkerTypeCode");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeePhoto,FirstName,MiddleName,LastName,FullName,Gender,PrimaryMobileNo,SecondaryMobileNo,AreaStdCode,PhoneNo,EmailId,Address1,Address2,Address3,City,District,Pin,PostOffice,PoliceStation,DepartmentId,GradeId,WorkerTypeId")] Employee employee, IFormFile EmployeePhoto)
        {
            var b = System.IO.File.ReadAllBytes(_varimg.randuserimgchooser(_hosting_environment.WebRootPath));
            byte[] c = null;
            if (EmployeePhoto != null)
            {
                if (EmployeePhoto.Length > 0)
                    //Convert Image to byte and save to database
                {
                    using (var ms1 = new MemoryStream())
                    {
                        await EmployeePhoto.CopyToAsync(ms1);
                        c = ms1.ToArray();
                        ViewBag.photo = Convert.ToBase64String(c);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                if (!c.Equals(null))
                {
                    employee.EmployeePhoto = c;
                }
                
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentCode", employee.DepartmentId);
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeCode", employee.GradeId);
            ViewData["WorkerTypeId"] = new SelectList(_context.WorkerType, "WorkerTypeId", "WorkerTypeCode", employee.WorkerTypeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var b = System.IO.File.ReadAllBytes(_varimg.userimgchooser(_hosting_environment.WebRootPath,employee.Gender));
            byte[] im = null;
            try
            {
                var base64String = Convert.ToBase64String(employee.EmployeePhoto);
                im = employee.EmployeePhoto;
            }
            catch (Exception)
            {
                im = b;
            }

            ViewBag.photo = im;
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentCode", employee.DepartmentId);
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeCode", employee.GradeId);
            ViewData["WorkerTypeId"] = new SelectList(_context.WorkerType, "WorkerTypeId", "WorkerTypeCode", employee.WorkerTypeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeePhoto,FirstName,MiddleName,LastName,FullName,Gender,PrimaryMobileNo,SecondaryMobileNo,AreaStdCode,PhoneNo,EmailId,Address1,Address2,Address3,City,District,Pin,PostOffice,PoliceStation,DepartmentId,GradeId,WorkerTypeId")] Employee employee,IFormFile EmployeePhoto)
        {
            byte[] img = null;
            if (EmployeePhoto != null)
            {
                if (EmployeePhoto.Length > 0)
                    //Convert Image to byte and save to database
                {
                    using (var ms1 = new MemoryStream())
                    {
                        await EmployeePhoto.CopyToAsync(ms1);
                        img = ms1.ToArray();
                        var b = System.IO.File.ReadAllBytes(_varimg.userimgchooser(_hosting_environment.WebRootPath,employee.Gender));
                        ViewBag.photo = b;
                    }
                }
            }
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employee.EmployeePhoto = img;
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentCode", employee.DepartmentId);
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeCode", employee.GradeId);
            ViewData["WorkerTypeId"] = new SelectList(_context.WorkerType, "WorkerTypeId", "WorkerTypeCode", employee.WorkerTypeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Grade)
                .Include(e => e.WorkerType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            var b = System.IO.File.ReadAllBytes(_varimg.userimgchooser(_hosting_environment.WebRootPath,employee.Gender));
            try
            {
                var base64String = Convert.ToBase64String(employee.EmployeePhoto);
            }
            catch (Exception)
            {
                employee.EmployeePhoto = b;
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
*/