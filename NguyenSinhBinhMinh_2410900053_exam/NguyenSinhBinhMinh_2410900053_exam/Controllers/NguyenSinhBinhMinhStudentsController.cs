
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenSinhBinhMinh_2410900053_exam.Models;

public class NguyenSinhBinhMinhStudentsController : Controller
{
    private readonly NguyenSinhBinhMinhStudentContext _context;

    public NguyenSinhBinhMinhStudentsController(NguyenSinhBinhMinhStudentContext context)
    {
        _context = context;
    }

    // GET: NGUYENSINHBINHMINHSTUDENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.NguyenSinhBinhMinhStudents.ToListAsync());
    }

    // GET: NGUYENSINHBINHMINHSTUDENTS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nguyensinhbinhminhstudent = await _context.NguyenSinhBinhMinhStudents
            .FirstOrDefaultAsync(m => m.Id == id);
        if (nguyensinhbinhminhstudent == null)
        {
            return NotFound();
        }

        return View(nguyensinhbinhminhstudent);
    }

    // GET: NGUYENSINHBINHMINHSTUDENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NGUYENSINHBINHMINHSTUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NguyenSinhBinhMinhName,NguyenSinhBinhMinhGender,NguyenSinhBinhMinhBirthday,NguyenSinhBinhMinhEmail,NguyenSinhBinhMinhPhone,NguyenSinhBinhMinhActive")] NguyenSinhBinhMinhStudent nguyensinhbinhminhstudent)
    {
        if (ModelState.IsValid)
        {
            _context.Add(nguyensinhbinhminhstudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(nguyensinhbinhminhstudent);
    }

    // GET: NGUYENSINHBINHMINHSTUDENTS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nguyensinhbinhminhstudent = await _context.NguyenSinhBinhMinhStudents.FindAsync(id);
        if (nguyensinhbinhminhstudent == null)
        {
            return NotFound();
        }
        return View(nguyensinhbinhminhstudent);
    }

    // POST: NGUYENSINHBINHMINHSTUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,NguyenSinhBinhMinhName,NguyenSinhBinhMinhGender,NguyenSinhBinhMinhBirthday,NguyenSinhBinhMinhEmail,NguyenSinhBinhMinhPhone,NguyenSinhBinhMinhActive")] NguyenSinhBinhMinhStudent nguyensinhbinhminhstudent)
    {
        if (id != nguyensinhbinhminhstudent.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(nguyensinhbinhminhstudent);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguyenSinhBinhMinhStudentExists(nguyensinhbinhminhstudent.Id))
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
        return View(nguyensinhbinhminhstudent);
    }

    // GET: NGUYENSINHBINHMINHSTUDENTS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nguyensinhbinhminhstudent = await _context.NguyenSinhBinhMinhStudents
            .FirstOrDefaultAsync(m => m.Id == id);
        if (nguyensinhbinhminhstudent == null)
        {
            return NotFound();
        }

        return View(nguyensinhbinhminhstudent);
    }

    // POST: NGUYENSINHBINHMINHSTUDENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var nguyensinhbinhminhstudent = await _context.NguyenSinhBinhMinhStudents.FindAsync(id);
        if (nguyensinhbinhminhstudent != null)
        {
            _context.NguyenSinhBinhMinhStudents.Remove(nguyensinhbinhminhstudent);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NguyenSinhBinhMinhStudentExists(long? id)
    {
        return _context.NguyenSinhBinhMinhStudents.Any(e => e.Id == id);
    }
}
