using DiscountApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiscountApi.Controllers
{
    public class ProductController : Controller
    {
        // Для примера используем статический список продуктов как базу данных.
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Description = "High-end laptop" },
            new Product { Id = 2, Name = "Phone", Price = 499.99m, Description = "Smartphone" }
        };

        // GET: /Product/Edit/1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Product/Edit/1
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedProduct);
            }

            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product == null)
            {
                return NotFound();
            }

            // Обновляем данные продукта.
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;

            // Перенаправляем на главную страницу после успешного обновления.
            return RedirectToAction("Index", "Product");
        }

        // Для отображения списка всех продуктов (главная страница).
        public IActionResult Index()
        {
            return View(_products);
        }
    }
}
