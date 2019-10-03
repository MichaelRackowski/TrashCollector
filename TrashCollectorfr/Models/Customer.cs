using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollectorfr.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetName { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }

        [Display(Name = "Balance")]
        public string Balence { get; }

        [Display(Name = "Extra Pick Up Date")]
        public string ExtraDay { get; set; }
      
        [Display(Name = "Start Date For Suspension")]
        public string StartDay { get; set; }
       
        [Display(Name = "End Date For Suspension")]
        public string EndDay { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Day")]
        [Display(Name = "Pick Up Day")]
        public int DayId { get; set; }
        public Day Day { get; set; }

        public IEnumerable<Day> Days { get; set; }




    }
}
