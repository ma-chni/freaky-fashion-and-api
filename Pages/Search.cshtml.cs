using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public IList<Product> ProductList { get; set; }

        public async Task<IActionResult> OnGet([FromQuery] string q)
        {
            ViewData["q"] = q; 
            var product = from p in _context.Product
                          select p;
            if (q == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(q))
            {
                product = product.Where(s => s.Name.Contains(q));
            }

            ProductList = await product.ToListAsync();

            return Page();
        }
    }
}
