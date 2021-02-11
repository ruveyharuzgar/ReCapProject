using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            //data+mesaj çıktısı isterse
            //success default true alsın
        }

        public ErrorDataResult(T data) : base(data, false)
        {
            //sadece data çıktısı isterse
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
            //sadece mesaj çıktısı isterse
        }

        public ErrorDataResult() : base(default, false)
        {
            //hiçbir çıktı istemezse
        }
    }
}
