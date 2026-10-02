
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NsbmLesson12.Models;
using NsbmLesson12.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

public class NsbmProductController : Controller
{
    private readonly NsbmAppDbContext _context;

    public NsbmProductController(NsbmAppDbContext context)
    {
        _context = context;
    }

    // GET: NSBMPRODUCTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.NsbmProduct.ToListAsync());
    }

    // GET: NSBMPRODUCTS/Details/5
    public async Task<IActionResult> Details(int? nsbmid)
    {
        if (nsbmid == null)
        {
            return NotFound();
        }

        var nsbmproduct = await _context.NsbmProduct
            .FirstOrDefaultAsync(m => m.NsbmId == nsbmid);
        if (nsbmproduct == null)
        {
            return NotFound();
        }

        return View(nsbmproduct);
    }

    // GET: NSBMPRODUCTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NSBMPRODUCTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NsbmId,NsbmName,NsbmImage,NsbmPrice,NsbmsalePrice,NsbmStatus,Descriptions,NsbmCategoryId,NsbmCreatedDate,NsbmCategory")] NsbmProduct nsbmproduct)
    {
        if (ModelState.IsValid)
        {
            
            var files = HttpContext.Request.Form.Files;
            //files[0] là file đầu tiên được upload lên
            //length là kích thước của file, nếu > 0 thì có nghĩa là có file được upload lên
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var FileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    nsbmproduct.NsbmImage = FileName;
                }
            }
            _context.Add(nsbmproduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
         ViewData["NsbmCategoryId"] = new SelectList(_context.NsbmCategories, "NsbmCategoryId", "NsbmCategoryName", nsbmproduct.NsbmCategoryId);
        return View(nsbmproduct);
    }

    // GET: NSBMPRODUCTS/Edit/5
    public async Task<IActionResult> Edit(int? nsbmid)
    {
        if (nsbmid == null)
        {
            return NotFound();
        }

        var nsbmproduct = await _context.NsbmProduct.FindAsync(nsbmid);
        if (nsbmproduct == null)
        {
            return NotFound();
        }
        return View(nsbmproduct);
    }

    // POST: NSBMPRODUCTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? nsbmid, [Bind("NsbmId,NsbmName,NsbmImage,NsbmPrice,NsbmsalePrice,NsbmStatus,Descriptions,NsbmCategoryId,NsbmCreatedDate,NsbmCategory")] NsbmProduct nsbmproduct)
    {
        if (nsbmid != nsbmproduct.NsbmId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(nsbmproduct);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NsbmProductExists(nsbmproduct.NsbmId))
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
        return View(nsbmproduct);
    }

    // GET: NSBMPRODUCTS/Delete/5
    public async Task<IActionResult> Delete(int? nsbmid)
    {
        if (nsbmid == null)
        {
            return NotFound();
        }

        var nsbmproduct = await _context.NsbmProduct
            .FirstOrDefaultAsync(m => m.NsbmId == nsbmid);
        if (nsbmproduct == null)
        {
            return NotFound();
        }

        return View(nsbmproduct);
    }

    // POST: NSBMPRODUCTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? nsbmid)
    {
        var nsbmproduct = await _context.NsbmProduct.FindAsync(nsbmid);
        if (nsbmproduct != null)
        {
            _context.NsbmProduct.Remove(nsbmproduct);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NsbmProductExists(int? nsbmid)
    {
        return _context.NsbmProduct.Any(e => e.NsbmId == nsbmid);
    }
}
