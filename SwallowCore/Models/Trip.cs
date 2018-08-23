using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwallowCore.Models
{
    public partial class Trip
    {
        public Trip()
        {
            EstimatePrice = new HashSet<EstimatePrice>();
        }

        public int Id { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal OriginLatitude { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal OriginLongitude { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal ArrivalLatitude { get; set; }
        [Column(TypeName = "decimal(8, 6)")]
        public decimal ArrivalLongitude { get; set; }

        [InverseProperty("Trip")]
        public ICollection<EstimatePrice> EstimatePrice { get; set; }
    }
}
