using ClubApp.Helper;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace ClubApp.Services
{
   public class BookingStore:IBookingStore
    {
        private readonly string _apiBaseUrl;
        private readonly string _BookingRelativeUrlTemplate;
        public BookingStore()
        {
            _apiBaseUrl = App.AzureBackendUrl;
            _BookingRelativeUrlTemplate = "api/booking";
        }
        public  async System.Threading.Tasks.Task GetAssetsAsync(dynamic query)
        {
            try
            {

                var relativeUrl = _apiBaseUrl.AppendPathSegment("api/bookings").SetQueryParam(nameof(query.SiteFilter), query.SiteFilter.Value);

                if (query.AssetCategoryFilter != null && query.SiteFilter != null)
                {
                    relativeUrl = relativeUrl
                        .SetQueryParam(nameof(query.SiteFilter), query.SiteFilter.Value)
                        .SetQueryParam(nameof(query.AssetCategoryFilter), query.AssetCategoryFilter.Value);

                }
                var header = new AuthenticationHeaderValue(
                "Bearer", Settings.AccessToken);
                var response = await relativeUrl
                        .WithHeader("Authorization", header)
                        .GetAsync()
                        .ReceiveJson<List<dynamic>>();

               // return response;
            }
            catch (FlurlHttpException fex)
            {
                var errorText = await fex.GetResponseStringAsync();
                Debug.WriteLine(errorText); 
            }
        }

        void IBookingStore.GetAssetsAsync(dynamic query)
        {
            throw new NotImplementedException();
        }
    }
}
