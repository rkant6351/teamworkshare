﻿using System;
using System.Collections.Generic;

namespace WebApiDBFirstCaseStudyTRY1.Models
{
    public partial class Administrator
    {
        public int AdminId { get; set; }
        public string AdminEmail { get; set; } = null!;
        public string AdminFullName { get; set; } = null!;
        public string AdminPhoneNumber { get; set; } = null!;
        public string AdminPassword { get; set; } = null!;
    }
}
