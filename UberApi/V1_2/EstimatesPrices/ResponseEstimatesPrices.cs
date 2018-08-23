using System;
using System.Collections.Generic;
using System.Text;

namespace UberApi.V1_2
{
    /// <summary>
    /// https://developer.uber.com/docs/riders/references/api/v1.2/estimates-price-get#response
    /// </summary>
    public class ResponseEstimatesPrices
    {
        public List<ResponseEstimatesPricesItem> prices { get; set; }
    }

    public class ResponseEstimatesPricesItem
    {        
        /// <summary>
        /// Unique identifier representing a specific product for a given latitude & longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles.
        /// </summary>
        public string product_id { get; set; }

        /// <summary>
        /// ISO 4217 currency code.
        /// </summary>
        public string currency_code { get; set; }

        /// <summary>
        /// Display name of product.
        /// </summary>
        public string display_name { get; set; }

        /// <summary>
        /// Localized display name of product.
        /// </summary>
        public string localized_display_name { get; set; }

        /// <summary>
        /// Formatted string of estimate in local currency of the start location. Estimate could be a range, a single number (flat rate) or “Metered” for TAXI.
        /// </summary>
        public string estimate { get; set; }

        /// <summary>
        /// Minimum price for product.
        /// </summary>
        public int minimum { get; set; }

        /// <summary>
        /// Lower bound of the estimated price.
        /// </summary>
        public float low_estimate { get; set; }

        /// <summary>
        /// Upper bound of the estimated price.
        /// </summary>
        public float high_estimate { get; set; }

        /// <summary>
        /// Expected surge multiplier. Surge is active if surge_multiplier is greater than 1. Price estimate already factors in the surge multiplier.
        /// </summary>
        public float surge_multiplier { get; set; }

        /// <summary>
        /// Expected activity duration (in seconds). Always show duration in minutes.
        /// </summary>
        public int duration { get; set; }

        /// <summary>
        /// Expected activity distance (in miles).
        /// </summary>
        public float distance { get; set; }   
    }
}
