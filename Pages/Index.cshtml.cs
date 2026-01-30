using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DbApp_CRUD.Data;
using DbApp_CRUD.Models;

namespace DbApp_CRUD.Pages
{
    public class IndexModel(AppDbContext context) : PageModel
    {
        private readonly AppDbContext _context = context;

        [BindProperty]
        public Employee EmpObj { get; set; } = new();
        public List<Employee> EmployeeList { get; set; } = new();

        public async Task OnGetAsync()
        {
            EmployeeList = await _context.Employees.ToListAsync();
        }

        // INSERT & UPDATE (Edit) Logic
        public async Task<IActionResult> OnPostSaveAsync()
        {
            if (EmpObj.Id == 0) 
                _context.Employees.Add(EmpObj); // Insert new
            else 
                _context.Employees.Update(EmpObj); // Update existing

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // DELETE Logic
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}