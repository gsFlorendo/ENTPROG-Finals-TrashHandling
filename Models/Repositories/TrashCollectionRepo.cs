using TrashHandling.Data;
using TrashHandling.Models.Entities;
using TrashHandling.RepoPattern;

namespace TrashHandling.Models.Repositories
{
    public class TrashCollectionRepo : CommonRP<TrashCollection>, ITrashCollectionRepo
    {
        public TrashCollectionRepo(PatientConsultAuthDBContext dbContext) : base(dbContext)
        {
        }
    }
}
