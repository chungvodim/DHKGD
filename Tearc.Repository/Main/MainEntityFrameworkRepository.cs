namespace Tearc.Repository.Main
{
    public class MainEntityFrameworkRepository : Tearc.Utils.Repository.EntityFramework.Repository
    {
        public MainEntityFrameworkRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}
