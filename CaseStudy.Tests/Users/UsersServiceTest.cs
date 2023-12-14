using CaseStudy.Core.Data;
using CaseStudy.Services.Services;
using CaseStudy.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;

namespace CaseStudy.Tests.Users
{
    public class UsersServiceTest:IClassFixture<UsersServiceFixture>
    {
        private UsersServiceFixture _usersServiceFixture;
        private IServiceProvider _serviceProvider;
        public UsersServiceTest(UsersServiceFixture usersServiceFixture)
        {
            _usersServiceFixture = usersServiceFixture;
            _serviceProvider = usersServiceFixture.ServiceCollection.BuildServiceProvider();
        }

        [Fact]
        public async void Mock_ValidateLogin_NoToken()
        {
            var UsersService = new UsersService(_serviceProvider);

            var result = UsersService.ValidateLogin("incorrectuseremail", "password");

            Assert.Equal("", result);
        }

        [Fact]
        public async void Mock_ValidateLogin_ValidToken()
        {
            _usersServiceFixture.Mock_CreateToken_Ok();

            var UsersService = new UsersService(_serviceProvider);

            var user = UsersData.Users.First();

            var ActualResult = UsersService.ValidateLogin(user.Email, user.Password);

            Assert.StartsWith("ey", ActualResult);
        }
    }
}
