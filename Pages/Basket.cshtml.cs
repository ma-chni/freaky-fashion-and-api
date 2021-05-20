using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FreakyFashion.Pages
{
    public class BasketModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public BasketModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        [BindProperty]
        public Product Product { get; set; }


        public IActionResult OnGet()
        {
            var serializedBasket = HttpContext.Session.GetString("Basket");

            if (!string.IsNullOrEmpty(serializedBasket))
            {
                Products = JsonConvert.DeserializeObject<List<Product>>(serializedBasket);
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Checkout");
        }
    }
}
