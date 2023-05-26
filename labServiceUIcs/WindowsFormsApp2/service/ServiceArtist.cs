using System.Collections.Generic;
using WindowsFormsApp2.model;
using WindowsFormsApp2.repository;

namespace WindowsFormsApp2
{
    public class ServiceArtist
    {
        private ArtistsDBRepository artistsDbRepository;

        public ServiceArtist(ArtistsDBRepository artistsDbRepository)
        {
            this.artistsDbRepository = artistsDbRepository;
        }

        public Artist findOne(int id)
        {
            return artistsDbRepository.FindOne(id);
        }

        public IEnumerable<Artist> FindAll()
        {
            return artistsDbRepository.FindAll();
        }
    }
}