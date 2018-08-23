using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwallowCore.Models
{
    public partial class TravelRoad
    {
        [Column("User_Id")]
        public int UserId { get; set; }
        [Column("Travel_Id")]
        public int TravelId { get; set; }
        [Column("OriginMapMarker_Id")]
        public int OriginMapMarkerId { get; set; }
        [Column("ArrivalMapMarker_Id")]
        public int ArrivalMapMarkerId { get; set; }

        [ForeignKey("ArrivalMapMarkerId")]
        [InverseProperty("TravelRoadArrivalMapMarker")]
        public MapMarker ArrivalMapMarker { get; set; }
        [ForeignKey("OriginMapMarkerId")]
        [InverseProperty("TravelRoadOriginMapMarker")]
        public MapMarker OriginMapMarker { get; set; }
        [ForeignKey("TravelId")]
        [InverseProperty("TravelRoad")]
        public Travel Travel { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("TravelRoad")]
        public User User { get; set; }
    }
}
