namespace Kinopoisk.Models.DTO
{
    public class MovieDTO
        //какие конкретно поля будут отоброжаться
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int ProducerId { get; set; }
        public int CreateYear { get; set; }
        public string Country { get; set; }
        public List<DictItem<int>> Jenres { get; set; }
        public DictItem<int> Producer { get; set; }
    }
}
