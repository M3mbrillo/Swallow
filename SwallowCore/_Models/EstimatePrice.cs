using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwallowCore.Models
{
    public partial class EstimatePrice
    {
        [Column(TypeName = "datetime")]
        public DateTime StartDateTime { get; set; }
        [Column("Trip_Id")]
        public int TripId { get; set; }
        [StringLength(200)]
        public string ProductId { get; set; }
        [StringLength(200)]
        public string DisplayName { get; set; }
        [Required]
        [StringLength(20)]
        public string Estimate { get; set; }
        [Required]
        [StringLength(20)]
        public string CurrencyCode { get; set; }
        public int LowEstimate { get; set; }
        public int HighEstimate { get; set; }
        public int Duration { get; set; }

        [ForeignKey("TripId")]
        [InverseProperty("EstimatePrice")]
        public Trip Trip { get; set; }
    }
}
