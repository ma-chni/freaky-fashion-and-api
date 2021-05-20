using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.Areas.Admin.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<Category> Category { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {

            IQueryable<Category> categories = from p in _context.Category.Include(x => x.ProductCategory).ThenInclude(x => x.Product)
                                           select p;
            int pageSize = 10;
            Category = await PaginatedList<Category>.CreateAsync(
                categories.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
