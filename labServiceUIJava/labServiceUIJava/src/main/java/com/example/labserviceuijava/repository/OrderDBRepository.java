package com.example.labserviceuijava.repository;

import com.example.labserviceuijava.model.Order;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.Properties;

import com.example.labserviceuijava.repository.exceptions.RepositoryException;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

public class OrderDBRepository implements OrderRepository{

    private JdbcUtils dbUtils;
    private static final Logger logger= LogManager.getLogger();

    public OrderDBRepository(Properties properties){
        logger.info("Initializing ConcertDBRepository with properties: {} ",properties);
        dbUtils=new JdbcUtils(properties);
    }

    @Override
    public Order findOne(Integer integer) {
        return null;
    }

    @Override
    public Iterable<Order> findAll() {
        return null;
    }

    @Override
    public Order save(Order entity) {
        logger.traceEntry("saving order task{}");
        Connection con= dbUtils.getConnection();
        try(PreparedStatement preparedStatement=con.prepareStatement("insert into orders(concertID,buyerName,numberOfTickets) values (?,?,?)")){
            preparedStatement.setInt(1,entity.getConcertId());
            preparedStatement.setString(2,entity.getBuyerName());
            preparedStatement.setInt(3,entity.getNumberOfTickets());
            int result=preparedStatement.executeUpdate();
            logger.trace("saved {} objects",result);
        }catch (SQLException e){
            logger.error(e);
            System.err.println("ERROR DB" + e);
        }
        logger.traceExit(entity);
        return entity;
    }

    @Override
    public Order delete(Integer integer) {
        return null;
    }

    @Override
    public Order update(Order entity) {
        return null;
    }
}
