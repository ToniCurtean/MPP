package org.example.model;

import java.util.Objects;

public class Buyer extends Entity<Integer>{


    private String name;
    private String email;
    private String phoneNumber;

    public Buyer(Integer integer,String name,String email,String phoneNumber) {
        super(integer);
        this.name=name;
        this.email=email;
        this.phoneNumber=phoneNumber;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Buyer buyer = (Buyer) o;
        return name.equals(buyer.name);
    }

    @Override
    public int hashCode() {
        return Objects.hash(name);
    }
}
