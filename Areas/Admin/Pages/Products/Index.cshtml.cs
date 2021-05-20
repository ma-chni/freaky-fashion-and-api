using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.Areas.Admin.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IEnumerable<Product> Products { get; set; }

        public PaginatedList<Product> Product { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {

            IQueryable<Product> products = from p in _context.Product.Include(x => x.ProductCategory).ThenInclude(x => x.Category)
                                           select p;
            int pageSize = 10;
            Product = await PaginatedList<Product>.CreateAsync(
                products.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
