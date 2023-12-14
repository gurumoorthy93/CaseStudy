using CaseStudy.Core.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Security.Claims;

namespace CaseStudy.Tests.Fixtures
{
    public class UsersServiceFixture
    {
        private ServiceCollection _serviceCollection;
        private Mock<ITokenHelper> _tokenHelper;

        public UsersServiceFixture()
        {
            _tokenHelper = new Mock<ITokenHelper>();
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton<ITokenHelper>(_tokenHelper.Object);
        }

        public ServiceCollection ServiceCollection { get { return _serviceCollection; } }
        public void Dispose()
        {
            _serviceCollection = null;
        }

        public void Mock_CreateToken_Ok()
        {
            _tokenHelper.Setup(x => x.CreateToken(It.IsAny<List<Claim>>())).Returns("eyz");
        }
    }
}
