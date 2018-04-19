using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRIS.Framework;
using SRIS.Model;
using SRIS.SPI;

namespace SRIS.BLL
{
    /// <summary>
    /// 登记案例的信息操作类
    /// </summary>
    public class RegisterInfoBLL:IRegisterInfo
    {
        private SRISContext db = new SRISContext();

        /// <summary>
        /// 获取所有的登记案例的信息
        /// </summary>
        /// <returns></returns>
        public List<RegisterInfo> GetAllCaseInfo()
        {
            var list = db.RegisterInfos.ToList();
            return list;
        }
    }
}
