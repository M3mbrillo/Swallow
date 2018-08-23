using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwallowCore.Models
{
    public partial class MapMarker
    {
        public MapMarker()
        {
            TravelRoadArrivalMapMarker = new HashSet<TravelRoad>();
            TravelRoadOriginMapMarker = new HashSet<TravelRoad>();
        }

        public int Id { get; set; }
        [Column("User_Id")]
        public int UserId { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal? Longitude { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("MapMarker")]
        public User User { get; set; }
        [InverseProperty("ArrivalMapMarker")]
        public ICollection<TravelRoad> TravelRoadArrivalMapMarker { get; set; }
        [InverseProperty("OriginMapMarker")]
        public ICollection<TravelRoad> TravelRoadOriginMapMarker { get; set; }
    }
}
