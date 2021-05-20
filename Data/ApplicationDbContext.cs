using System;
using System.Collections.Generic;
using System.Text;
using FreakyFashion.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categories = new List<Category>
            {
                  new Category(1, "Rea", new Uri("/img/bag.jpg", UriKind.Relative)),
                  new Category(2, "Tröjor", new Uri("/img/sweater.jpg", UriKind.Relative)),
                  new Category(3, "Skor", new Uri("/img/shoe.jpg", UriKind.Relative)),
                  new Category(4, "Jeans", new Uri("/img/jeans.jpg", UriKind.Relative)),
                  new Category(5, "Jackor", new Uri("/img/jacket.jpg", UriKind.Relative)),
                  new Category(6, "Väskor", new Uri("/img/bag.jpg", UriKind.Relative)),
                  new Category(7, "Klänningar", new Uri("/img/dress.jpg", UriKind.Relative)),
            };

            categories.ForEach(x => modelBuilder.Entity<Category>().HasData(x));

            var products = new List<Product>
            {
                  new Product(1,"Brun väska", "AWE321", "Brun läder väska med rem", 899, new Uri("/img/bag.jpg", UriKind.Relative), "brun-läder-väska"),
                  new Product(2, "Svart klänning" , "13K34S" , "Svart klänning med vita prickar", 649, new Uri("/img/dress.jpg", UriKind.Relative), "svart-klänning"),
                  new Product(3, "Gul vindjacka" , "7UR432" , "Gul vindjacka med gore-tex material", 1100, new Uri("/img/jacket2.jpg", UriKind.Relative), "gul-vind-jacka"),
                  new Product(4, "Ljus-blå jeans" , "UI8923" , "Ljus-blå jeans med hål", 799, new Uri("/img/jeans4.jpg", UriKind.Relative), "ljus-blå-jeans"),
                  new Product(5, "Nike sneakers" , "Q32SDR" , "Multi färgad sneaker från Nike", 1800, new Uri("/img/shoe4.jpg", UriKind.Relative), "multifärgad-nike-sneakers"),
                  new Product(6, "Gul väska" , "Q8H53D" , "Gul limiterad väska med svarta bin och bruna detaljer", 2499, new Uri("/img/bag1.jpg", UriKind.Relative), "gul-väska"),          
                  new Product(7, "Svart klänning" , "GD02DB" , "Svart klänning med vita prickar", 1499, new Uri("/img/dress7.jpg", UriKind.Relative), "svart-klänning-med-prickar"),
                  new Product(8, "Gråa jeans" , "TG023A" , "Grå jeans med slitningar", 699, new Uri("/img/jeans3.jpg", UriKind.Relative), "gråa-jeans"),
                  new Product(9,"Svarta stövlar", "1EF56G", "Svarta militär stövlar", 999, new Uri("/img/shoe.jpg", UriKind.Relative), "svarta-stövlar"),
                  new Product(10, "Vit tröja" , "WE58XC" , "Vit bomullströja med små detaljer ", 789, new Uri("/img/sweater1.jpg", UriKind.Relative), "vit-tröja"),
                  new Product(11,"Ljus-rosa väska", "TYG4D5", "Ljus-rosa väska", 400, new Uri("/img/bag2.jpg", UriKind.Relative), "ljus-rosa-väska"),
                  new Product(12, "Gul klänning" , "HU90D3" , "Gul off-shoulder klänning", 499, new Uri("/img/dress2.jpg", UriKind.Relative), "gul-klänning"),
                  new Product(13, "Ljus-brun jacka" , "3DR5GC" , "Ljus-brun jacka med snöre", 699, new Uri("/img/jacket3.jpg", UriKind.Relative), "ljus-brun-jacka"),
                  new Product(14, "Ljus-blå jeans" , "B76SXW" , "Ljus-blå jeans med slitningar, band på sidorna", 699, new Uri("/img/jeans6.jpg", UriKind.Relative), "ljus-blåa-jeans-med-band"),
                  new Product(15, "Blå tröja" , "E35FGB" , "Blå stickad tröja", 500, new Uri("/img/sweater2.jpg", UriKind.Relative), "blå-tröja"),
                  new Product(16, "Ljus-rosa klänning" , "WD780C" , "Ljus-rosa off-shoulder klänning", 899, new Uri("/img/dress3.jpg", UriKind.Relative), "ljus-rosa-klänning"),
                  new Product(17, "Adidas träningsjacka" , "T5DESW" , "Grå träningsjacka från Adidias", 1499, new Uri("/img/jacket4.jpg", UriKind.Relative), "adidas-tränings-jacka"),
                  new Product(18, "Vita jeans" , "7UGSRA" , "Vita straight jeans", 399, new Uri("/img/jeans2.jpg", UriKind.Relative), "vita-jeans"),
                  new Product(19,"Ljus-rosa sneakers", "EQ98SX", "Ljus-rosa sneakers med fake diamanter",399, new Uri("/img/shoe7.jpg", UriKind.Relative), "ljus-rosa-sneakers"),
                  new Product(20, "Grå polotröja" , "WH68CS" , "Grå polotröja med små detaljer ", 550, new Uri("/img/sweater5.jpg", UriKind.Relative), "grå-polo-tröja"),
                  new Product(21,"Grå väska", "AW4X50", "Grå tyg väska med varg motiv", 1100, new Uri("/img/bag6.jpg", UriKind.Relative), "grå-väska"),
                  new Product(22, "Vit klänning" , "TYC543" , "Cool Vit klänning", 999, new Uri("/img/dress1.jpg", UriKind.Relative), "vit-klänning"),
                  new Product(23, "Röda klack skor" , "7UR432" , "Röda klackskor med 20 cm klack", 800, new Uri("/img/shoe2.jpg", UriKind.Relative), "röda-klack-skor"),
                  new Product(24, "Rosa polotröja" , "HB7382" , "Rosa stickad polotröja", 799, new Uri("/img/sweater3.jpg", UriKind.Relative), "rosa-polo-tröja"),
                  new Product(25,"Brun väska", "H829KL", "Brun väska", 250, new Uri("/img/bag3.jpg", UriKind.Relative), "brun-väska"),
                  new Product(26, "Blommig klänning" , "YHWE4W" , "Blommig klänning", 800, new Uri("/img/dress4.jpg", UriKind.Relative), "blommig-klänning"),
                  new Product(27, "Svart skinnjacka" , "OPS3ES" , "Svart skinnjacka med silvriga detaljer", 1500, new Uri("/img/jacket.jpg", UriKind.Relative), "svart-skinn-jacka"),
                  new Product(28,"Blå väska", "HUS823", "Blå väska", 400, new Uri("/img/bag5.jpg", UriKind.Relative), "blå-väska"),
                  new Product(29, "Nike sneakers" , "IUS62H" , "Vita sneaker från Nike", 1600, new Uri("/img/shoe3.jpg", UriKind.Relative), "vita-nike-sneakers"),
                  new Product(30, "Röd tröja" , "O1AMCS" , "Röd stickad tröja med V-hals", 800, new Uri("/img/sweater.jpg", UriKind.Relative), "röd-tröja"),
                  new Product(31, "Brun jeansjacka" , "91S6D" , "Brun jeansjacka", 900, new Uri("/img/jacket6.jpg", UriKind.Relative), "brun-jeans-jacka"),
                  new Product(32, "Röda jeans" , "AH390D" , "Röda jeans med slitningar pch hål", 450, new Uri("/img/jeans1.jpg", UriKind.Relative), "röda-jeans"),
                  new Product(33,"Beige klackskor", "PA28S1", "Beige klackskor med rosett", 700, new Uri("/img/shoe5.jpg", UriKind.Relative), "beige-klack-skor"),
                  new Product(34, "Röd stickad tröja" , "OSDG72" , "Röd bomullströja med små detaljer ", 499, new Uri("/img/sweater4.jpg", UriKind.Relative), "röd-stickad-tröja"),
                  new Product(35,"Brun väska", "BNS534", "Brun hand väska", 300, new Uri("/img/bag4.jpg", UriKind.Relative), "brun-hand-väska"),
                  new Product(36, "Blå klänning" , "1A9SDE" , "Blå klänning", 1200, new Uri("/img/dress5.jpg", UriKind.Relative), "blå-klänning"),
                  new Product(37, "Ljus-blå jeansjacka" , "MD7392" , "Ljus-blå jeans jacka", 700, new Uri("/img/jacket1.jpg", UriKind.Relative), "ljus-blå-jeans-jacka"),
                  new Product(38, "Svarta jeans" , "AO02D4" , "Svarta jeans med hål och fiskenät", 500, new Uri("/img/jeans5.jpg", UriKind.Relative), "svarta-jeans"),
                  new Product(39, "Ljus-rosa tröja" , "A83BDH" , "Ljus-rosa stickad tröja", 399, new Uri("/img/sweater6.jpg", UriKind.Relative), "ljus-rosa-tröja"),
                  new Product(40, "Vit klänning" , "O1AN5T" , "Vit klänning med genomskinliga armar", 899, new Uri("/img/dress6.jpg", UriKind.Relative), "vit-klänning"),
                  new Product(41, "Beige kappa" , "R5T2C3" , "Beige kappa med svarta knappar", 1500, new Uri("/img/jacket5.jpg", UriKind.Relative), "beige-kappa"),
                  new Product(42, "Ljus-blå jeans" , "O27DBF" , "Ljus-blå jeans med hål", 599, new Uri("/img/jeans7.jpg", UriKind.Relative), "ljus-blå-jeans"),
                  new Product(43,"Vita sneakers", "FR1NC6", "Vita sneakers med svarta detaljer",399, new Uri("/img/shoe1.jpg", UriKind.Relative), "vita-sneakers"),
                  new Product(44, "Röd polotröja" , "OADB73" , "Röd polotröja med små detaljer ", 550, new Uri("/img/sweater7.jpg", UriKind.Relative), "röd-polo-tröja"),
                  new Product(45, "Ljus-blå jeans" , "CG6234" , "Ljus-blå jeans med hål", 499, new Uri("/img/jeans.jpg", UriKind.Relative), "ljus-blå-jeans-med-hål"),
                  new Product(46, "Olive väska" , "QAMO93" , "Olive packpack med små detaljer", 599, new Uri("/img/bag7.jpg", UriKind.Relative), "olive-väska"),
                  new Product(47, "Gula converse" , "GANCG4" , "Gula converse", 850, new Uri("/img/shoe6.jpg", UriKind.Relative), "gula-converse"),
                  new Product(48, "Rutig jacka" , "AB634D" , "Rutig mångfärgad jacka", 1100, new Uri("/img/jacket7.jpg", UriKind.Relative), "rutig-jacka"),

            };

            products.ForEach(x => modelBuilder.Entity<Product>().HasData(x));

            var productCategory = new List<ProductCategory>
            {
                new ProductCategory(products[0].Id, categories[5].Id),
                new ProductCategory(products[1].Id, categories[6].Id),
                new ProductCategory(products[2].Id, categories[4].Id),
                new ProductCategory(products[3].Id, categories[3].Id),
                new ProductCategory(products[4].Id, categories[2].Id),
                new ProductCategory(products[5].Id, categories[5].Id),
                new ProductCategory(products[6].Id, categories[6].Id),
                new ProductCategory(products[7].Id, categories[3].Id),
                new ProductCategory(products[8].Id, categories[2].Id),
                new ProductCategory(products[9].Id, categories[1].Id),
                new ProductCategory(products[10].Id, categories[5].Id),
                new ProductCategory(products[11].Id, categories[6].Id),
                new ProductCategory(products[12].Id, categories[4].Id),
                new ProductCategory(products[13].Id, categories[3].Id),
                new ProductCategory(products[14].Id, categories[1].Id),
                new ProductCategory(products[15].Id, categories[6].Id),
                new ProductCategory(products[16].Id, categories[4].Id),
                new ProductCategory(products[17].Id, categories[3].Id),
                new ProductCategory(products[18].Id, categories[2].Id),
                new ProductCategory(products[19].Id, categories[1].Id),
                new ProductCategory(products[20].Id, categories[5].Id),
                new ProductCategory(products[21].Id, categories[6].Id),
                new ProductCategory(products[22].Id, categories[2].Id),
                new ProductCategory(products[23].Id, categories[1].Id), 
                new ProductCategory(products[24].Id, categories[5].Id), 
                new ProductCategory(products[25].Id, categories[6].Id), 
                new ProductCategory(products[26].Id, categories[4].Id),
                new ProductCategory(products[27].Id, categories[5].Id),
                new ProductCategory(products[28].Id, categories[2].Id),
                new ProductCategory(products[29].Id, categories[1].Id),
                new ProductCategory(products[30].Id, categories[4].Id),
                new ProductCategory(products[31].Id, categories[3].Id),
                new ProductCategory(products[32].Id, categories[2].Id),
                new ProductCategory(products[33].Id, categories[1].Id),
                new ProductCategory(products[34].Id, categories[5].Id),
                new ProductCategory(products[35].Id, categories[6].Id),
                new ProductCategory(products[36].Id, categories[4].Id),
                new ProductCategory(products[37].Id, categories[3].Id),
                new ProductCategory(products[38].Id, categories[1].Id),
                new ProductCategory(products[39].Id, categories[6].Id),
                new ProductCategory(products[40].Id, categories[4].Id),
                new ProductCategory(products[41].Id, categories[3].Id),
                new ProductCategory(products[42].Id, categories[2].Id),
                new ProductCategory(products[43].Id, categories[1].Id),
                new ProductCategory(products[44].Id, categories[3].Id),
                new ProductCategory(products[45].Id, categories[5].Id),
                new ProductCategory(products[46].Id, categories[2].Id),
                new ProductCategory(products[47].Id, categories[4].Id),
                //Rea
                //new ProductCategory(products[1].Id, categories[1].Id),
                //new ProductCategory(products[2].Id, categories[1].Id),

            };

            productCategory.ForEach(x => modelBuilder.Entity<ProductCategory>().HasData(x));

            modelBuilder.Entity<ProductCategory>()
                .HasKey(x => new { x.ProductId, x.CategoryId });
        }
    }
}
