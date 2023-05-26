package org.example.model;

import java.time.LocalDate;
import java.util.Objects;

public class Concert extends Entity<Integer>{

    private LocalDate concertDate;
    private String concertLocation;
    private Integer ticketsAvailable;
    private Integer ticketsSold;

    private Integer artistId;

    public Concert(Integer integer,LocalDate concertDate, String concertLocation, Integer ticketsAvailable, Integer ticketsSold,Integer artistId) {
        super(integer);
        this.concertDate = concertDate;
        this.concertLocation = concertLocation;
        this.ticketsAvailable = ticketsAvailable;
        this.ticketsSold = ticketsSold;
        this.artistId=artistId;
    }

    public LocalDate getConcertDate() {
        return concertDate;
    }

    public void setConcertDate(LocalDate concertDate) {
        this.concertDate = concertDate;
    }

    public String getConcertLocation() {
        return concertLocation;
    }

    public void setConcertLocation(String concertLocation) {
        this.concertLocation = concertLocation;
    }

    public Integer getTicketsAvailable() {
        return ticketsAvailable;
    }

    public void setTicketsAvailable(Integer ticketsAvailable) {
        this.ticketsAvailable = ticketsAvailable;
    }

    public Integer getTicketsSold() {
        return ticketsSold;
    }

    public void setTicketsSold(Integer ticketsSold) {
        this.ticketsSold = ticketsSold;
    }


    public Integer getArtistId() {
        return artistId;
    }

    public void setArtistId(Integer artistId) {
        this.artistId = artistId;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Concert concert = (Concert) o;
        return concertDate.equals(concert.concertDate) && concertLocation.equals(concert.concertLocation);
    }

    @Override
    public int hashCode() {
        return Objects.hash(concertDate, concertLocation);
    }
}
