using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Playground
    {
        public int EquipId { get; set; }
        public string Type { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string? Location { get; set; }
        public DateOnly? InstallDate { get; set; }
    }
}
