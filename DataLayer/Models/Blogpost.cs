﻿using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Blogpost
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
    }
}
