using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashHandling.Models.Entities
{
    public class Shop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public int ShopContact { get; set; }
    }
}
