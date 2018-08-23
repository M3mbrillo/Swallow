using System;
using System.Collections.Generic;
using System.Text;
using UberApi.V1_2;

namespace SwallowCore.Models
{
    public partial class Trip
    {
        public RequestEstimatesPrices ToRequestEstimatesPrices()
        {
            var rep = new RequestEstimatesPrices();

            rep.start_latitude = (float)this.OriginLatitude;
            rep.end_latitude = (float)this.ArrivalLatitude;
            rep.start_longitude = (float)this.OriginLongitude;
            rep.end_longitude= (float)this.ArrivalLongitude;

            return rep;
        }
    }
}
