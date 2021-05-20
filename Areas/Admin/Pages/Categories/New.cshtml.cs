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

namespace FreakyFashion.Areas.Admin.Pages.Categories
{
    public class NewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public NewModel(ApplicationDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public NewCategoryViewModel CategoryViewModel { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var category = new Category(
                CategoryViewModel.Name,
                new Uri(CategoryViewModel.ImgUrl, UriKind.Relative));

            _context.Category.Add(category);

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");

        }
         
        public class NewCategoryViewModel
        {
            [Required]
            public string Name { get; set; }

            public string ImgUrl { get; set; }
        }
    }
}
