using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //Base alacağım bir data bilgisi yok, o yüzden her iki constructorda da data'yı set ediyorum.
        //Bu class bana datayı verecek yer,mecbur set etmek zorundayım.
        public DataResult(T data,bool success) : base(success)
        {
            Data = data;
        }

        public DataResult(T data,bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public T Data { get; } //IDataResult'u implemente ettiğimiz için geldi,orda artık bizim bir datamız olacağını belirtmiştik.
    }
}
