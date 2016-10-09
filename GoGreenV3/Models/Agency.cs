using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoGreenV3.Models
{
    public class Agency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Agency Type")]
        public string Type { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Up to {0} characters only allowed")]
        [Display(Name = "Agency")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> Hospitals { get; set; }


        public IEnumerable<SelectListItem> PoliceDepartments { get; set; }


        public IEnumerable<SelectListItem> FireStations { get; set; }


        [StringLength(250, ErrorMessage = "Up to {0} characters only allowed")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }

        [StringLength(maximumLength: 1000, ErrorMessage = "Up to {0} characters only allowed")]
        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string WebsiteUrl { get; set; }

        [RegularExpression(pattern: "^[0-9]*$", ErrorMessage = "{0} must only be numbers")]
        public string Contact { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class AgencyDbContext : DbContext
    {
        public AgencyDbContext() : base ("AgencyConnection")
        { }

        public System.Data.Entity.DbSet<GoGreenV3.Models.Agency> Agencies { get; set; }
    }
}