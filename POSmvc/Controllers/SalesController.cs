using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POSmvc.Data;
using POSmvc.Models;
using POSmvc.Models.PosViewModel;


namespace POSmvc
{
    public class SalesController : Controller
    {
        private readonly PosContext _context;

        public SalesController(PosContext context)
        {
            _context = context;
        }

        //method that get the product dropdown values when you click on the category dropdowwn
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ProductDropDownValues([FromBody] AjaxModel value)
        {
           
            var product = _context.Products.Where(p => p.CategoryID == value.CategoryID).ToList();
            return Json(product);
        }

        //method that get the product price  when you click on the product dropdowwn
        [HttpPost]
        [AllowAnonymous]
        public JsonResult GetProductPrice([FromBody] AjaxModel value)
        {

            var product = _context.Products.Where(p => p.ID == value.ProductID);
            return Json(product);
        }



        // GET: Sales
        public IActionResult Index()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FullName");
            var categoriesList = _context.Categories.OrderBy(s => s.Name);
            ViewData["Category"] = new SelectList(categoriesList, "ID", "Name");



            var categories = _context.Categories.ToList();
            var products = _context.Products.ToList();
            var customers = _context.Customers.ToList();
            var salesDetails = _context.SalesDetails.ToList();
            var sales = _context.Sales.ToList();




            var viewModel = new MakeSalesData()
            {

                Categories = categories,
                Products = products,
                Customers = customers,
                Sales=sales,
                SalesDetails=salesDetails

            };

            return View(viewModel);

            //var posContext = _context.Sales
            //    .Include(s => s.Customer);
              
            //return View(await posContext.ToListAsync());

            // .Include(s => s.Categories)
            // .ThenInclude(s=>s.Products);
        }

        // GET: Sales/Details/5
        public IActionResult Details(int? id, int? transactionid)
        {
            var categories = _context.Categories.ToList();
            var products = _context.Products.ToList();
            var customers = _context.Customers.ToList();
            var salesDetails = _context.SalesDetails.ToList();
            var sales = _context.Sales.ToList();
            var viewModel = new MakeSalesData()
            {

                Categories = categories,
                Products = products,
                Customers = customers,
                Sales = sales,
                SalesDetails = salesDetails

            };

            if (id != transactionid)
            {
                //ViewData["transactionID"] = id.Value;
                //SalesDetail SalesDetail = viewModel.SalesDetails.Where(
                //    i => i.TransctionID == id.Value).Single();
                ////viewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);


                //viewModel.SalesDetails = viewModel.SalesDetails.Where(
                //    x => x.TransctionID == id).SingleOrDefault().SalesDetails;

                viewModel.SalesDetails = viewModel.SalesDetails.Where(p => p.TransctionID == transactionid);
                viewModel.Sales= viewModel.Sales.Where(p => p.TransctionID == transactionid);
            }

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var makeSales = await _context.MakeSales
            //    .FirstOrDefaultAsync(m => m.ID == id);
            //if (makeSales == null)
            //{
            //    return NotFound();
            //}

            return View(viewModel);
        }
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var sales = await _context.Sales
        //        .Include(s => s.Customer)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (sales == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(sales);
        //}

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FullName");
            var categories = _context.Categories.OrderBy(s => s.Name);
           ViewData["Category"] = new SelectList(categories, "ID", "Name");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TransctionID,TotalAmount,AmountPaid,Balance,TranscationDate,CustomerID")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FirstName", sales.CustomerID);
          //  ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", sales.CategoryID);
            return View(sales);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FirstName", sales.CustomerID);
            return View(sales);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TransctionID,TotalAmount,AmountPaid,Balance,TranscationDate,CustomerID")] Sales sales)
        {
            if (id != sales.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesExists(sales.ID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FirstName", sales.CustomerID);
            return View(sales);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = await _context.Sales
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sales = await _context.Sales.FindAsync(id);
            _context.Sales.Remove(sales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesExists(int id)
        {
            return _context.Sales.Any(e => e.ID == id);
        }
    }
}
