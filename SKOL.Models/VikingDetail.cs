﻿using SKOL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKOL.Models
{
    public class VikingDetail
    {
        [Display(Name = "Viking Name")]
        public string Name { get; set; }
        [Display(Name = "Your Occupation")]
        public Job Job { get; set; }
        [Display(Name = "Your Kingdom")]
        public string Kingdom { get; set; }
    }
}
