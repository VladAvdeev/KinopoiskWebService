using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskData.Interfaces
{
    public interface IBaseResponse<T>
    {
        public int Code { get; set; } //свои коды ради удобства
        public string Message { get; set; } //Сообщение

    }
}
