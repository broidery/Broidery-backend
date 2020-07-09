namespace Broidery.DataAccess
{
    public interface IUser
    {
        int Id { get; }
        string Email { get; }
        string Name { get; }
        string Surname { get; }
        string Password { get; }
        string Token { get; }
    }
}