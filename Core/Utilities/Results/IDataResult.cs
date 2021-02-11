using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //List<> yapısında ki methodlarımız için data+message döndürecek base yapıyı oluşturuyorum
        //IResult u referans aldığı için success ve message proplarını da bu class da tanımlamış gibi düşünebilirim
        T Data { get; }
    }
}
