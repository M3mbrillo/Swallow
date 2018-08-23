using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwallowCore.Models
{
    public partial class User
    {
        public User()
        {
            MapMarker = new HashSet<MapMarker>();
            Travel = new HashSet<Travel>();
            TravelRoad = new HashSet<TravelRoad>();
        }

        public int Id { get; set; }
        [StringLength(200)]
        public string UserName { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Name { get; set; }

        [InverseProperty("User")]
        public ICollection<MapMarker> MapMarker { get; set; }
        [InverseProperty("User")]
        public ICollection<Travel> Travel { get; set; }
        [InverseProperty("User")]
        public ICollection<TravelRoad> TravelRoad { get; set; }
    }
}
