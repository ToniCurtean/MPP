package org.example;

import org.example.hib.OrderHBRepository;
import org.example.jdbc.ArtistDBRepository;
import org.example.jdbc.CashierDBRepository;
import org.example.jdbc.ConcertDBRepository;
import org.example.utils.AbstractServer;
import org.example.utils.FestivalRpcConcurrentServer;
import org.hibernate.SessionFactory;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

import java.io.IOException;
import java.util.Properties;

public class StartRpcServer {
    public static void main(String[] args) {
        Properties serverProps=new Properties();
        try {
            serverProps.load(StartRpcServer.class.getResourceAsStream("/chatserver.properties"));
            System.out.println("Server properties set. ");
            serverProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find chatserver.properties "+e);
            return;
        }

            CashierDBRepository cashierDBRepository=new CashierDBRepository(serverProps);
            ArtistDBRepository artistDBRepository=new ArtistDBRepository(serverProps);
            ConcertDBRepository concertDBRepository=new ConcertDBRepository(serverProps);
            OrderHBRepository orderHBRepository=new OrderHBRepository();

        IFestivalService atlServerImpl=new FestivalServicesImpl(artistDBRepository,cashierDBRepository,concertDBRepository,orderHBRepository);
        int defaultPort = 55555;
        int atletismServerPort= defaultPort;
        try {
            atletismServerPort = Integer.parseInt(serverProps.getProperty("chat.server.port"));
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

    static SessionFactory sessionFactory;
    static void initialize() {
        // A SessionFactory is set up once for an application!
        final StandardServiceRegistry registry = new StandardServiceRegistryBuilder()
                .configure() // configures settings from hibernate.cfg.xml
                .build();
        try {
            sessionFactory = new MetadataSources( registry ).buildMetadata().buildSessionFactory();
        }
        catch (Exception e) {
            System.err.println("Exception "+e);
            StandardServiceRegistryBuilder.destroy( registry );
        }
    }

    static void close(){
        if ( sessionFactory != null ) {
            sessionFactory.close();
        }

    }



}