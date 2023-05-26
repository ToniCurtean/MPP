package org.example.repository;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.example.model.Artist;
import org.example.repository.exceptions.RepositoryException;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class ArtistDBRepository implements ArtistRepository {

    private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public ArtistDBRepository(Properties props) {
        logger.info("Initializing ArtistsRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }



    @Override
    public Artist findOne(Integer integer) {
        logger.traceEntry("find artist by id task{}");
        Connection con=dbUtils.getConnection();
        Artist artist=null;
        try(PreparedStatement preparedStatement=con.prepareStatement("select * from artists where id=?")){
            preparedStatement.setInt(1,integer);
            try(ResultSet resultSet=preparedStatement.executeQuery()){
                while(resultSet.next()){
                    artist=new Artist(resultSet.getInt("id"),resultSet.getString("name"),resultSet.getString("musicType"));
                }
            }
        }
        catch(SQLException e){
            logger.error(e);
            System.err.println("ERROR DB"+ e);
        }
        logger.traceExit(artist);
        if(artist ==null)
            throw new RepositoryException("no artist has been found with the given id!");
        return artist;
    }

    @Override
    public Iterable<Artist> findAll() {
        logger.traceEntry("get all artists task{}");
        Connection con= dbUtils.getConnection();
        List<Artist> artists=new ArrayList<>();
        try(PreparedStatement preparedStatement=con.prepareStatement("select * from artists")){
            try(ResultSet resultSet=preparedStatement.executeQuery()){
                while(resultSet.next()){
                    int id=resultSet.getInt("id");
                    String name=resultSet.getString("name");
                    String musicType=resultSet.getString("musicType");
                    Artist artist=new Artist(id,name,musicType);
                    artists.add(artist);
                }
            }
        }catch(SQLException e){
            logger.error(e);
            System.err.println("ERROR DB"+ e);
        }
        logger.traceExit(artists);
        return artists;

    }

    @Override
    public Artist save(Artist entity) {
        return null;
    }

    @Override
    public Artist delete(Integer integer) {
        return null;
    }

    @Override
    public Artist update(Artist entity) {
        return null;
    }
}
