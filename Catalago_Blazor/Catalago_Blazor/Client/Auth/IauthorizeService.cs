namespace Catalago_Blazor.Client.Auth
{
    public interface IauthorizeService
    {
        Task Login(string token);
        Task Logout();
    }
}
