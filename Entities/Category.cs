using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyFashion.Entities
{
    public class Category
    {
        public Category(int id)
        {
            Id = id;
        }

        public Category(string name, Uri imgUrl)
        {
            Name = name;
            ImgUrl = imgUrl;
        }

        public Category(int id, string name, Uri imgUrl)
        {
            Id = id;
            Name = name;
            ImgUrl = imgUrl;
        }

        public Category()
        {

        }

        public int Id { get; set; }
        [Display(Name = "Kategori")]
        public string Name { get; set; }
        public Uri ImgUrl { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; protected set; } = new List<ProductCategory>();
    }
}