using CaseStudy.Core.Data;
using CaseStudy.Core.Helpers;
using CaseStudy.Core.Services;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace CaseStudy.Services.Services
{
    public class UsersService : IUsersService
    {
        private readonly ITokenHelper tokenHelper;

        public UsersService(IServiceProvider serviceProvider)
        {
            tokenHelper = serviceProvider.GetRequiredService<ITokenHelper>();
        }

        public string ValidateLogin(string username, string password)
        {
            string token = "";

            var User = UsersData.Users.Where(x => x.Email == username).FirstOrDefault();

            if (User != null)
            {
                if (User.Password == password)
                {
                    var claims = new List<Claim>
                    {
                      new Claim("sub", User.Email),
                      new Claim("firstname", User.FirstName),
                      new Claim("lastname", User.LastName),
                      new Claim("userid", User.Id.ToString())
                    };

                    token = tokenHelper.CreateToken(claims);
                }
            }

            return token;
        }
    }
}
