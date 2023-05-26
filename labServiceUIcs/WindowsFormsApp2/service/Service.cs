namespace WindowsFormsApp2
{
    public class Service
    {
        private ServiceArtist serviceArtist;

        private ServiceCashier serviceCashier;

        private ServiceConcert serviceConcert;

        private ServiceOrder serviceOrder;

        public Service(ServiceArtist serviceArtist, ServiceCashier serviceCashier, ServiceConcert serviceConcert,
            ServiceOrder serviceOrder)
        {
            this.serviceArtist = serviceArtist;
            this.serviceCashier = serviceCashier;
            this.serviceConcert = serviceConcert;
            this.serviceOrder = serviceOrder;
        }

        public ServiceArtist ServiceArtist
        {
            get { return serviceArtist; }
        }

        public ServiceCashier ServiceCashier
        {
            get { return serviceCashier; }
        }

        public ServiceConcert ServiceConcert
        {
            get { return serviceConcert; }
        }

        public ServiceOrder ServiceOrder
        {
            get { return serviceOrder; }
        }
    }
}