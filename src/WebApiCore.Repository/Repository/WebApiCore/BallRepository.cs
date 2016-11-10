using WebApiCore.DomainModel.WebApiCore;

namespace WebApiCore.Repository.Repository.WebApiCore
{
    public class BallRepository : RepositoryBase<BallEntity, int>, IBallRepository
    {
        public string Hello()
        {
            return "Hello from ryan";
        }
    }
}