using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.Library
{
    internal class ResponseModel
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
