using WindowsFormsApp2.model;
using WindowsFormsApp2.repository;

namespace WindowsFormsApp2
{
    public class ServiceCashier
    {
        private CashiersDBRepository cashiersDbRepository;

        public ServiceCashier(CashiersDBRepository cashiersDbRepository)
        {
            this.cashiersDbRepository = cashiersDbRepository;
        }

        public int getCashierByUserPassword(string username, string password)
        {
            Cashier cashier = cashiersDbRepository.getCashierByUsernamePassword(username, password);
            if (cashier == null)
                return -1;
            return 1;
        }
    }
}