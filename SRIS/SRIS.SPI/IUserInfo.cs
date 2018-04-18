using SRIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.SPI
{
    /// <summary>
    /// 用户信息接口类
    /// </summary>
    public interface IUserInfo
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userInfo">用户信息实体类</param>
        /// <returns></returns>
        int Register(UserInfo userInfo);

        /// <summary>
        /// 通过用户名查询用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        UserInfo GetUserInfoByUserName(string userName);
    }
}
