package com.example.labserviceuijava.controller;

import com.example.labserviceuijava.Main;
import com.example.labserviceuijava.model.Artist;
import com.example.labserviceuijava.model.Concert;
import com.example.labserviceuijava.model.Order;
import com.example.labserviceuijava.repository.exceptions.RepositoryException;
import com.example.labserviceuijava.service.Service;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;
import javafx.scene.input.KeyCode;
import javafx.stage.Stage;
import javafx.scene.paint.Color;
import javafx.scene.text.Text;

import java.io.IOException;

public class MainController {

    Service service;
    public void setService(Service service){
        this.service=service;
    }

    @FXML
    ListView<Text> concertsView;

    private final ObservableList<Text> concerts = FXCollections.observableArrayList();

    @FXML
    ListView<String> concertsDateView;

    private final ObservableList<String> concertsDate=FXCollections.observableArrayList();

    @FXML
    TextField dateText;

    @FXML
    TextField nameText;

    @FXML
    TextField numberText;

    @FXML
    Button searchButton;

    @FXML
    Button buyButton;

    @FXML
    Button logoutButton;

    public void init(){
        concertsView.setItems(concerts);
        concertsDateView.setItems(concertsDate);
        concertsDate.clear();
        loadConcerts();
        dateText.setOnKeyPressed(event -> {
            if(event.getCode()== KeyCode.ENTER) {
                onSearchButtonClick(new ActionEvent());
            }
        });

        nameText.setOnKeyPressed(event -> {
            if(event.getCode()== KeyCode.ENTER){
                numberText.requestFocus();
            }
        });

        numberText.setOnKeyPressed(event -> {
            if(event.getCode()==KeyCode.ENTER){
                onBuyButtonClick(new ActionEvent());
            }
        });
    }

    @FXML
    private void onSearchButtonClick(ActionEvent actionEvent){
        concertsDate.clear();
        if(dateText.getText().strip().equals(""))
            return;
        try{
            for(Concert concert:service.getServiceConcert().getConcertsByDate(dateText.getText())){
                Artist artist=service.getServiceArtist().findOne(concert.getArtistId());
                concertsDate.add(artist.getName()+" "+concert.getConcertDate()+" "+concert.getConcertLocation()+" TA "+concert.getTicketsAvailable().toString()+" TS: "+concert.getTicketsSold()+" "+concert.getStartingTime());
            }
        }catch(RepositoryException e){
            UIAlert.showMessage(null, Alert.AlertType.INFORMATION,"","No concerts have the given date!");
        }
    }

    @FXML
    private void onBuyButtonClick(ActionEvent actionEvent) {
        if(nameText.getText().equals("") || numberText.getText().equals("") || concertsView.getSelectionModel().getSelectedItem()==null)
            return;
        String selected=concertsView.getSelectionModel().getSelectedItem().getText();
        String[] data= selected.split("/");
        Concert concert=service.getServiceConcert().getConcertByDateLocationStart(data[1],data[2],data[5]);
        if(concert.getTicketsAvailable()<Integer.parseInt(numberText.getText())){
            UIAlert.showMessage(null, Alert.AlertType.INFORMATION,"","There aren't as much tickets available");
            return;
        }
        service.getServiceOrder().save(concert.getId(),nameText.getText(),Integer.parseInt(numberText.getText()));
        service.getServiceConcert().updateConcertTickets(concert.getId(),Integer.parseInt(numberText.getText()));
        loadConcerts();
    }

    private void loadConcerts(){
        concerts.clear();
        for(Concert concert:service.getServiceConcert().findAll()){
            Text text=new Text();
            Artist artist=service.getServiceArtist().findOne(concert.getArtistId());
            if(concert.getTicketsAvailable()==0){
                text.setText(artist.getName()+"/"+concert.getConcertDate()+"/"+concert.getConcertLocation()+"/"+concert.getTicketsAvailable().toString()+"/"+concert.getTicketsSold().toString()+"/"+concert.getStartingTime());
                text.setFill(Color.RED);
                concerts.add(text);
            }
            else{
                text.setText(artist.getName()+"/"+concert.getConcertDate()+"/"+concert.getConcertLocation()+"/"+concert.getTicketsAvailable().toString()+"/"+concert.getTicketsSold().toString()+"/"+concert.getStartingTime());
                concerts.add(text);
            }
        }
    }

    public void onLogoutButtonClick(ActionEvent event) throws IOException {
        FXMLLoader loader = new FXMLLoader(Main.class.getResource("login-view.fxml"));
        Scene scene = new Scene(loader.load(), 600, 360);
        Stage stage = new Stage();
        stage.setScene(scene);
        stage.setTitle("Welcome!");
        stage.resizableProperty().setValue(Boolean.FALSE);
        stage.show();
        LoginController loginController = loader.getController();
        loginController.setService(service);
        loginController.init();
        ((Stage) logoutButton.getScene().getWindow()).close();
    }

}
