namespace Tearc.Repository.Log
{
    public class LogEntityFrameworkRepository : Tearc.Utils.Repository.EntityFramework.Repository
    {
        public LogEntityFrameworkRepository(LogContext dbContext) : base(dbContext)
        {
        }
    }
}
