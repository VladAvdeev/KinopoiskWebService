namespace Kinopoisk.Models
{
    public class ResponseModel
    {
        public int Code { get; set; } //свои коды ради удобства
        public string Message { get; set; } //Сообщение
        public ResponseModel(int code)
        {
            Code = code;
        }
        public ResponseModel(int code, string message) : this(code)
        {
            Message = message;
        }
    }
}
