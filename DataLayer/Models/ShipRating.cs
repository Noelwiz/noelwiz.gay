using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class ShipRating
    {
        public int Ship { get; set; }
        public string Rater { get; set; } = null!;
        public int Rating { get; set; }

        public virtual Owner RaterNavigation { get; set; } = null!;
        public virtual Ship ShipNavigation { get; set; } = null!;
    }
}
