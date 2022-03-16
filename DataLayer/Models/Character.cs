using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Character
    {
        public Character()
        {
            ShipCharacter1Navigations = new HashSet<Ship>();
            ShipCharacter2Navigations = new HashSet<Ship>();
        }

        public string Name { get; set; } = null!;
        public string? Race { get; set; }
        public string? Description { get; set; }
        public string? Owner { get; set; }
        public int Id { get; set; }

        public virtual Owner? OwnerNavigation { get; set; }
        public virtual ICollection<Ship> ShipCharacter1Navigations { get; set; }
        public virtual ICollection<Ship> ShipCharacter2Navigations { get; set; }
    }
}
