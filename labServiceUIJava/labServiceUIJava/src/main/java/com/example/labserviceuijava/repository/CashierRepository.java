package com.example.labserviceuijava.repository;

import com.example.labserviceuijava.model.Cashier;

public interface CashierRepository extends Repository<Integer, Cashier>{

    Cashier getCashierByUserPassword(String username,String password);

}
