using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashHandling.Models.Entities
{
    public class TrashBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TypeofTrash { get; set; }
        public int Weight { get; set; }
        public string Location { get; set; }
        public DateTime BookDate { get; set; }
    }

}
