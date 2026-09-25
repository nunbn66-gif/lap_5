
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NsbmLesson10_EFDB.Models;

public class NsbmMembersController : Controller
{
    private readonly Lesson10EfdbContext _context;

    public NsbmMembersController(Lesson10EfdbContext context)
    {
        _context = context;
    }

    // GET: NSBMMEMBERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.NsbmMembers.ToListAsync());
    }

    // GET: NSBMMEMBERS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nsbmmember = await _context.NsbmMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (nsbmmember == null)
        {
            return NotFound();
        }

        return View(nsbmmember);
    }

    // GET: NSBMMEMBERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NSBMMEMBERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NsbmUserName,NsbmPassword,NsbmFullName,NsbmEmail,NsbmPhone,NsbmStartus")] NsbmMember nsbmmember)
    {
        if (ModelState.IsValid)
        {
            _context.Add(nsbmmember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(nsbmmember);
    }

    // GET: NSBMMEMBERS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nsbmmember = await _context.NsbmMembers.FindAsync(id);
        if (nsbmmember == null)
        {
            return NotFound();
        }
        return View(nsbmmember);
    }

    // POST: NSBMMEMBERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,NsbmUserName,NsbmPassword,NsbmFullName,NsbmEmail,NsbmPhone,NsbmStartus")] NsbmMember nsbmmember)
    {
        if (id != nsbmmember.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(nsbmmember);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NsbmMemberExists(nsbmmember.Id))
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
        return View(nsbmmember);
    }

    // GET: NSBMMEMBERS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nsbmmember = await _context.NsbmMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (nsbmmember == null)
        {
            return NotFound();
        }

        return View(nsbmmember);
    }

    // POST: NSBMMEMBERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var nsbmmember = await _context.NsbmMembers.FindAsync(id);
        if (nsbmmember != null)
        {
            _context.NsbmMembers.Remove(nsbmmember);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NsbmMemberExists(long? id)
    {
        return _context.NsbmMembers.Any(e => e.Id == id);
    }
}
