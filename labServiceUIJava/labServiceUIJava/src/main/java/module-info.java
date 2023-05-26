module com.example.labserviceuijava {
    requires javafx.controls;
    requires javafx.fxml;
    requires org.apache.logging.log4j;
    requires java.sql;


    opens com.example.labserviceuijava to javafx.fxml;
    exports com.example.labserviceuijava.controller to javafx.fxml;
    opens com.example.labserviceuijava.controller to javafx.fxml;
    exports com.example.labserviceuijava;
}