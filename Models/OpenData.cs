using System;
using System.ComponentModel.DataAnnotations;

namespace OceanographyManager.Models
{
    public class OceanData
    {
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; } // Legătura cu utilizatorul

        [Required]
        [Display(Name = "Data Collection Date")]
        public DateTime CollectionDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Location Name")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public decimal Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        public decimal Longitude { get; set; }

        [Required]
        [Display(Name = "Temperature (°C)")]
        [Range(-2, 40, ErrorMessage = "Temperature must be between -2°C and 40°C")]
        public decimal Temperature { get; set; }

        [Required]
        [Display(Name = "Salinity (PSU)")]
        [Range(0, 50, ErrorMessage = "Salinity must be between 0 and 50 PSU")]
        public decimal Salinity { get; set; }

        [Display(Name = "pH Level")]
        [Range(0, 14, ErrorMessage = "pH must be between 0 and 14")]
        public decimal? PH { get; set; }

        [Display(Name = "Dissolved Oxygen (mg/L)")]
        [Range(0, 20, ErrorMessage = "Dissolved oxygen must be between 0 and 20 mg/L")]
        public decimal? DissolvedOxygen { get; set; }

        [Display(Name = "Additional Notes")]
        public string Notes { get; set; }
    }
}
