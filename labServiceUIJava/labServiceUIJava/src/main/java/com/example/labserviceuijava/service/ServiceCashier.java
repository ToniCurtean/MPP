package com.example.labserviceuijava.service;

import com.example.labserviceuijava.model.Cashier;
import com.example.labserviceuijava.repository.CashierDBRepository;
import com.example.labserviceuijava.repository.exceptions.RepositoryException;
import com.example.labserviceuijava.validator.CashierValidator;

public class ServiceCashier {

    private final CashierDBRepository cashierDBRepository;

    private final CashierValidator cashierValidator;

    public ServiceCashier(CashierDBRepository cashierDBRepository, CashierValidator cashierValidator) {
        this.cashierDBRepository = cashierDBRepository;
        this.cashierValidator = cashierValidator;
    }

    public boolean getCashierByUserPassword(String username, String password){
        Cashier cashier=cashierDBRepository.getCashierByUserPassword(username,password);
        return cashier!=null;
    }

}
