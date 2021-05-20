using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreakyFashion.Areas.Admin.Pages.Products
{
    public class NewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public NewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        
        [BindProperty]
        public NewCategoryViewModel CategoryViewModel { get; set; }

        //[BindProperty]
        //public int[] SelectedTags { get; set; }

        public void OnGet()
        {
            CategoryViewModel = new NewCategoryViewModel
            {
                CategoryList = _context.Category
                .ToList()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var urlSlug = Product.Name.Replace(' ', '-').ToLower();
            Product.UrlSlug = urlSlug;

            Product product = new Product(
                Product.Name,
                Product.ArticleNumber,
                Product.Description,
                Product.Price,
                Product.ImageUrl,
                Product.UrlSlug);

            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            var category = new Category(CategoryViewModel.Id);
            var productCategory = new ProductCategory(category.Id, product);
            _context.ProductCategory.Add(productCategory);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
         
        public class NewCategoryViewModel
        {
            [Required]
            public int Id { get; set; }

            public IEnumerable<SelectListItem> CategoryList { get; set; }
        }
    }
}
