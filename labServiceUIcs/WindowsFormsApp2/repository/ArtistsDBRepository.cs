using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using log4net;
using WindowsFormsApp2.model;

namespace WindowsFormsApp2.repository
{
    public class ArtistsDBRepository :IArtistsRepository
    {
        private IDictionary<string, string> properties;
        private static ILog log = LogManager.GetLogger(typeof(ArtistsDBRepository));

        public ArtistsDBRepository(IDictionary<string, string> properties)
        {
            log.Info("Initializing ArtistsDBRepository");
            this.properties = properties;
        }
        
        public Artist FindOne(int id)
        {
            log.InfoFormat("Find buyer after id {0}",id);
            IDbConnection connection = DBUtils.getConnection(properties);
            Artist artist = null;
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
                        artist = new Artist(dataR.GetInt16(0),dataR.GetString(1),dataR.GetString(2));
                    }
                }
            }
            log.InfoFormat("The artist found {0}",artist);
            return artist;
        }

        public IEnumerable<Artist> FindAll()
        {
            log.Info("getting all artists");
            IDbConnection connection = DBUtils.getConnection(properties);
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

            log.InfoFormat("finished finding all");
            return artists;
        }

        public Artist Save(Artist e)
        {
            throw new System.NotImplementedException();
        }

        public Artist Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Artist Update(int id, Artist e)
        {
            throw new System.NotImplementedException();
        }
    }
}