using TrashHandling.Data;
using TrashHandling.Models.Entities;
using TrashHandling.RepoPattern;

namespace TrashHandling.Models.Repositories
{
    public class FacilityRepo : CommonRP<Facility>, IFacilityRepo
    {
        public FacilityRepo(PatientConsultAuthDBContext dbContext) : base(dbContext)
        {
        }
    }
}
