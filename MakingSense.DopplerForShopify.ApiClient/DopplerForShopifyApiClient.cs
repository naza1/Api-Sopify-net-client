using MakingSense.DopplerForShopify.ApiClient.Internal;
using System;
using System.Net.Http;

namespace MakingSense.DopplerForShopify.ApiClient
{
    public class DopplerForShopifyApiClient : IDopplerForShopifyApiClient
    {
        private readonly DopplerForShopifyApiClientConfiguration _configuration;

        public DopplerForShopifyApiClient(DopplerForShopifyApiClientConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AbandonedCarts[] GetAbandonedCarts(string shopDomain)
        {


            var request = Helper.CreateRequest(_configuration.BaseUrl + "/abandoned-carts", HttpMethod.Post);

            if (request.StatusCode != System.Net.HttpStatusCode.OK)
                throw new NotImplementedException();

            dynamic a = request.GetContentAsJObject();
            var array = new AbandonedCarts[10];
            var i = 0;

            foreach (dynamic item in a.d)
            {
                array[i] = item;
                i++;
            }

            return array;
        }

        public IntegrationStatus GetIntegrationStatus(int userId)
        {
            throw new NotImplementedException();
        }

        public IntegrationStatus GetIntegrationStatus(string shopDomain)
        {
            throw new NotImplementedException();
        }

        public Shop[] GetShops(string apiKey)
        {
            throw new NotImplementedException();
        }
    }
}
