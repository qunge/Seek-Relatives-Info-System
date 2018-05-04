using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRIS.Model;

namespace SRIS.SPI
{
    /// <summary>
    /// 宝贝回家案例信息接口
    /// </summary>
    public interface IBBHJ
    {
        /// <summary>
        /// 获取所有的宝贝回家案例
        /// </summary>
        /// <returns></returns>
        List<BBHJInfo> GetBBHJInfoList();
    }
}
