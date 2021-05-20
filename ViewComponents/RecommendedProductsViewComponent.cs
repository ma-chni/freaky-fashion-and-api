using System;
using System.Collections;
using System.Collections.Generic;
using FreakyFashion.Data;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashion.ViewComponents
{
    public class RecommendedProductsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public RecommendedProductsViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke(IList<Product> products)
        {
            return View(products);
        }
    }
}
