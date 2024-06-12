using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.Library.Entity
{
    public class JenreToMovie
    {
        public int IdJenre { get; set; }
        public int IdMovie { get; set; }
        public Movie Movie { get; set; }
        public Jenre Jenre { get; set; }
    }
}
