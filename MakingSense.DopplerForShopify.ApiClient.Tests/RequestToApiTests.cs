using MakingSense.DopplerForShopify.ApiClient.Internal;
using System.Net;
using System.Net.Http;
using Xunit;

namespace MakingSense.DopplerForShopify.ApiClient.Tests
{
    public class RequestToApiTests
    {
        [Fact]
        public void Check_Request_Return_Ok()
        {
            var response = Helper.CreateRequest("?p=test", HttpMethod.Get);

            Assert.Equal(HttpStatusCode.OK, actual: response.StatusCode);
        }

        [Fact]
        public void Check_Request_Return_Not_Found()
        {
            var response = Helper.CreateRequest("www.ggogle.com", HttpMethod.Get);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
