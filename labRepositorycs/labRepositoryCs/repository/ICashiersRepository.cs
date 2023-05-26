using labRepositoryCs.model;

namespace labRepositoryCs.repository
{
    public interface ICashiersRepository:IRepository<int,Cashier>
    {
        Cashier getCashierByUsernamePassword(string username, string password);
    }
}