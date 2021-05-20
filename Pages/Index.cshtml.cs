using System.Collections.Generic;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FreakyFashion.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ApplicationDbContext _context;
      
        public IList<Product> ProductList = new List<Product>();

        public IList<Category> Categories = new List<Category>();

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
      
        }

        public async Task OnGetAsync()
        {
            ProductList = await _context.Product.ToListAsync();
            Categories = await _context.Category.ToListAsync();
        }
    }
}
