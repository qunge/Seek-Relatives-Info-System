using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRIS.Model;
using SRIS.Framework;
using SRIS.SPI;
using System.Data.Entity;

namespace SRIS.BLL
{
    /// <summary>
    /// 宝贝回家案例信息操作类
    /// </summary>
    public class BBHJBLL:IBBHJ
    {
        /// <summary>
        /// 获取所有的宝贝回家案例
        /// </summary>
        /// <returns></returns>
        public List<BBHJInfo> GetBBHJInfoList()
        {
            using (var db = new SRISContext())
            {
                List<BBHJInfo> list = db.BBHJInfos.Include(n=>n.RegisterInfo).ToList();
                return list;
            }
        }
    }
}
