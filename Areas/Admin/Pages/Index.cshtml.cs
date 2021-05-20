using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Order> Orders { get; set; }

        public void OnGet()
        {
            Orders = context.Order.Include(x => x.Customer).ToList();
        }
    }
}
