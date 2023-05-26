package org.example.repository;


import org.example.model.Cashier;

public interface CashierRepository extends Repository<Integer, Cashier>{

    Cashier getCashierByUserPassword(String username,String password);

}
