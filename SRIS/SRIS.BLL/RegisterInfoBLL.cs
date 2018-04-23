using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRIS.Framework;
using SRIS.Model;
using SRIS.SPI;
using System.Data.Entity;

namespace SRIS.BLL
{
    /// <summary>
    /// 登记案例的信息操作类
    /// </summary>
    public class RegisterInfoBLL : IRegisterInfo
    {
        /// <summary>
        /// 获取所有的登记案例的信息
        /// </summary>
        /// <returns></returns>
        public List<RegisterInfo> GetAllCaseInfo(string userId)
        {
            using (var db = new SRISContext())
            {
                var list = db.RegisterInfos.Where(n => n.UserInfo.UserInfoID == userId).Include(t=>t.SRType).ToList();
      
                return list;
            }

        }

        /// <summary>
        /// 获取所有的案例类型
        /// </summary>
        /// <returns></returns>
        public List<SRType> GetSRType()
        {
            using (var db = new SRISContext())
            {
                List<SRType> SRTypeList = db.SRTypes.ToList();
                return SRTypeList;
            }
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
                using (var db = new SRISContext())
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
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return false;
            }

        }

        /// <summary>
        /// 通过案例类型ID获取案例类型
        /// </summary>
        /// <param name="id">例类型ID</param>
        /// <returns></returns>
        public SRType GetSRTypeById(int id)
        {
            using (var db = new SRISContext())
            {
                return db.SRTypes.Where(n => n.SRTypeID == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 通过案例ID获取联系人信息
        /// </summary>
        /// <param name="CaseId">案例ID</param>
        /// <returns></returns>
        public LinkMan GetLinManModelById(string CaseId)
        {
            using (var db = new SRISContext())
            {
                LinkMan model = db.LinkMans.Where(n=>n.RegisterInfoId==CaseId).FirstOrDefault();
                return model;
            }
        }
       
    }
}
