using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.Models
{
    public class Episode
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Сериал")]
        public int SeriesId { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Продолжительность")]
        public TimeSpan Duration { get; set; }
        [Required]
        [DisplayName("Дата выхода")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        public virtual Series Series { get; set; }
    }
}
