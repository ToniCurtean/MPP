using WindowsFormsApp2.model;

namespace WindowsFormsApp2.repository
{
    public interface ICashiersRepository:IRepository<int,Cashier>
    {
        Cashier getCashierByUsernamePassword(string username, string password);
    }
}