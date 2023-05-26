package org.example.model;

public class Cashier extends Entity<Integer>{

    private String username;
    private String password;

    public Cashier(String username,String password,Integer integer) {
        super(integer);
        this.username=username;
        this.password=password;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
