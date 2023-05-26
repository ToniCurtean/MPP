package com.example.labserviceuijava.controller;

import com.example.labserviceuijava.Main;
import com.example.labserviceuijava.model.Cashier;
import com.example.labserviceuijava.repository.exceptions.RepositoryException;
import com.example.labserviceuijava.service.Service;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.input.KeyCode;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

import java.io.IOException;
import java.util.Objects;

public class LoginController {

    private Service service;

    @FXML
    private TextField usernameText;

    @FXML
    private PasswordField passwordText;

    @FXML
    private Button loginButton;

    public void setService(Service service) {
        this.service = service;
    }

    public void init() {
        usernameText.setOnKeyPressed(event -> {
            if (event.getCode() == KeyCode.ENTER) {
                passwordText.requestFocus();
            }
        });
    }

    public void onLoginButtonClick(ActionEvent actionEvent) throws IOException, RepositoryException {
        if (Objects.equals(usernameText.getText(), "") || Objects.equals(passwordText.getText(), ""))
            return;
        try {
            if (service.getServiceCashier().getCashierByUserPassword(usernameText.getText(), passwordText.getText())) {
                FXMLLoader loader = new FXMLLoader(Main.class.getResource("main-view.fxml"));
                Scene scene = new Scene(loader.load(), 800, 390);
                Stage stage = new Stage();
                stage.setTitle("Welcome!");
                stage.setScene(scene);
                stage.initStyle(StageStyle.UTILITY);
                stage.show();
                MainController mainPageController = loader.getController();
                mainPageController.setService(service);
                mainPageController.init();
                ((Stage) loginButton.getScene().getWindow()).close();
            }
        } catch (IOException e) {
            System.out.println(e);
        }catch(RepositoryException exception){
            UIAlert.showMessage(null, Alert.AlertType.INFORMATION,"","Username and password incorrect!");
        }
    }
}