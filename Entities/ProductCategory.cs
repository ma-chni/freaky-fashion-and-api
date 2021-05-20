namespace FreakyFashion.Entities
{
    public class ProductCategory
    {
        public ProductCategory(int categoryId)
        {
            CategoryId = categoryId;
        }

        public ProductCategory(int productId, int categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }

        public ProductCategory(int categoryId, Product product)
        {
            CategoryId = categoryId;
            Product = product;
        }

        public int ProductId { get; protected set; }
        public int CategoryId { get; protected set; }
        public Product Product { get; protected set; }
        public Category Category { get; protected set; }
    }
}
