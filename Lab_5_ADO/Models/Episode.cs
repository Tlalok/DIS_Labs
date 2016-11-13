using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_ADO.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Today;
    }
}
