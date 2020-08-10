namespace Broidery.DataAccess.Entities
{
    public interface IProduct
    {
        int Id { get; }
        string Image { get; }
        string Description { get; }
        double Price { get; }
        string Composition { get; }
        bool IsActive { get; }
    }
}