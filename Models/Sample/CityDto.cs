using System.Collections;
using System.Collections.Generic;

namespace XYC.Models.Sample
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public int NumberOfPointsOfInterest { get; set; }
        public ICollection<PointOfInterestDto> PointOfInterest { get; set; }
    }
}