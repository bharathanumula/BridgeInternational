using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeInternationalAcademies.Data.Core.Interfaces
{
    public interface IDataResult<T> : IBaseResult
    {
        T Data { get; }
    }
}
