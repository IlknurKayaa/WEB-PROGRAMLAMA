using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MakaleController : Controller
    {
        MakaleContext _context=new MakaleContext();
        public async Task<IActionResult> Index()
        {
            var makaleContext = _context.makales.Include(m => m.Kullanici);
            return View(await makaleContext.ToListAsync());
        }

        // GET: Makales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.makales == null)
            {
                return NotFound();
            }

            var makale = await _context.makales
                .Include(m => m.Kullanici)
                .FirstOrDefaultAsync(m => m.MakaleId == id);
            if (makale == null)
            {
                return NotFound();
            }

            return View(makale);
        }

        // GET: Makales/Create
        [HttpGet]
        public IActionResult Create()
        {

            ViewData["KullaniciID"] = new SelectList(_context.kullanicis, "KullaniciID", "KullaniciAd");
            return View();
        }

        // POST: Makales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Makale makale)
        {
            
                _context.Add(makale);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
        
        }

        // GET: Makales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.makales == null)
            {
                return NotFound();
            }

            var makale = await _context.makales.FindAsync(id);
            if (makale == null)
            {
                return NotFound();
            }
            ViewData["KullaniciID"] = new SelectList(_context.kullanicis, "KullaniciID", "KullaniciAd", makale.KullaniciID);
            return View(makale);
        }

        // POST: Makales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MakaleId,MakaleAd,KullaniciID")] Makale makale)
        {
            if (id != makale.MakaleId)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(makale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakaleExists(makale.MakaleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            //ViewData["KullaniciID"] = new SelectList(_context.kullanicis, "KullaniciID", "KullaniciAd", makale.KullaniciID);
            //return View(makale);
        }

        // GET: Makales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.makales == null)
            {
                return NotFound();
            }

            var makale = await _context.makales
                .Include(m => m.Kullanici)
                .FirstOrDefaultAsync(m => m.MakaleId == id);
            if (makale == null)
            {
                return NotFound();
            }

            return View(makale);
        }

        // POST: Makales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.makales == null)
            {
                return Problem("Entity set 'MakaleContext.makales'  is null.");
            }
            var makale = await _context.makales.FindAsync(id);
            if (makale != null)
            {
                _context.makales.Remove(makale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakaleExists(int id)
        {
            return _context.makales.Any(e => e.MakaleId == id);
        }
    }
}
