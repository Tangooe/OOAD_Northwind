using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOAD_Northwind.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OOAD_Northwind.Controllers
{
    public class PartiesController : Controller
    {
        private readonly NorthwindContext _context;

        public PartiesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: Parties
        public async Task<IActionResult> Index()
        {
            var northwindContext = _context.Parties.Include(p => p.TypeNavigation);
            return View(await northwindContext.ToListAsync());
        }

        // GET: Parties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parties = await _context.Parties
                .Include(p => p.TypeNavigation)
                .Include(p => p.AccountabilitiesPartyANavigation).ThenInclude(a => a.TypeNavigation)
                .Include(p => p.AccountabilitiesPartyANavigation).ThenInclude(a => a.PartyBNavigation)
                .Include(p => p.AccountabilitiesPartyBNavigation).ThenInclude(b => b.TypeNavigation)
                .Include(p => p.AccountabilitiesPartyBNavigation).ThenInclude(b => b.PartyANavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (parties == null)
            {
                return NotFound();
            }

            return View(parties);
        }

        // GET: Parties/Create
        public IActionResult Create()
        {
            ViewData["Type"] = new SelectList(_context.PartyTypes, "Id", "Id");
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Type")] Parties parties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Type"] = new SelectList(_context.PartyTypes, "Id", "Id", parties.Type);
            return View(parties);
        }

        // GET: Parties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parties = await _context.Parties.SingleOrDefaultAsync(m => m.Id == id);
            if (parties == null)
            {
                return NotFound();
            }
            ViewData["Type"] = new SelectList(_context.PartyTypes, "Id", "Id", parties.Type);
            return View(parties);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Type")] Parties parties)
        {
            if (id != parties.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartiesExists(parties.Id))
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
            ViewData["Type"] = new SelectList(_context.PartyTypes, "Id", "Id", parties.Type);
            return View(parties);
        }

        // GET: Parties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parties = await _context.Parties
                .Include(p => p.TypeNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (parties == null)
            {
                return NotFound();
            }

            return View(parties);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parties = await _context.Parties.SingleOrDefaultAsync(m => m.Id == id);
            _context.Parties.Remove(parties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartiesExists(int id)
        {
            return _context.Parties.Any(e => e.Id == id);
        }
    }
}
