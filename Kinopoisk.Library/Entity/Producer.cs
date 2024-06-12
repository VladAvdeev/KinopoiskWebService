using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.Library.Entity
{
    [Table(name: "producers", Schema = "public")]
    public class Producer
    {
        //[Column("Producer_id")]
        public int ProducerId { get; set; }

        //[Column("Lastname")]
        public string LastName { get; set; }

        //[Column("Firstname")]
        public string FirstName { get; set; }

        //[Column("Birthday")]
        public DateOnly BirthDay { get; set; }

        //[Column("Country")]
        public string Country { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
