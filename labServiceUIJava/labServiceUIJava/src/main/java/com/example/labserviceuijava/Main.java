package com.example.labserviceuijava;

import com.example.labserviceuijava.controller.LoginController;
import com.example.labserviceuijava.model.Artist;
import com.example.labserviceuijava.repository.*;
import com.example.labserviceuijava.service.*;
import com.example.labserviceuijava.validator.ArtistValidator;
import com.example.labserviceuijava.validator.CashierValidator;
import com.example.labserviceuijava.validator.ConcertValidator;
import com.example.labserviceuijava.validator.OrderValidator;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.FileReader;
import java.io.IOException;
import java.util.Properties;

public class Main extends Application {

    ArtistDBRepository artistRepository;

    CashierDBRepository cashierRepository;

    ConcertDBRepository concertRepository;

    OrderDBRepository orderRepository;

    ServiceArtist serviceArtist;

    ServiceCashier serviceCashier;

    ServiceConcert serviceConcert;

    ServiceOrder serviceOrder;

    Service service;

    @Override
    public void start(Stage primaryStage) throws Exception {
        Properties properties=new Properties();
        try{
            properties.load(new FileReader("bd.config"));
        }catch(IOException e){
            System.out.println("Cannot find bd.config"+e);
        }

        artistRepository =new ArtistDBRepository(properties);
        cashierRepository=new CashierDBRepository(properties);
        concertRepository=new ConcertDBRepository(properties);
        orderRepository=new OrderDBRepository(properties);

        serviceArtist=new ServiceArtist(artistRepository,new ArtistValidator());
        serviceCashier=new ServiceCashier(cashierRepository,new CashierValidator());
        serviceConcert=new ServiceConcert(concertRepository,new ConcertValidator());
        serviceOrder=new ServiceOrder(orderRepository,new OrderValidator());

        Service service=new Service(serviceArtist,serviceCashier,serviceConcert,serviceOrder);

        FXMLLoader fxmlLoader = new FXMLLoader(Main.class.getResource("login-view.fxml"));
        Scene scene = new Scene(fxmlLoader.load(), 600, 360);
        primaryStage.setTitle("Welcome!");
        primaryStage.setScene(scene);
        primaryStage.show();
        LoginController loginController=fxmlLoader.getController();
        loginController.init();
        loginController.setService(service);

    }

    public static void main(String[] args) {
        launch();



    }
}
