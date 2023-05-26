using System.Collections.Generic;
using model;

namespace persistence
{
    public class ArtistDBRepository:IArtistRepository
    {

        private IDictionary<string, string> props;

        public ArtistDBRepository(IDictionary<string, string> props)
        {
            this.props = props;
        }
        
        public void Save(Artist entity)
        {
            throw new System.NotImplementedException();
        }

        public Artist FindOne(int id)
        {
            var connection = DbUtils.getConnection(props);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from artists where id=@id";
                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);
                using (var dataR = command.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        Artist artist = new Artist(dataR.GetInt16(0), dataR.GetString(1), dataR.GetString(2));
                        return artist;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Artist> FindAll()
        {
            var connection = DbUtils.getConnection(props);
            IList <Artist> artists= new List<Artist>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from artists";
                using (var dataR = command.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt16(0);
                        string name = dataR.GetString(1);
                        string musicType = dataR.GetString(2);
                        Artist artist = new Artist(id, name, musicType);
                        artists.Add(artist);
                    }
                }
            }
            return artists;
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Artist e)
        {
            throw new System.NotImplementedException();
        }
    }
}