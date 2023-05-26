package com.example.labserviceuijava.service;

import com.example.labserviceuijava.model.Artist;
import com.example.labserviceuijava.repository.ArtistDBRepository;

import com.example.labserviceuijava.repository.exceptions.RepositoryException;
import com.example.labserviceuijava.validator.ArtistValidator;

import java.security.Provider;

public class ServiceArtist {

    private final ArtistDBRepository artistDBRepository;

    private final ArtistValidator artistValidator;

    public ServiceArtist(ArtistDBRepository artistDBRepository, ArtistValidator artistValidator) {
        this.artistDBRepository = artistDBRepository;
        this.artistValidator = artistValidator;
    }

    public Artist findOne(Integer id){
        return artistDBRepository.findOne(id);
    }

    public Iterable<Artist> findAll(){
        return artistDBRepository.findAll();
    }
}
