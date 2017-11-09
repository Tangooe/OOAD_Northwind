using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOAD_Northwind.Models;

namespace OOAD_Northwind.Controllers
{
    public class AccountabilitiesController : Controller
    {
        private readonly NorthwindContext _context;

        public AccountabilitiesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: Accountabilities
        public IActionResult Index()
        {
            var northwindContext = _context.Accountabilities.Include(a => a.PartyANavigation).Include(a => a.PartyBNavigation).Include(a => a.TypeNavigation).Where(a => a.PartyANavigation.Name != "Northwind").ToList();
            return View(northwindContext);
        }

        // GET: Accountabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountabilities = await _context.Accountabilities
                .Include(a => a.PartyANavigation)
                .Include(a => a.PartyBNavigation)
                .Include(a => a.TypeNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (accountabilities == null)
            {
                return NotFound();
            }

            return View(accountabilities);
        }

        // GET: Accountabilities/Create
        public IActionResult Create()
        {
            ViewData["PartyA"] = new SelectList(_context.Parties, "Id", "Name");
            ViewData["PartyB"] = new SelectList(_context.Parties, "Id", "Name");
            ViewData["Type"] = new SelectList(_context.AccountabilityTypes, "Id", "Id");
            return View();
        }

        // POST: Accountabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PartyA,PartyB,Type,StartDateTime,EndDateTime")] Accountabilities accountabilities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountabilities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartyA"] = new SelectList(_context.Parties, "Id", "Name", accountabilities.PartyA);
            ViewData["PartyB"] = new SelectList(_context.Parties, "Id", "Name", accountabilities.PartyB);
            ViewData["Type"] = new SelectList(_context.AccountabilityTypes, "Id", "Id", accountabilities.Type);
            return View(accountabilities);
        }

        // GET: Accountabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountabilities = await _context.Accountabilities.SingleOrDefaultAsync(m => m.Id == id);
            if (accountabilities == null)
            {
                return NotFound();
            }
            ViewData["PartyA"] = new SelectList(_context.Parties, "Id", "Name", accountabilities.PartyA);
            ViewData["PartyB"] = new SelectList(_context.Parties, "Id", "Name", accountabilities.PartyB);
            ViewData["Type"] = new SelectList(_context.AccountabilityTypes, "Id", "Id", accountabilities.Type);
            return View(accountabilities);
        }

        // POST: Accountabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PartyA,PartyB,Type,StartDateTime,EndDateTime")] Accountabilities accountabilities)
        {
            if (id != accountabilities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountabilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountabilitiesExists(accountabilities.Id))
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
            ViewData["PartyA"] = new SelectList(_context.Parties, "Id", "Name", accountabilities.PartyA);
            ViewData["PartyB"] = new SelectList(_context.Parties, "Id", "Name", accountabilities.PartyB);
            ViewData["Type"] = new SelectList(_context.AccountabilityTypes, "Id", "Id", accountabilities.Type);
            return View(accountabilities);
        }

        // GET: Accountabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountabilities = await _context.Accountabilities
                .Include(a => a.PartyANavigation)
                .Include(a => a.PartyBNavigation)
                .Include(a => a.TypeNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (accountabilities == null)
            {
                return NotFound();
            }

            return View(accountabilities);
        }

        // POST: Accountabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountabilities = await _context.Accountabilities.SingleOrDefaultAsync(m => m.Id == id);
            _context.Accountabilities.Remove(accountabilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountabilitiesExists(int id)
        {
            return _context.Accountabilities.Any(e => e.Id == id);
        }
    }
}
