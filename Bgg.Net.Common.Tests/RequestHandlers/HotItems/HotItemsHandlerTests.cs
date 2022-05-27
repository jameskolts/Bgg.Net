using Bgg.Net.Common.Infrastructure;
using Bgg.Net.Common.Models;
using Bgg.Net.Common.Models.Requests;
using Bgg.Net.Common.RequestHandlers.HotItems;
using Bgg.Net.Common.Tests.Infrastructure.Xml;
using Bgg.Net.Common.Tests.TestFiles;
using Bgg.Net.Common.Types;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serilog;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bgg.Net.Common.Tests.RequestHandlers.HotItems
{
    [TestClass]
    internal class HotItemsHandlerTests : HandlerTestBase
    {
        private IHotItemsHandler? _handler;

        [TestMethod]
        public async Task GetHotItemsByType_Success()
        {

        }
    }
}
