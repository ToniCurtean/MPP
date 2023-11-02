package org.example;

import org.example.jdbc.ArtistDBRepository;
import org.example.jdbc.CashierDBRepository;
import org.example.jdbc.ConcertDBRepository;
import org.example.jdbc.OrderDBRepository;
import org.example.utils.AbstractServer;
import org.example.utils.FestivalRpcConcurrentServer;

import java.io.IOException;
import java.util.Properties;

public class StartRpcServer {
    public static void main(String[] args) {
        Properties serverProps=new Properties();
        try {
            serverProps.load(StartRpcServer.class.getResourceAsStream("/festivalserver.properties"));
            System.out.println("Server properties set. ");
            serverProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find festivalserver.properties "+e);
            return;
        }
        CashierDBRepository cashierDBRepository=new CashierDBRepository(serverProps);
        ArtistDBRepository artistDBRepository=new ArtistDBRepository(serverProps);
        ConcertDBRepository concertDBRepository=new ConcertDBRepository(serverProps);
        OrderDBRepository orderDBRepository=new OrderDBRepository(serverProps);

        IFestivalService atlServerImpl=new FestivalServicesImpl(artistDBRepository,cashierDBRepository,concertDBRepository,orderDBRepository);
        int defaultPort = 55555;
        int atletismServerPort= defaultPort;
        try {
            atletismServerPort = Integer.parseInt(serverProps.getProperty("festival.server.port"));
        }catch (NumberFormatException nef){
            System.err.println("Wrong  Port Number"+nef.getMessage());
            System.err.println("Using default port "+ defaultPort);
        }
        System.out.println("Starting server on port: "+atletismServerPort);
        AbstractServer server = new FestivalRpcConcurrentServer(atletismServerPort, atlServerImpl);
        try {
            server.start();
        } catch (org.example.utils.ServerException e) {
            throw new RuntimeException(e);
        } finally {
            try {
                server.stop();
            } catch (org.example.utils.ServerException e) {
                throw new RuntimeException(e);
            }
        }
    }
}