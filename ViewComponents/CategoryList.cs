using System;
using System.Collections.Generic;
using System.Linq;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashion.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ApplicationDbContext context;

        public CategoryList(ApplicationDbContext context) 
        {
            this.context = context;
        }

        public IList<Category> Category { get; set; }

        public IViewComponentResult Invoke()
        {
            Category = context.Category.ToList();
            return View(Category);
        }
    }
}
