using System.ComponentModel.DataAnnotations;

namespace TrashHandling.Models
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        [Display(Name = "Name")]
        public string ShopName { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        [Display(Name = "Address")]
        public string ShopAddress { get; set; }
        [Required]
        [Display(Name = "Contact")]
        public int ShopContact { get; set; }
    }
}
