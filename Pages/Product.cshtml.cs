using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FreakyFashion.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Product Product { get; set; }

        public IList<Product> ProductList = new List<Product>();

        public ProductModel(ApplicationDbContext context)
        {

            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(string urlSlug)
        {
            if (urlSlug == "")
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.UrlSlug == urlSlug);

            ProductList = await _context.Product.ToListAsync();

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            var serializedBasket = HttpContext.Session.GetString("Basket");

            var basket = new List<Product>();

            if (serializedBasket != null)
            {
                basket = JsonConvert.DeserializeObject<List<Product>>(serializedBasket);
            }

            Product = _context.Product
                   .FirstOrDefault(x => x.Id == Product.Id);

            basket.Add(Product);

            serializedBasket = JsonConvert.SerializeObject(basket);

            HttpContext.Session.SetString("Basket", serializedBasket);

            return RedirectToPage("Basket");
        }
    }
}
