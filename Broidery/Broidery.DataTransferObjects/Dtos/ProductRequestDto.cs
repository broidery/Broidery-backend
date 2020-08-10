namespace Broidery.DataTransferObjects.Dtos
{
    public class ProductRequestDto 
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Composition { get; set; }
        public bool IsActive { get; set; }
    }
}