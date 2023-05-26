package com.example.labserviceuijava.validator;

public interface Validator<T>{
    void validate(T entity) throws ValidationException;
}
