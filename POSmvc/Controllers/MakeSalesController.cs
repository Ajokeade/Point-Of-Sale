using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using POSmvc.Data;
using POSmvc.Models;

using POSmvc.Models.PosViewModel;

namespace POSmvc.Controllers
{
    public class MakeSalesController : Controller
    {
        private readonly PosContext _context;

        public MakeSalesController(PosContext context)
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

        //save to saletable
        [HttpPost]
        [AllowAnonymous]
        public JsonResult SaveSales([FromBody] Sales sales)
        {
            
            var newsales = _context.Sales;
            newsales.Add(sales);
           _context.SaveChanges();
            var salesDetails = _context.SalesDetails.Where(p => p.TransctionID == sales.TransctionID);

            return Json(salesDetails);
        }
        //SaveSalesDetails
        [HttpPost]
        [AllowAnonymous]
        public JsonResult SaveSalesDetails([FromBody] SalesDetail salesDetails)
        {

            var newsales = _context.SalesDetails;
            newsales.Add(salesDetails);
            _context.SaveChanges();
            //var product = _context.Products.Where(p => p.ID == value.ProductID);

            return Json(salesDetails);
        }

        // GET: MakeSales
        public IActionResult Index()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FullName");
            var categoriesList = _context.Categories.OrderBy(s => s.Name);
            ViewData["Category"] = new SelectList(categoriesList, "ID", "Name");


           
            var categories = _context.Categories.ToList();
            var products = _context.Products.ToList();
            var customers = _context.Customers.ToList();
          //  var salesDetails = _context.SalesDetails.ToList();
           // var sales = _context.Sales.ToList();

            //var result = Math.Floor((Math.Random() * 2000) + 1);

           // GetRandomTransactionID();
            var viewModel = new MakeSalesData()
            {

                Categories = categories,
                Products = products,
                Customers = customers,
              //  Sales = sales,
               // SalesDetails = salesDetails

            };

            return View(viewModel);
            //  return View(await _context.MakeSales.ToListAsync());
        }

        // GET: MakeSales/Details/5
        public IActionResult Details(int? id ,int? transactionid)
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




        // GET: MakeSales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MakeSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductName,Price,QuanitityPurchased,SubTotal")] MakeSales makeSales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(makeSales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(makeSales);
        }

        // GET: MakeSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makeSales = await _context.MakeSales.FindAsync(id);
            if (makeSales == null)
            {
                return NotFound();
            }
            return View(makeSales);
        }

        // POST: MakeSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductName,Price,QuanitityPurchased,SubTotal")] MakeSales makeSales)
        {
            if (id != makeSales.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(makeSales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakeSalesExists(makeSales.ID))
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
            return View(makeSales);
        }

        // GET: MakeSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makeSales = await _context.MakeSales
                .FirstOrDefaultAsync(m => m.ID == id);
            if (makeSales == null)
            {
                return NotFound();
            }

            return View(makeSales);
        }

        // POST: MakeSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var makeSales = await _context.MakeSales.FindAsync(id);
            _context.MakeSales.Remove(makeSales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakeSalesExists(int id)
        {
            return _context.MakeSales.Any(e => e.ID == id);
        }
    }
}
