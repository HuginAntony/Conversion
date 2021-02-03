using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using Tournament.WebApi.Tests.ApiTests;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Conversion.API.Tests.ApiTests
{
    [TestFixture]
    public class ConversionControllersTests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void StartupTest()
        {
            var factory = new TestFactory();
            TestServer server = factory.Server;

            _httpClient = server.CreateClient();
        }

        [Test]
        public async Task Can_Call_ConvertToCelsius()
        {
            var response = await _httpClient.GetAsync("conversion/temperature/celsius/90");
            var result = await response.Deserialize<decimal>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(result == 32.2222m);
        }
    }
}
