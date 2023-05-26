package org.example.repository;


import org.example.model.Concert;

import java.time.LocalDate;
import java.util.Collection;

public interface ConcertRepository extends Repository<Integer, Concert>{

    Collection<Concert> getConcertsByDate(String date);

    Integer updateConcertTickets(Integer id,Integer newTicketsAvailable,Integer newTicketsSold);

    Concert getConcertByDateLocationStart(String data,String Location,String startTime);
}
