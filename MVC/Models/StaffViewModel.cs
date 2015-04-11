﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MVC.Models
{
    public class StaffViewModel 
    {
        // Display Attribute will appear in the Html.LabelFor
        [Display(Name = "Staff Members")]
        public int SelecteStaff { get; set; }
        public IEnumerable<SelectListItem> StaffMembers { get; set; }
    }
}