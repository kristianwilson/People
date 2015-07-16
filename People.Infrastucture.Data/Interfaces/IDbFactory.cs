namespace People.Infrastucture.Data.Interfaces
{
    public interface IDbFactory
    {
        IDatabase GetDatabase();
    }
}
