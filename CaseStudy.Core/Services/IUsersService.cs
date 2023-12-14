
namespace CaseStudy.Core.Services
{
    public interface IUsersService
    {
        string ValidateLogin(string username, string password);
    }
}
