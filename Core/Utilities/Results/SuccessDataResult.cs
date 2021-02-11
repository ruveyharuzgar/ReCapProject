using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //default da size kızarsa ampulden 'Upgrade all C# projects to language version 7.1' seçeneğini seçebilirsiniz
        public SuccessDataResult(T data,string message) : base(data,true,message)
        {
            //data+mesaj çıktısı isterse
            //success default true alsın
        }

        public SuccessDataResult(T data) : base(data,true)
        {
            //sadece data çıktısı isterse
        }
        public SuccessDataResult(string message) : base(default,true,message)
        {
            //sadece mesaj çıktısı isterse
        }

        public SuccessDataResult() : base(default,true)
        {
            //hiçbir çıktı istemezse
        }
    }
}
