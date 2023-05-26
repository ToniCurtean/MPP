using model;

namespace persistence
{
    public interface ICashierRepository:IRepository<int,Cashier>
    {
        Cashier GetCashierByUserPassword(string username, string password);
    }
}