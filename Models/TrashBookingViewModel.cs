using System.ComponentModel.DataAnnotations;

namespace TrashHandling.Models
{
    public class TrashBookingViewModel
    {
        public int Id { get; set; }
        public string TypeofTrash { get; set; }
        public int Weight { get; set; }
        public string Location { get; set; }
        public DateTime BookDate { get; private set; } = DateTime.Now;
    }
}
