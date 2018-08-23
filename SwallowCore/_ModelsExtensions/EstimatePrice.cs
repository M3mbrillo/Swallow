using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UberApi.V1_2;

namespace SwallowCore.Models
{
    public partial class EstimatePrice
    {
        public EstimatePrice()
        {

        }

        public EstimatePrice(ResponseEstimatesPricesItem responseEstimatesPricesItem)
        {
            this.ProductId = responseEstimatesPricesItem.product_id;
            this.CurrencyCode = responseEstimatesPricesItem.currency_code;
            this.DisplayName = responseEstimatesPricesItem.display_name;
            this.Estimate = responseEstimatesPricesItem.estimate;
            this.LowEstimate = (int)responseEstimatesPricesItem.low_estimate;
            this.HighEstimate = (int)responseEstimatesPricesItem.high_estimate;
        }
    }
}
