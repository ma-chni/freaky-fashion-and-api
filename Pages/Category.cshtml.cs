using System.Collections.Generic;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Category Category { get; set; }

        public IList<Category> Categories { get; set; }

        public CategoryModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (name == "")
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.Name == name);

            Categories = await _context.Category
            .Include(x => x.ProductCategory)
            .ThenInclude(x => x.Product)
            .ToListAsync();

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
