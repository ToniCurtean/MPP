package com.example.labserviceuijava.validator;

import com.example.labserviceuijava.model.Artist;

import java.util.Objects;

public class ArtistValidator implements Validator<Artist> {
    @Override
    public void validate(Artist entity) throws ValidationException {
        String message = "";
        if (entity.getId() == null)
            message += "The ID can't be null";
        if (Objects.equals(entity.getName(), ""))
            message += " The name can't be null";
        if (Objects.equals(entity.getMusicType(), ""))
            message += " The music type can't be null";
        if (message.length() != 0)
            throw new ValidationException(message);
    }
}
