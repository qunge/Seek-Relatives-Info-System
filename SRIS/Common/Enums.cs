using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Common
{
    /// <summary>
    /// 发生错误是处理方式
    /// </summary>
    public enum ErrorHandle
    {
        /// <summary>
        /// 抛出异常
        /// </summary>
        Throw,
        /// <summary>
        /// 跳出
        /// </summary>
        Continue
    }
}
