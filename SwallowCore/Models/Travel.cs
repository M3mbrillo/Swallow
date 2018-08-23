using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwallowCore.Models
{
    public partial class Travel
    {
        public Travel()
        {
            TravelRoad = new HashSet<TravelRoad>();
        }

        public int Id { get; set; }
        [Column("User_Id")]
        public int UserId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Travel")]
        public User User { get; set; }
        [InverseProperty("Travel")]
        public ICollection<TravelRoad> TravelRoad { get; set; }
    }
}
