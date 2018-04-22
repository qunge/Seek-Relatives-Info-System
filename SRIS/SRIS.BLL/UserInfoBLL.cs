using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRIS.Model;
using SRIS.Framework;
using SRIS.SPI;

namespace SRIS.BLL
{
    /// <summary>
    /// 用户信息操作类
    /// </summary>
    public class UserInfoBLL:IUserInfo
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userInfo">用户信息实体类</param>
        /// <returns></returns>
        public int Register(UserInfo userInfo)
        {
            using (var db = new SRISContext())
            {
                db.UserInfos.Add(userInfo);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 通过用户名查询用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public UserInfo GetUserInfoByUserName(string userName)
        {
            using (var db = new SRISContext())
            {
                var userInfo = db.UserInfos.Where(n => n.UserName == userName).SingleOrDefault();
                return userInfo;
            }
        }
    }
}
