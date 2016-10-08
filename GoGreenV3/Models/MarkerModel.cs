using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoGreenV3.Models
{
    public class MarkerModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public string Status { get; set; }


        public string Location { get; set; }


        public string Description { get; set; }


        public bool IsControllable { get; set; }


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