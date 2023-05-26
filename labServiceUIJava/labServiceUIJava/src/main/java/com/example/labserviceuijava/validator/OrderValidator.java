package com.example.labserviceuijava.validator;

import com.example.labserviceuijava.model.Order;

import java.util.Objects;

public class OrderValidator implements Validator<Order> {

    @Override
    public void validate(Order entity) throws ValidationException {
        String message = "";
        if (entity.getId() == null)
            message += "ID can't be null";
        if (entity.getConcertId() == null)
            message += "Concert id can't be null";
        if (Objects.equals(entity.getBuyerName(), ""))
            message += "Buyer name can't be empty";
        if (entity.getNumberOfTickets() == null)
            message += "Number of tickets can't be null";
        if (entity.getNumberOfTickets() <= 0)
            message += "Number of tickets need to be greater then 0";
        if (message.length() != 0)
            throw new ValidationException(message);
    }
}