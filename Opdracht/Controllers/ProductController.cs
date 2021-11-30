using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Opdracht.DAL;
using Opdracht.Data;
using Opdracht.Models;

namespace Opdracht.Controllers
{
    public class ProductController : Controller
    {
        private readonly OpdrachtContext _context;
        ProductAccessLayer pal = new ProductAccessLayer();

        public ProductController(OpdrachtContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = pal.GetProductList();
            return View(products);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var products = pal.GetProduct(id);
            return View(products);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View(new ProductModel());
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sku,ProductName,Price")] ProductModel productModel)
        {
            if(productModel.ProductName == null)
            {
                productModel.ProductName = string.Empty;
            }
            else if (productModel.Sku == null)
            {
                productModel.Sku = string.Empty;
            }
            pal.AddProduct(productModel);
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ProductModel productModel = pal.GetProduct(id);
            return View(productModel);

        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sku,ProductName,Price")] ProductModel productModel)
        {
            if (productModel.ProductName == null)
            {
                productModel.ProductName = string.Empty;
            }
            else if (productModel.Sku == null)
            {
                productModel.Sku = string.Empty;
            }
            pal.UpdateProduct(productModel);
            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ProductModel productModel = pal.GetProduct(id);
            return View(productModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            pal.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}
