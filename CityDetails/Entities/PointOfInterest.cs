using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CityDetails.Models;

namespace CityDetails.Entities
{
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; } //To navigate from point of interest to parent city.

       public string Description { get; set; }

        public int CityId { get; set; }
       // public string Description { get; internal set; }
    }
}
