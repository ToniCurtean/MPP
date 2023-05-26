package com.example.labserviceuijava.service;

public class Service {

    private final ServiceArtist serviceArtist;

    private final ServiceCashier serviceCashier;

    private final ServiceConcert serviceConcert;

    private final ServiceOrder serviceOrder;

    public Service(ServiceArtist serviceArtist, ServiceCashier serviceCashier, ServiceConcert serviceConcert, ServiceOrder serviceOrder) {
        this.serviceArtist = serviceArtist;
        this.serviceCashier = serviceCashier;
        this.serviceConcert = serviceConcert;
        this.serviceOrder = serviceOrder;
    }

    public ServiceArtist getServiceArtist() {
        return serviceArtist;
    }

    public ServiceCashier getServiceCashier() {
        return serviceCashier;
    }

    public ServiceConcert getServiceConcert() {
        return serviceConcert;
    }

    public ServiceOrder getServiceOrder() {
        return serviceOrder;
    }
}
