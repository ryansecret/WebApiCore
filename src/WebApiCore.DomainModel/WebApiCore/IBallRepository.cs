namespace WebApiCore.DomainModel.WebApiCore
{
     
    public interface IBallRepository: IRepository<BallEntity, int>
    {
        string Hello();
    }
}
