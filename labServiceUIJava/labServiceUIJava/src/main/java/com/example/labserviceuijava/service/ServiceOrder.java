package com.example.labserviceuijava.service;

import com.example.labserviceuijava.model.Order;
import com.example.labserviceuijava.repository.OrderDBRepository;
import com.example.labserviceuijava.repository.exceptions.RepositoryException;
import com.example.labserviceuijava.validator.OrderValidator;
import com.example.labserviceuijava.validator.ValidationException;

public class ServiceOrder {

    private final OrderDBRepository orderDBRepository;

    private final OrderValidator orderValidator;

    public ServiceOrder(OrderDBRepository orderDBRepository, OrderValidator orderValidator) {
        this.orderDBRepository = orderDBRepository;
        this.orderValidator = orderValidator;
    }

    public Order save(Integer concertID,String buyerName, Integer numberOfTickets){
        Order order=new Order(0,concertID,buyerName,numberOfTickets);
        try{
            orderValidator.validate(order);
        }catch(ValidationException validationException){
            System.out.println(validationException);
        }
        return orderDBRepository.save(order);
    }
}
