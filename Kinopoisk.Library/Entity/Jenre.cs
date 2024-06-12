using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.Library.Entity
{
    public class Jenre
    {
        public int JenreId { get; set; }
        public string JenreName { get; set; }
        public ICollection<JenreToMovie> JenreToMovies { get; set; }
    }
}
