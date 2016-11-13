using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4_ADO.Models;

namespace Lab_4_ADO.Repositories
{
    public class SeriesRepository
    {
        private readonly string connectionString;

        public SeriesRepository(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            this.connectionString = connectionString;
        }

        public List<Series> GetAll()
        {
            var connection = new OleDbConnection(connectionString);
            var command = new OleDbCommand("Select * From series", connection);
            connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                var listSeries = RetrieveListSeries(reader);
                return listSeries;
            }
            finally
            {
                connection.Close();
            }
        }

        public void Add(Series series)
        {
            var connection = new OleDbConnection(connectionString);
            var query = $"Insert Into series (series_name) Values ('{series.Name}');";
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

        public Series GetTheShortestSeries()
        {
            var query = @"SELECT episode.series_id ,SUM(duration) as sum_duration, series_name
FROM episode 
INNER JOIN series ON episode.series_id = series.series_id
GROUP BY episode.series_id, series.series_name";
            var connection = new OleDbConnection(connectionString);
            var command = new OleDbCommand(query, connection);
            connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                var series = new List<Series>();
                while (reader.Read())
                {
                    series.Add(new Series
                    {
                        Id = (int)reader["series_id"],
                        Name = reader["series_name"].ToString(),
                        Duration = TimeSpan.FromSeconds((double)reader["sum_duration"])
                    });
                }
                return series.First(sr => sr.Duration == series.Min(s => s.Duration));
            }
            finally
            {
                connection.Close();
            }
        }

        private Series RetrieveSeries(OleDbDataReader reader)
        {
            return new Series
            {
                Id = (int)reader["series_id"],
                Name = reader["series_name"].ToString()
            };
        }

        private List<Series> RetrieveListSeries(OleDbDataReader reader)
        {
            var listSeries = new List<Series>();
            while (reader.Read())
            {
                listSeries.Add(RetrieveSeries(reader));
            }
            return listSeries;
        }
    }
}
