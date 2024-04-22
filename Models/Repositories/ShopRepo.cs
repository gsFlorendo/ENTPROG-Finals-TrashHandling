using TrashHandling.Data;
using TrashHandling.Models.Entities;
using TrashHandling.RepoPattern;

namespace TrashHandling.Models.Repositories
{
    public class ShopRepo : CommonRP<Shop>, IShopRepo
    {
        public ShopRepo(PatientConsultAuthDBContext dbContext) : base(dbContext)
        {
        }
    }
}
