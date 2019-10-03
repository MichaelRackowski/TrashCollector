using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollectorfr.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Day")]
        public string DayOfWeek { get; set; }
    }
}