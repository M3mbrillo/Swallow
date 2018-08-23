using SwallowCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using UberApi.V1_2;
using System.Globalization;
using SwallowCore.Settings;

namespace SwallowCore.Core
{
    public class TripsFinders : IDisposable
    {
        private SwallowContext context;

        private HttpClient client;

        public TripsFinders(SwallowContext context)
        {
            this.context = context;
            this.client = this.BuildClientUberApi();
        }

        private HttpClient BuildClientUberApi()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.uber.com");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SwallowCoreSettings.UberApiSetting.TypeAuthentication, SwallowCoreSettings.UberApiSetting.Token);

            return client;
        }

        private async Task SaveTripPriceAsync(Trip trip) {
            var request = trip.ToRequestEstimatesPrices();

            var startAt = DateTime.UtcNow;
            var response = await this.client.GetAsync($"{request.Uri}?{request.ToUriParameters()}");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new SwallowCoreException($"GET /v1.2/estimates/prices: {response.StatusCode}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var responseEstimatesPrices = JsonConvert.DeserializeObject<ResponseEstimatesPrices>(
                jsonResponse, 
                new JsonSerializerSettings() {
                    Culture = CultureInfo.GetCultureInfo("en-US")
                });

            foreach (var estimatePrice in responseEstimatesPrices.prices)
            {
                this.context.EstimatePrice.Add(new EstimatePrice(estimatePrice) {
                    Trip = trip,
                    StartDateTime = startAt
                });
            }
            
            await this.context.SaveChangesAsync();
        }

        public void Run()
        {
            var trips = from t in this.context.Trip
                        select t;

            var taskQueue = new List<Task>();
            foreach (var t in trips)
            {
                taskQueue.Add(this.SaveTripPriceAsync(t));
            }

            Task.WaitAll(taskQueue.ToArray());
        }


        public void Dispose()
        {
            this.client.Dispose();
            this.context.Dispose();
        }
    }
}
