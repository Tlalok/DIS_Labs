using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.Models
{
    public class Series
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Называние")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
