using Microsoft.AspNetCore.Mvc;
using WorkplaceMG.Models.DTOs;
using WorkplaceMG.Services.IServices;

namespace WorkplaceMG.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var result = _employeeService.GetAllEmployees();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employee);
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employee = _employeeService.GetEmployeeById((int)id);
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                TempData["success"] = "Employee edited successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
