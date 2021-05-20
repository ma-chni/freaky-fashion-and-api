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
    public class OrderConfirmationModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public OrderConfirmationModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Order Order { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public IActionResult OnGet()
        {
       
            var serializedBasket = HttpContext.Session.GetString("Basket");

            if (!string.IsNullOrEmpty(serializedBasket))
            {
                Products = JsonConvert.DeserializeObject<List<Product>>(serializedBasket);
            }

            foreach (var item in Products)
            {
                Order = context.Order.Include(x => x.Customer).Include(x => x.Customer.Address).Include(x => x.Product).SingleOrDefault(x => x.ProductId == item.Id);
            }

            return Page();
        }
    }
}
