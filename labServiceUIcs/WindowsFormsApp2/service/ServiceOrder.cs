using System.Management.Instrumentation;
using WindowsFormsApp2.model;
using WindowsFormsApp2.repository;

namespace WindowsFormsApp2
{
    public class ServiceOrder
    {
        private OrdersDBRepository ordersDbRepository;

        public ServiceOrder(OrdersDBRepository ordersDbRepository)
        {
            this.ordersDbRepository = ordersDbRepository;
        }

        public Order save(int concertID, string buyerName, int numberOfTickets)
        {
            Order order = new Order(0, concertID, buyerName, numberOfTickets);
            return this.ordersDbRepository.Save(order);
        }
    }
}