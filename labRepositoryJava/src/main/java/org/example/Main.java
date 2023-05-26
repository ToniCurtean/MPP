package org.example;

import org.example.model.Artist;
import org.example.repository.ArtistDBRepository;
import org.example.repository.CashierDBRepository;
import org.example.repository.ConcertDBRepository;
import org.example.repository.OrderDBRepository;

import java.io.FileReader;
import java.io.IOException;
import java.util.Properties;

public class Main {


    public static void main(String[] args) {

        Properties properties=new Properties();
        try{
            properties.load(new FileReader("D:\\faculta\\anun2\\SEM2\\MPP\\laborator\\labRepositoryJava\\bd.config"));
        }catch(IOException e){
            System.out.println("Cannot find bd.config"+e);
        }

        ArtistDBRepository artistRepository =new ArtistDBRepository(properties);
        CashierDBRepository cashierRepository=new CashierDBRepository(properties);
        ConcertDBRepository concertRepository=new ConcertDBRepository(properties);
        OrderDBRepository orderRepository=new OrderDBRepository(properties);


        for(Artist artist: artistRepository.findAll())
            System.out.println(artist.getName()+" "+artist.getMusicType());

    }
}