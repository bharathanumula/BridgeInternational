using BridgeInternationalAcademies.Data.Core.Enums;
using BridgeInternationalAcademies.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeInternationalAcademies.Data.Core.Models
{
    public class DataResult<T> : BaseResult, IDataResult<T>
    {
        public T Data { get; private set; }

        public DataResult(ResultCode resultCode, string resultMessage, T dataResult) : base(resultCode, resultMessage)
        {
            Data = dataResult;
        }

        public DataResult(T dataResult) : base(ResultCode.Success, string.Empty)
        {
            Data = dataResult;
        }

        public DataResult(IBaseResult previous, T dataResult) : base(previous.Info)
        {
            Data = dataResult;
        }
    }
}
