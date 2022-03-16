using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Ship
    {
        public Ship()
        {
            ShipRatings = new HashSet<ShipRating>();
        }

        public int Id { get; set; }
        public int? Character1 { get; set; }
        public int? Character2 { get; set; }

        public virtual Character? Character1Navigation { get; set; }
        public virtual Character? Character2Navigation { get; set; }
        public virtual ICollection<ShipRating> ShipRatings { get; set; }
    }
}
