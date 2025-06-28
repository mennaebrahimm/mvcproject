using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using mvcproject.ViewModels;
using System;
using System.Linq;

namespace mvcproject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProjectContext db;

        public ProductController(ProjectContext context)
        {
            db = context;
        }

        public IActionResult Index(string categoryFilter, string search, int page = 1, int pageSize = 6)
        {
            var products = db.Products.Where(p => !p.isDeleted);

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                categoryFilter = categoryFilter.ToLower();
                products = products.Where(p => p.category.ToLower().Contains(categoryFilter));
            }

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.name.Contains(search));
            }

            var totalItems = products.Count();

            var paginatedProducts = products
                .OrderBy(p => p.id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new ProductListViewModel
            {
                Products = paginatedProducts.Select(p => new ProductViewModel
                {
                    Id = p.id,
                    Name = p.name,
                    Description = p.description,
                    Category = p.category,
                    Price = p.price,
                    Quantity = p.quantity,
                    ImagePath = p.imagePath
                }).ToList(),

                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                CategoryFilter = categoryFilter,
                Search = search
            };

            return View(viewModel);
        }
    }
}
