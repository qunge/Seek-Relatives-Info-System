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
        public List<RegisterInfo> GetAllCaseInfo(string userId)
        {
            var list = db.RegisterInfos.Where(n=>n.UserInfoID==userId).ToList();
            return list;
        }

        /// <summary>
        /// 获取所有的案例类型
        /// </summary>
        /// <returns></returns>
        public List<SRType> GetSRType()
        {
            List<SRType> SRTypeList = db.SRTypes.ToList();
            return SRTypeList;
        }

        /// <summary>
        /// 创建一条案例信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateRegister(RegisterInfo model)
        {
            try
            {
                db.RegisterInfos.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return false;
            }

        }
    }
}
