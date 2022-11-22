using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly qlnhanvienContext _context = new qlnhanvienContext(); 

        public HomeController(ILogger<HomeController> logger )
        {
            
            _logger = logger;
           
        }

        public async Task<IActionResult> Index()
        {
            
            var a = await _context.Nhanviens.ToListAsync();
            Console.WriteLine(a);
            return View(a);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }
            var nv = await _context.Nhanviens.FindAsync(id);
            if (nv == null)
            {
                return NotFound();
            }
            return View(nv);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Address")] Nhanvien nhanvien)
        {
            if (id != nhanvien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nhanvien);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FirstOrDefaultAsync(m => m.Id == id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Address")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nhanviens == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Nhanviens == null)
            {
                return Problem("Entity set 'qlnhanvienContext.Nhanviens'  is null.");
            }
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien != null)
            {
                _context.Nhanviens.Remove(nhanvien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}