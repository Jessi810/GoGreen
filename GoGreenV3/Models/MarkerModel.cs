using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoGreenV3.Models
{
    public class MarkerModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Up to {0} characters only allowed")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Controllable?")]
        public bool IsControllable { get; set; }

        [Display(Name = "Working?")]
        public bool IsWorking { get; set; }
    }

    public class MarkerDbContext : DbContext
    {
        public MarkerDbContext() : base ("MarkerConnection")
        {

        }

        public System.Data.Entity.DbSet<GoGreenV3.Models.MarkerModel> Markers { get; set; }
    }
}