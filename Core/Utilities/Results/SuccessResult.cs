using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //bu class da bir result, o yüzden ikisini de destekleyecek doğru sonuçlar için 2 constructor oluşturuyorum
        //default değerlerini Resulttan alabilsin ve this ile oluşturduğum yapısı base alıp mantığı bozmadan çalışsın istiyorum
        public SuccessResult(string message) : base(true,message)
        {

        }

        public SuccessResult() : base(true)
        {

        }
    }
}
