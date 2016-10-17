using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoGreenV3.Models
{
    public class BackupReport
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Maximum of {0} characters only")]
        public string Address { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum of {0} characters only")]
        public string Status { get; set; }
    }

    public class EmergencyReport
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Maximum of {0} characters only")]
        public string Address { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum of {0} characters only")]
        public string EmergencyType { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum of {0} characters only")]
        public string EmergencyStatus { get; set; }
    }

    public class ReinforcementReport
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Maximum of {0} characters only")]
        public string Address { get; set; }

        [Required]
        public int ReinforcementCount { get; set; }

        [Required]
        public int VehicleCount { get; set; }
    }

    public class ReportDbContext : DbContext
    {
        public ReportDbContext() : base("ReportConnection") { }

        public DbSet<BackupReport> Backups { get; set; }
        public DbSet<EmergencyReport> Emergencies { get; set; }
        public DbSet<ReinforcementReport> Reinforcements { get; set; }
    }
}