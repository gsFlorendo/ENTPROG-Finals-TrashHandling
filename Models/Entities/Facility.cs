using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashHandling.Models.Entities
{
    public class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
    }
}
