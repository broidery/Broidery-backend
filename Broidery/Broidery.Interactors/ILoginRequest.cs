namespace Broidery.Interactors
{
    public interface ILoginRequest
    {
        string _email { get; }
        string _password { get; }
    }
}