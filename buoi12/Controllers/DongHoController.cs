using buoi12.Data;
using buoi12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace buoi12.Controllers
{
    public class DongHoController : Controller
    {
        private readonly ShopDbContext _context;

        public DongHoController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: DongHo
        public async Task<IActionResult> Index(string? searchString)
        {
            var query = _context.DongHo
                .Include(d => d.ThuongHieu)
                .Include(d => d.LoaiMay)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(d =>
                    d.TenDH.Contains(searchString) ||
                    d.ThuongHieu!.TenTH.Contains(searchString));
            }

            ViewBag.SearchString = searchString;

            var danhSach = await query
                            .OrderByDescending(d => d.MaDH)
                            .ToListAsync();

            return View(danhSach);
        }

        // GET: DongHo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dongHo = await _context.DongHo
                            .Include(d => d.ThuongHieu)
                            .Include(d => d.LoaiMay)
                            .FirstOrDefaultAsync(d => d.MaDH == id);

            if (dongHo == null)
                return NotFound();

            return View(dongHo);
        }

        // GET: DongHo/Create
        public IActionResult Create()
        {
            LoadDanhMuc();
            return View();
        }

        // POST: DongHo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DongHo dongHo)
        {
            if (ModelState.IsValid)
            {
                dongHo.NgayTao = DateTime.Now;
                dongHo.TrangThai = 1;

                _context.DongHo.Add(dongHo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            LoadDanhMuc(dongHo);
            return View(dongHo);
        }

        // GET: DongHo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dongHo = await _context.DongHo.FindAsync(id);

            if (dongHo == null)
                return NotFound();

            LoadDanhMuc(dongHo);
            return View(dongHo);
        }

        // POST: DongHo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DongHo dongHo)
        {
            if (id != dongHo.MaDH)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dongHo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DongHoExists(dongHo.MaDH))
                        return NotFound();

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            LoadDanhMuc(dongHo);
            return View(dongHo);
        }

        // GET: DongHo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dongHo = await _context.DongHo
                            .Include(d => d.ThuongHieu)
                            .Include(d => d.LoaiMay)
                            .FirstOrDefaultAsync(d => d.MaDH == id);

            if (dongHo == null)
                return NotFound();

            return View(dongHo);
        }

        // POST: DongHo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dongHo = await _context.DongHo.FindAsync(id);

            if (dongHo != null)
            {
                _context.DongHo.Remove(dongHo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private void LoadDanhMuc(DongHo? dongHo = null)
        {
            ViewBag.MaTH = new SelectList(
                _context.ThuongHieu
                    .Where(t => t.TrangThai == 1)
                    .OrderBy(t => t.TenTH),
                "MaTH",
                "TenTH",
                dongHo?.MaTH);

            ViewBag.MaLM = new SelectList(
                            _context.LoaiMay
                                .Where(l => l.TrangThai == 1)
                                .OrderBy(l => l.TenLM),
                            "MaLM",
                            "TenLM",
                            dongHo?.MaLM);
        }

        private bool DongHoExists(int id)
        {
            return _context.DongHo.Any(d => d.MaDH == id);
        }
    }
}
