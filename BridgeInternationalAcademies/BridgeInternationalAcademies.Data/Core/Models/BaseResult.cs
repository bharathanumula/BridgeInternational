using BridgeInternationalAcademies.Data.Core.Enums;
using BridgeInternationalAcademies.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeInternationalAcademies.Data.Core.Models
{
    public class BaseResult : IBaseResult
    {
        public class BaseInfoResult : IBaseInfoResult
        {
            public ResultCode ResultCode { get; private set; }

            public string ResultMessage { get; private set; }

            public BaseInfoResult(ResultCode resultCode, string resultMessage)
            {
                ResultCode = resultCode;
                ResultMessage = resultMessage;
            }
        }

        public IBaseInfoResult Info { get; private set; }

        public BaseResult(ResultCode resultCode, string resultMessage)
        {
            Info = new BaseInfoResult(resultCode, resultMessage);
        }

        public BaseResult(IBaseInfoResult previousResult)
        {
            Info = new BaseInfoResult(previousResult.ResultCode, previousResult.ResultMessage);
        }
    }
}
