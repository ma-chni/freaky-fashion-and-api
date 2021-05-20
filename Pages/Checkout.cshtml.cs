using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FreakyFashion.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public CheckoutModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Product> Products { get; set; } = new List<Product>();

        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public Address Address { get; set; }

        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnGet()
        {
            var serializedBasket = HttpContext.Session.GetString("Basket");

            if (!string.IsNullOrEmpty(serializedBasket))
            {
                Products = JsonConvert.DeserializeObject<List<Product>>(serializedBasket);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var address = new Address(
                Address.Street,
                Address.City,
                Address.Postcode);

            var customer = new Customer
                (
                Customer.FirstName,
                Customer.LastName,
                Customer.PhoneNumber,
                Customer.SocialSecurityNumber,
                Customer.Email,
                address
                );

            context.Customer.Add(customer);
            await context.SaveChangesAsync();

            var product = HttpContext.Session.GetString("Basket");

            if (!string.IsNullOrEmpty(product))
            {
                Products = JsonConvert.DeserializeObject<List<Product>>(product);
            }

            foreach (var item in Products)
            {
                Product.Id = item.Id;
                Order.TotalPrice += item.Price;
                Order.Quantity = Products.Count();
            }

            var order = new Order
            (
            customer.Id,
            Order.Quantity,
            Order.Date = DateTime.Now,
            Order.TotalPrice,
            Product.Id
            );
            context.Order.Add(order);
            await context.SaveChangesAsync();
      
            return RedirectToPage("OrderConfirmation");
        }
    }
}
