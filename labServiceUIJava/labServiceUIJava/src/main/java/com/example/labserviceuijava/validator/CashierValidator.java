package com.example.labserviceuijava.validator;

import com.example.labserviceuijava.model.Cashier;

import java.util.Objects;

public class CashierValidator implements Validator<Cashier> {

    @Override
    public void validate(Cashier entity) throws ValidationException {
        String message = "";
        if (entity.getId() == null)
            message += "Id can't be null";
        if (Objects.equals(entity.getUsername(), ""))
            message += " Username can't be null";
        if (Objects.equals(entity.getPassword(), ""))
            message += " Password can't be null";
        if (message.length() != 0)
            throw new ValidationException(message);
    }
}
