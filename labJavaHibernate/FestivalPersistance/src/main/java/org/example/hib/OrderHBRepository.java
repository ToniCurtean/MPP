package org.example.hib;

import org.example.Order;
import org.example.OrderRepository;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

public class OrderHBRepository implements OrderRepository {

    static SessionFactory sessionFactory;

    public OrderHBRepository(){
        this.sessionFactory=sessionFactory;
        StandardServiceRegistry registry = new StandardServiceRegistryBuilder()
                .configure().build();
        try {
            sessionFactory = new MetadataSources(registry).buildMetadata().buildSessionFactory();
        } catch (Exception e)
        {
            System.out.println("Exceptie: AICI " + e.getMessage());
            StandardServiceRegistryBuilder.destroy(registry);
        }
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
        try(Session session=sessionFactory.openSession()){
            Transaction tx=null;
            try{
                tx= session.beginTransaction();
                session.save(entity);
                tx.commit();
                return entity;
            }catch(RuntimeException ex){
                System.err.println("Eroare la inserare "+ex);
                if(tx!=null)
                    tx.rollback();
            }
        }
        return null;
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
