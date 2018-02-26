using System.ComponentModel.DataAnnotations;

namespace XYC.Models.Sample{
    public class PointOfInterestForUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}