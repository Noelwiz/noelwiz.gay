using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Characters = new HashSet<Character>();
            ShipRatings = new HashSet<ShipRating>();
        }

        public string DiscordUser { get; set; } = null!;

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<ShipRating> ShipRatings { get; set; }
    }
}
