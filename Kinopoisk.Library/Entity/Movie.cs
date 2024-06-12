using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.Library.Entity
{
    [Table(name: "movies", Schema = "public")]
    public class Movie
    {
        [Column("movie_id")]
        public int MovieId { get; set; }

        [Column("movie_name")]
        public string MovieName { get; set; }

        [Column("create_year")]
        public int CreateYear { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("producer_id")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public ICollection<JenreToMovie> JenreToMovies { get; set; }
    }
}
