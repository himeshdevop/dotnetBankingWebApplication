using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBWebEFAPI.Data;

namespace DBWebEFAPI.Controllers
{
    public class AuditsController : Controller
    {
        private readonly DBManage _context;

        public AuditsController(DBManage context)
        {
            _context = context;
        }

        // GET: Audits
        public async Task<IActionResult> Index()
        {
              return _context.Audits != null ? 
                          View(await _context.Audits.ToListAsync()) :
                          Problem("Entity set 'DBManage.Audits'  is null.");
        }

        // GET: Audits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Audits == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits
                .FirstOrDefaultAsync(m => m.auditId == id);
            if (audit == null)
            {
                return NotFound();
            }

            return View(audit);
        }

        // GET: Audits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Audits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("auditId,auditRecord")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audit);
        }

        // GET: Audits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Audits == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits.FindAsync(id);
            if (audit == null)
            {
                return NotFound();
            }
            return View(audit);
        }

        // POST: Audits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("auditId,auditRecord")] Audit audit)
        {
            if (id != audit.auditId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditExists(audit.auditId))
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
            return View(audit);
        }

        // GET: Audits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Audits == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits
                .FirstOrDefaultAsync(m => m.auditId == id);
            if (audit == null)
            {
                return NotFound();
            }

            return View(audit);
        }

        // POST: Audits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Audits == null)
            {
                return Problem("Entity set 'DBManage.Audits'  is null.");
            }
            var audit = await _context.Audits.FindAsync(id);
            if (audit != null)
            {
                _context.Audits.Remove(audit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditExists(string id)
        {
          return (_context.Audits?.Any(e => e.auditId == id)).GetValueOrDefault();
        }
    }
}
