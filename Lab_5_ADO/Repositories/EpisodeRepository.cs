using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using Lab_4_ADO.Models;

namespace Lab_4_ADO.Repositories
{
    public class EpisodeRepository
    {
        private readonly string connectionString;

        public EpisodeRepository(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            this.connectionString = connectionString;
        }

        public Episode Get(int episodeId)
        {
            var connection = new OleDbConnection(connectionString);
            var command = new OleDbCommand($"Select * From episode Where episode_id = {episodeId}", connection);
            connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                return RetrieveEpisode(reader);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Episode> GetAll()
        {
            var connection = new OleDbConnection(connectionString);
            var command = new OleDbCommand("Select * From episode", connection);
            connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                var listEpisodes = RetrieveListEpisodes(reader);
                return listEpisodes;
            }
            finally
            {
                connection.Close();
            }
        }

        public void Add(Episode episode)
        {
            var connection = new OleDbConnection(connectionString);
            var query = $"Insert Into episode (series_id, episode_name, duration, release_date) Values ({episode.SeriesId}, '{episode.Name}', {(int)episode.Duration.TotalSeconds}, '{episode.ReleaseDate}');";
            var command = new OleDbCommand(query, connection);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void Update(Episode episode)
        {
            var connection = new OleDbConnection(connectionString);
            var query = $"Update episode Set series_id = {episode.SeriesId}, episode_name = '{episode.Name}', duration = {episode.Duration}, release_date = '{episode.ReleaseDate}' Where episode_id = {episode.Id};";
            var command = new OleDbCommand(query, connection);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void Delete(Episode episode)
        {
            Delete(episode.Id);
        }

        public void Delete(int episodeId)
        {
            var connection = new OleDbConnection(connectionString);
            var query = $"Delete From episode Where episode_id = {episodeId};";
            var command = new OleDbCommand(query, connection);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        private Episode RetrieveEpisode(OleDbDataReader reader)
        {
            return new Episode
            {
                Id = (int)reader["episode_id"],
                SeriesId = (int)reader["series_id"],
                Name = reader["episode_name"].ToString(),
                Duration = TimeSpan.FromSeconds((int)reader["duration"]),
                ReleaseDate = (DateTime)reader["release_date"]
            };
        }

        private List<Episode> RetrieveListEpisodes(OleDbDataReader reader)
        {
            var listEpisodes = new List<Episode>();
            while (reader.Read())
            {
                listEpisodes.Add(RetrieveEpisode(reader));
            }
            return listEpisodes;
        }
    }
}
