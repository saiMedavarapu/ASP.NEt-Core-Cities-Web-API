using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityDetails.Models
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPointsOfInterest { get {
                return PointsOfInterest.Count;
            }
        } 

        public ICollection<PointOfInterest> PointsOfInterest = new List<PointOfInterest>();
    }
}
