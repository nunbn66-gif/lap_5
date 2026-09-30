
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NsbmLesson12.Models;
using NsbmLesson12.Data;
namespace NsbmLesson12.Controllers
{
    public class NsbmCategorieController : Controller
    {
        private readonly NsbmAppDbContext _context;

        public NsbmCategorieController(NsbmAppDbContext context)
        {
            _context = context;
        }

        // GET: NSBMCATEGORYS
        public async Task<IActionResult> Index()
        {
            return View(await _context.NsbmCategories.ToListAsync());
        }

        // GET: NSBMCATEGORYS/Details/5
        public async Task<IActionResult> Details(int? nsbmid)
        {
            if (nsbmid == null)
            {
                return NotFound();
            }

            var nsbmcategory = await _context.NsbmCategories
                .FirstOrDefaultAsync(m => m.NsbmId == nsbmid);
            if (nsbmcategory == null)
            {
                return NotFound();
            }

            return View(nsbmcategory);
        }

        // GET: NSBMCATEGORYS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NSBMCATEGORYS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NsbmId,Nsbmname,NsbmCreatedDate,NsbmProducts")] NsbmCategory nsbmcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nsbmcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nsbmcategory);
        }

        // GET: NSBMCATEGORYS/Edit/5
        public async Task<IActionResult> Edit(int? nsbmid)
        {
            if (nsbmid == null)
            {
                return NotFound();
            }

            var nsbmcategory = await _context.NsbmCategories.FindAsync(nsbmid);
            if (nsbmcategory == null)
            {
                return NotFound();
            }
            return View(nsbmcategory);
        }

        // POST: NSBMCATEGORYS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? nsbmid, [Bind("NsbmId,Nsbmname,NsbmCreatedDate,NsbmProducts")] NsbmCategory nsbmcategory)
        {
            if (nsbmid != nsbmcategory.NsbmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nsbmcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NsbmCategoryExists(nsbmcategory.NsbmId))
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
            return View(nsbmcategory);
        }

        // GET: NSBMCATEGORYS/Delete/5
        public async Task<IActionResult> Delete(int? nsbmid)
        {
            if (nsbmid == null)
            {
                return NotFound();
            }

            var nsbmcategory = await _context.NsbmCategories
                .FirstOrDefaultAsync(m => m.NsbmId == nsbmid);
            if (nsbmcategory == null)
            {
                return NotFound();
            }

            return View(nsbmcategory);
        }

        // POST: NSBMCATEGORYS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? nsbmid)
        {
            var nsbmcategory = await _context.NsbmCategories.FindAsync(nsbmid);
            if (nsbmcategory != null)
            {
                _context.NsbmCategories.Remove(nsbmcategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NsbmCategoryExists(int? nsbmid)
        {
            return _context.NsbmCategories.Any(e => e.NsbmId == nsbmid);
        }
    }
}