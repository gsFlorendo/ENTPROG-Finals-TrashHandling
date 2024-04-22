using System.ComponentModel.DataAnnotations;

namespace TrashHandling.Models
{
    public class FacilityViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        [Display(Name = "Name")]
        public string FacilityName { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        [Display(Name = "Address")]
        public string FacilityAddress { get; set; }
    }
}
