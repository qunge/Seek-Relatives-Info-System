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
        public List<RegisterInfo> GetAllCaseInfo(string userId,int page,int limit,Dictionary<string,string> whereDic, out int pageCount)
        {
            using (var db = new SRISContext())
            {
                List<RegisterInfo> list = db.RegisterInfos
                    .Where(n => n.UserInfo.UserInfoID == userId&&n.IsReturnTask==0&&n.IsBBHJ=="0"&&n.IsDelete==0&&n.IsSuccess==0)
                    .Include(t=>t.SRType)
                    .OrderByDescending(s=>s.GetTaskDateTime)
                    .ToList();
                if (whereDic != null)
                {
                    if (!string.IsNullOrEmpty(whereDic["caseCode"]))
                    {
                        list = list.Where(n => n.CaseCode.Contains(whereDic["caseCode"])).ToList();
                    }
                    if (!string.IsNullOrEmpty(whereDic["srTypeId"]))
                    {
                        list = list.Where(n => n.SRTypeID == Convert.ToInt32(whereDic["srTypeId"])).ToList();
                    }
                    if (!string.IsNullOrEmpty(whereDic["beSeekerName"]))
                    {
                        list = list.Where(n => n.BeSeekerName.Contains(whereDic["beSeekerName"])).ToList();
                    }
                    if (!string.IsNullOrEmpty(whereDic["getTaskDate"]))
                    {
                        list = list.Where(n => n.GetTaskDateTime == Convert.ToDateTime(whereDic["getTaskDate"])).ToList();
                    }
                }
                pageCount = list.Count;
                return list.Skip((page-1)*limit).Take(limit).ToList();
            }

        }

        /// <summary>
        /// 通过案例ID获取案例信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RegisterInfo GetRegisterInfoById(string Id)
        {
            using (var db = new SRISContext())
            {
                return db.RegisterInfos.Find(Id);
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

        /// <summary>
        /// 创建联系人信息
        /// </summary>
        /// <param name="model">联系人信息实体类</param>
        /// <returns></returns>
        public bool CreateLinkMan(LinkMan model)
        {
            using (var db = new SRISContext())
            {
                db.LinkMans.Add(model);
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

        /// <summary>
        /// 修改联系人信息
        /// </summary>
        /// <param name="model">联系人信息实体类</param>
        /// <returns></returns>
        public bool UpdateLinkMan(LinkMan model)
        {
            using (var db = new SRISContext())
            {
                LinkMan linkManModel = db.LinkMans.Find(model.LinkManID);
                linkManModel.Address = model.Address;
                linkManModel.Birthday = model.Birthday;
                linkManModel.Career = model.Career;
                linkManModel.CreateDateTime = model.CreateDateTime;
                linkManModel.Email = model.Email;
                linkManModel.IdCardNo = model.IdCardNo;
                linkManModel.LinkManName = model.LinkManName;
                linkManModel.OtherLink = model.OtherLink;
                linkManModel.Phone = model.Phone;
                linkManModel.QQ = model.QQ;
                linkManModel.Relationship = model.Relationship;
                linkManModel.Remark = model.Remark;
                linkManModel.Sex = model.Sex;
                linkManModel.TelPhone = model.TelPhone;
                linkManModel.WeiXin = model.WeiXin;
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// 修改案例信息
        /// </summary>
        /// <param name="model">案例信息实体类</param>
        /// <returns></returns>
        public bool UpdateRegisterInfo(RegisterInfo model)
        {
            using (var db = new SRISContext())
            {
                RegisterInfo md = db.RegisterInfos.Find(model.RegisterInfoID);
                md.BeSeekerName = model.BeSeekerName;
                md.CaseCode = model.CaseCode;
                md.GetTaskDateTime = model.GetTaskDateTime;
                md.PostLink = model.PostLink;
                md.RegisterLink = model.RegisterLink;
                md.Remarks = model.Remarks;
                md.SRTypeID = model.SRTypeID;
                md.Title = model.Title;
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// 删除案例登记信息
        /// </summary>
        /// <param name="id">案例登记ID</param>
        /// <returns></returns>
        public bool DelRegisterInfo(string id)
        {
            using (var db = new SRISContext())
            {
                RegisterInfo model = db.RegisterInfos.Find(id);
                model.IsDelete = 1;
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// 设置为宝贝回家案例
        /// </summary>
        /// <param name="id">要设置的案例ID</param>
        /// <returns></returns>
        public bool Bbhj(string id)
        {
            using (var db = new SRISContext())
            {
                var tran = db.Database.BeginTransaction();
                try
                {
                    // 修改案例状态为宝贝回家案例
                    RegisterInfo model = db.RegisterInfos.Find(id);
                    model.IsBBHJ = "1";

                    // 宝贝回家表添加数据
                    BBHJInfo bbModel = new BBHJInfo() {
                        BBHJCode="",
                        BBHJInfoID=System.Guid.NewGuid().ToString(),
                        CreateDateTime=DateTime.Now,
                        GuideTime=DateTime.Now,
                        RegisterInfoID=id,
                        Remark="",
                        Volunteer=""
                    };
                    db.BBHJInfos.Add(bbModel);

                    db.SaveChanges();
                    tran.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    return false;
                }
                
            }
        }

    }
}
