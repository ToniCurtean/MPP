package com.example.labserviceuijava.validator;

import com.example.labserviceuijava.model.Concert;

import java.util.Objects;

public class ConcertValidator implements Validator<Concert> {
    @Override
    public void validate(Concert entity) throws ValidationException {
        String message = "";
        if (entity.getId() == null)
            message += "ID can't be null";
        if (Objects.equals(entity.getConcertDate(), ""))
            message += " Concert date can't be empty";
        if (Objects.equals(entity.getConcertLocation(), ""))
            message += " Concert location can't be empty";
        if (entity.getTicketsAvailable() == null)
            message += " Tickets available can't be null";
        if (entity.getTicketsAvailable() < 0)
            message += "Tickets available can't be lesser then 0";
        if (entity.getTicketsSold() == null)
            message += " Tickets sold can't be null";
        if (entity.getArtistId() == null)
            message += " Artist id can't be null";
        if (message.length() != 0)
            throw new ValidationException(message);
    }
}
