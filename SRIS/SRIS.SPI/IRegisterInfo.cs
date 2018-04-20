using SRIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.SPI
{
    /// <summary>
    /// 案例登记信息类
    /// </summary>
    public interface IRegisterInfo
    {
        /// <summary>
        /// 获取所有的登记案例的信息
        /// </summary>
        /// <returns></returns>
        List<RegisterInfo> GetAllCaseInfo(string userId);

        /// <summary>
        /// 获取所有的案例类型
        /// </summary>
        /// <returns></returns>
        List<SRType> GetSRType();

        /// <summary>
        /// 创建一条案例信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool CreateRegister(RegisterInfo model);
    }
}
