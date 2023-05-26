package com.example.labserviceuijava.repository;

import com.example.labserviceuijava.model.Entity;

public interface Repository<ID, E extends Entity<ID>> {

    E findOne(ID id);

    Iterable<E> findAll();

    E save(E entity);

    E delete(ID id);


    E update(E entity);

}