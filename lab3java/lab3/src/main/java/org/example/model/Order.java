package org.example.model;

import java.util.Objects;

public class Order extends Entity<Integer>{

    private Integer concertId;
    private Integer buyerId;
    private Integer numberOfTickets;


    public Order(Integer integer, Integer concertId, Integer buyerId, Integer numberOfTickets) {
        super(integer);
        this.concertId = concertId;
        this.buyerId = buyerId;
        this.numberOfTickets = numberOfTickets;
    }

    public Integer getConcertId() {
        return concertId;
    }

    public void setConcertId(Integer concertId) {
        this.concertId = concertId;
    }

    public Integer getBuyerId() {
        return buyerId;
    }

    public void setBuyerId(Integer buyerId) {
        this.buyerId = buyerId;
    }

    public Integer getNumberOfTickets() {
        return numberOfTickets;
    }

    public void setNumberOfTickets(Integer numberOfTickets) {
        this.numberOfTickets = numberOfTickets;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Order order = (Order) o;
        return concertId.equals(order.concertId) && buyerId.equals(order.buyerId) && numberOfTickets.equals(order.numberOfTickets);
    }

    @Override
    public int hashCode() {
        return Objects.hash(concertId, buyerId, numberOfTickets);
    }
}
