using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UberApi.V1_2
{
    /// <summary>
    /// https://developer.uber.com/docs/riders/references/api/v1.2/estimates-price-get#query-parameters
    /// </summary>
    public class RequestEstimatesPrices : IModelRequestGet
    {

        public string Uri => "/v1.2/estimates/price";

        public string ToUriParameters()
        {
            return $"start_latitude={this.start_latitude.ToString(CultureInfo.GetCultureInfo("en-US"))}&" +
                   $"start_longitude={this.start_longitude.ToString(CultureInfo.GetCultureInfo("en-US"))}&" +
                   $"end_latitude={this.end_latitude.ToString(CultureInfo.GetCultureInfo("en-US"))}&" +
                   $"end_longitude={this.end_longitude.ToString(CultureInfo.GetCultureInfo("en-US"))}";
        }

        /// <summary>
        /// Latitude component of start location.
        /// </summary>
        public float start_latitude { get; set; }

        /// <summary>
        /// Longitude component of start location.
        /// </summary>
        public float start_longitude { get; set; }

        /// <summary>
        /// Latitude component of end location.
        /// </summary>
        public float end_latitude { get; set; }

        /// <summary>
        /// Longitude component of end location.
        /// </summary>
        public float end_longitude { get; set; }

        /// <summary>
        /// (optional) The number of seats required for uberPOOL.Default and maximum value is 2.
        /// </summary>
        public int? seat_count { get; set; }        
    }
}
