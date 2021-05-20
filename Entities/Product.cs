using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyFashion.Entities
{
    public class Product
    {
        public Product(string name, string articleNumber, string description, uint price, Uri imageUrl, string urlSlug)
        {
            Name = name;
            ArticleNumber = articleNumber;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            UrlSlug = urlSlug;
        }

        public Product(int id, string name, string articleNumber, string description, uint price, Uri imageUrl, string urlSlug) : this(name, articleNumber, description, price, imageUrl, urlSlug)
        {
            Id = id;
        }

        public Product()
        {

        }

        public int Id { get; set; }

        [Display(Name = "Produkt")]
        public string Name { get; set; }

        [Display(Name = "Art.nr")]
        public string ArticleNumber { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Display(Name = "Pris")]
        public uint Price { get; set; }

        [Display(Name = "Bild URL")]
        public Uri ImageUrl { get; set; }

        [Display(Name = "URL Slug")]
        public string UrlSlug { get; set; }

        public ICollection<ProductCategory> ProductCategory { get; set; } = new List<ProductCategory>();

        public ICollection<Order> Order { get; set; } = new List<Order>();
    }
}
