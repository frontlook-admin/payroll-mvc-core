using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using _varimg = payroll_app.codeHelper.RandomImage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using payroll_app.Data;
using payroll_app.Models.repository;

namespace payroll_app.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly payroll_app_context _context;
        private readonly IHostingEnvironment _hosting_environment;

        public EmployeesController(payroll_app_context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hosting_environment = hostingEnvironment;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var payroll_app_context = _context.Employee.Include(e => e.Categories).Include(e => e.Departments).Include(e => e.Designations).Include(e => e.Grades).Include(e => e.Shifts);

            var b = System.IO.File.ReadAllBytes(_varimg.Userimgchooser(_hosting_environment.WebRootPath));
            foreach (var employee in payroll_app_context)
            {
                try
                {
                    var base64String = Convert.ToBase64String(employee.EmployeePhoto);
                }
                catch (Exception)
                {
                    employee.EmployeePhoto = System.IO.File.ReadAllBytes(_varimg.Userimgchooser(_hosting_environment.WebRootPath, employee.Gender)); ;
                }
            }

            return View(await payroll_app_context.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Categories)
                .Include(e => e.Departments)
                .Include(e => e.Designations)
                .Include(e => e.Grades)
                .Include(e => e.Shifts)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            var b = System.IO.File.ReadAllBytes(_varimg.Userimgchooser(_hosting_environment.WebRootPath, employee.Gender));
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

        private byte[] Picshow(IFormFile EmployeePhoto = null)
        {
            byte[] c = null;
            if (EmployeePhoto != null)
            {
                if (EmployeePhoto.Length > 0)
                    //Convert Image to byte and save to database
                {
                    using (var ms1 = new MemoryStream())
                    {
                        EmployeePhoto.CopyToAsync(ms1);
                        c = ms1.ToArray();
                    }
                }
            }
            else
            {
                c = System.IO.File.ReadAllBytes(_varimg.Randuserimgchooser(_hosting_environment.WebRootPath));
            }
            
            return c;
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            
            //var b = System.IO.File.ReadAllBytes(_varimg.Userimgchooser(_hosting_environment.WebRootPath));
            //ViewBag.photo = Convert.ToBase64String(b);
            ViewBag.photo = Convert.ToBase64String(Picshow());
            ViewData["Category"] = new SelectList(_context.Category, "CategoryId", "CategoryCode");
            ViewData["Department"] = new SelectList(_context.Department, "DepartmentId", "DepartmentCode");
            ViewData["Designation"] = new SelectList(_context.Designations, "DesignationId", "DesignationCode");
            ViewData["Grade"] = new SelectList(_context.Grade, "GradeId", "GradeCode");
            ViewData["Shift"] = new SelectList(_context.Shift, "ShiftId", "ShiftCode");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeePhoto,AdultRegistrationNo,EmployeeCode,PfNo,EmployeeName,FatherOrHusbandName,DateOfBirth,Gender,PermanentAddress,CurrentAddress,Nominee,MobileNo,EmailId,PanNo,AadharNo,Department,Designation,Grade,Category,Shift,OffDay,JoinDate,LastWorkingDate,Active")] Employee employee, IFormFile EmployeePhoto = null)
        {

            //var b = System.IO.File.ReadAllBytes(_varimg.Randuserimgchooser(_hosting_environment.WebRootPath));
            //byte[] c = Picshow(EmployeePhoto);

            if (ModelState.IsValid)
            {
                if (EmployeePhoto != null)
                {
                    employee.EmployeePhoto = Picshow(EmployeePhoto);
                }
                else
                {
                    employee.EmployeePhoto = null;
                }

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["Category"] = new SelectList(_context.Category, "CategoryId", "CategoryCode", employee.Category);
            ViewData["Department"] = new SelectList(_context.Department, "DepartmentId", "DepartmentCode", employee.Department);
            ViewData["Designation"] = new SelectList(_context.Designations, "DesignationId", "DesignationCode", employee.Designation);
            ViewData["Grade"] = new SelectList(_context.Grade, "GradeId", "GradeCode", employee.Grade);
            ViewData["Shift"] = new SelectList(_context.Shift, "ShiftId", "ShiftCode", employee.Shift);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
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

            var b = System.IO.File.ReadAllBytes(_varimg.Userimgchooser(_hosting_environment.WebRootPath, employee.Gender));
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

            ViewBag.photo = Convert.ToBase64String(im);

            ViewData["Category"] = new SelectList(_context.Category, "CategoryId", "CategoryCode", employee.Category);
            ViewData["Department"] = new SelectList(_context.Department, "DepartmentId", "DepartmentCode", employee.Department);
            ViewData["Designation"] = new SelectList(_context.Designations, "DesignationId", "DesignationCode", employee.Designation);
            ViewData["Grade"] = new SelectList(_context.Grade, "GradeId", "GradeCode", employee.Grade);
            ViewData["Shift"] = new SelectList(_context.Shift, "ShiftId", "ShiftCode", employee.Shift);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeId,EmployeePhoto,AdultRegistrationNo,EmployeeCode,PfNo,EmployeeName,FatherOrHusbandName,DateOfBirth,Gender,PermanentAddress,CurrentAddress,Nominee,MobileNo,EmailId,PanNo,AadharNo,Department,Designation,Grade,Category,Shift,OffDay,JoinDate,LastWorkingDate,Active")] Employee employee, IFormFile EmployeePhoto)
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
                        var b = System.IO.File.ReadAllBytes(_varimg.Userimgchooser(_hosting_environment.WebRootPath, employee.Gender));
                        ViewBag.photo = b;
                    }
                }
            }
            if (id != employee.EmployeeId)
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
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["Category"] = new SelectList(_context.Category, "CategoryId", "CategoryCode", employee.Category);
            ViewData["Department"] = new SelectList(_context.Department, "DepartmentId", "DepartmentCode", employee.Department);
            ViewData["Designation"] = new SelectList(_context.Designations, "DesignationId", "DesignationCode", employee.Designation);
            ViewData["Grade"] = new SelectList(_context.Grade, "GradeId", "GradeCode", employee.Grade);
            ViewData["Shift"] = new SelectList(_context.Shift, "ShiftId", "ShiftCode", employee.Shift);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Categories)
                .Include(e => e.Departments)
                .Include(e => e.Designations)
                .Include(e => e.Grades)
                .Include(e => e.Shifts)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            var b = System.IO.File.ReadAllBytes(_varimg.Userimgchooser(_hosting_environment.WebRootPath, employee.Gender));
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
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
