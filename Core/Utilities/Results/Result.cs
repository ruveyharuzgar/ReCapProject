using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //başarısı+mesaj çıktısı istiyorsam,tek parametreli constructor gelen bool değişkeni
        //ile illa ki çalışacağı için return ettiğim Successi ' Don't Repeat Yourself ' kuralına uyarak, 
        //tekrar set etmiyorum.This anahtar sözcüğü burda "bu constructor 2 parametreli ama içinde set edilmiş
        //tek değişken var 2. değişkenini yani bizim burda ki succecs değişkenimi zaten benle birlikte çalışmış const2 den al" diyorum
        public Result(bool success,string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Succes = success;
        }
        public bool Succes { get; }

        public string Message { get; }
    }
}
