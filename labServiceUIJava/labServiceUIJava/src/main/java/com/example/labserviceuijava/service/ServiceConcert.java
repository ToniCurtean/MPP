package com.example.labserviceuijava.service;

import com.example.labserviceuijava.model.Concert;
import com.example.labserviceuijava.repository.ConcertDBRepository;
import com.example.labserviceuijava.repository.exceptions.RepositoryException;
import com.example.labserviceuijava.validator.ConcertValidator;

import java.util.Collection;

public class ServiceConcert {

    private final ConcertDBRepository concertDBRepository;

    private final ConcertValidator concertValidator;

    public ServiceConcert(ConcertDBRepository concertDBRepository, ConcertValidator concertValidator) {
        this.concertDBRepository = concertDBRepository;
        this.concertValidator = concertValidator;
    }

    public Iterable<Concert> findAll() {
        return concertDBRepository.findAll();
    }

    public Collection<Concert> getConcertsByDate(String date){
        return concertDBRepository.getConcertsByDate(date);
    }

    public void updateConcertTickets(Integer id, Integer numberOfTickets){
        Concert concert=concertDBRepository.findOne(id);
        int newTicketsAvailable=concert.getTicketsAvailable()-numberOfTickets;
        int newTicketsSold=concert.getTicketsSold()+numberOfTickets;
        concertDBRepository.updateConcertTickets(id,newTicketsAvailable,newTicketsSold);
    }

    public Concert getConcertByDateLocationStart(String date,String location,String startTime){
        return concertDBRepository.getConcertByDateLocationStart(date,location,startTime);
    }

}
