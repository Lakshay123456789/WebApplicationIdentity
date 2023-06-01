namespace WebApplicationIdentity.Services
{
    public interface IUserServices
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}