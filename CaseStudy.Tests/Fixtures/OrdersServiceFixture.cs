using CaseStudy.Core.Common;
using CaseStudy.Core.Helpers;
using CaseStudy.Services.Services;
using Castle.Core.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Tests.Fixtures
{
    public class OrdersServiceFixture
    {
        private ServiceCollection _serviceCollection;
        private Mock<ActionContext> _actionContext;

        public OrdersServiceFixture()
        {
            _actionContext = new Mock<ActionContext>();
            var _logger = new Mock<ILogger<OrdersService>>();
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton<ActionContext>(_actionContext.Object);
            _serviceCollection.AddSingleton<ILogger<OrdersService>>(_logger.Object);
        }

        public ServiceCollection ServiceCollection { get { return _serviceCollection; } }
        public void Dispose()
        {
            _serviceCollection = null;
        }

        public void Mock_ActionContext_Ok()
        {
            _actionContext.Object.UserId = 1;
        }

        public void Mock_ActionContext_BadRequest()
        {
            _actionContext.Object.UserId = 0;
        }
    }
}
