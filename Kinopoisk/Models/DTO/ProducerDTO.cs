using System.Collections.Generic;

namespace Kinopoisk.Models.DTO
{
    public class ProducerDTO
    //какие конкретно поля будут отоброжаться
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Country { get; set; }
        public List<DictItem<int>> MovieList { get; set; }
    }
}
