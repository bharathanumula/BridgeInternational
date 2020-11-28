using BridgeInternationalAcademies.Data.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeInternationalAcademies.Data.Core.Interfaces
{
    public interface IBaseInfoResult
    {
        ResultCode ResultCode { get; }
        string ResultMessage { get; }
    }
}
