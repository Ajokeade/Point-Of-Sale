using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POSmvc.Data;
using POSmvc.Models;

namespace POSmvc.Controllers
{
    public class SalesDetailsController : Controller
    {
        private readonly PosContext _context;

        public SalesDetailsController(PosContext context)
        {
            _context = context;
        }

        // GET: SalesDetails
        public async Task<IActionResult> Index(int? transactionid)
        {
            if (transactionid!=null)
            {
                var salesdetails =  _context.SalesDetails.Where(p => p.TransctionID == transactionid).Include(s=>s.Products);
                return View(await salesdetails.ToListAsync());
            }
            var posContext = _context.SalesDetails
                
                .Include(s => s.Products);
                    
            return View(await posContext.ToListAsync());
        }

        // GET: SalesDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetail = await _context.SalesDetails
                //.Include(s => s.Sales)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (salesDetail == null)
            {
                return NotFound();
            }

            return View(salesDetail);
        }

        // GET: SalesDetails/Create
        public IActionResult Create()
        {
            ViewData["SalesID"] = new SelectList(_context.Sales, "ID", "ID");
            return View();
        }

        // POST: SalesDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductID,QuantityPurchased,SubTotal,DatePurchased,SalesID")] SalesDetail salesDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesID"] = new SelectList(_context.Sales, "ID", "ID");//salesDetail.SalesID
            return View(salesDetail);
        }

        // GET: SalesDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetail = await _context.SalesDetails.FindAsync(id);
            if (salesDetail == null)
            {
                return NotFound();
            }
            ViewData["SalesID"] = new SelectList(_context.Sales, "ID", "ID");//, salesDetail.SalesID
            return View(salesDetail);
        }

        // POST: SalesDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductID,QuantityPurchased,SubTotal,DatePurchased,SalesID")] SalesDetail salesDetail)
        {
            if (id != salesDetail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesDetailExists(salesDetail.ID))
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
            ViewData["SalesID"] = new SelectList(_context.Sales, "ID", "ID");//salesDetail.SalesID
            return View(salesDetail);
        }

        // GET: SalesDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetail = await _context.SalesDetails
                //.Include(s => s.Sales)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (salesDetail == null)
            {
                return NotFound();
            }

            return View(salesDetail);
        }

        // POST: SalesDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesDetail = await _context.SalesDetails.FindAsync(id);
            _context.SalesDetails.Remove(salesDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesDetailExists(int id)
        {
            return _context.SalesDetails.Any(e => e.ID == id);
        }
    }
}
