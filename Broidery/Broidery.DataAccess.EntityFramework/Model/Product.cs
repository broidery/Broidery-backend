using Broidery.DataAccess.Entities;

namespace Broidery.DataAccess.EntityFramework.Model
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Composition { get; set; }
        public bool IsActive { get; set; }
    }
}