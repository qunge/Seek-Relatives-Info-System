using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRIS.SPI;
using SRIS.ViewModels;
using SRIS.Model;
using Newtonsoft.Json;

namespace SRIS.Controllers
{
    public class CaseController : Controller
    {
        IRegisterInfo IRegisterInfo;
        public CaseController()
        {
            IRegisterInfo = new BLL.RegisterInfoBLL();
        }
        // GET: Case
        public ActionResult AllCase()
        {
            return View();
        }

        /// <summary>
        /// 获取所有案例信息
        /// </summary>
        /// <returns></returns>
        public string GetAllCase(int page,int limit,string whereStr)
        {
            int pageCount;
            Dictionary<string, string> whereDic = null;
            if (!string.IsNullOrEmpty(whereStr))
            {
                whereDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(whereStr);
            }
            string userId = Session["userId"].ToString();
            List<RegisterInfo> list = IRegisterInfo.GetAllCaseInfo(userId, page,limit, whereDic, out pageCount);
            List<RegisterModel> modelList = new List<RegisterModel>();
            foreach (RegisterInfo item in list)
            {
                RegisterModel model = new RegisterModel();
                model.BeSeekerName = item.BeSeekerName;
                model.CaseCode = item.CaseCode;
                model.getTaskDate = item.GetTaskDateTime.ToShortDateString();
                model.IsBBHJ = item.IsBBHJ;
                model.IsReturnTask = item.IsReturnTask;
                model.PostLink = item.PostLink;
                model.RegisterInfoId = item.RegisterInfoID;
                model.RegisterLink = item.RegisterLink;
                model.Remarks = item.Remarks;
                model.SRTypeId = item.SRTypeID;
                model.SRTypeName = item.SRType.SRTypeName;
                model.Title = item.Title;
                modelList.Add(model);
            }
            RegisterCaseInfo data = new RegisterCaseInfo()
            {
                code = 0,
                count = pageCount,
                data = modelList,
                msg = ""
            };
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 创建案例
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateCase(string id="")
        {
            RegisterInfo model = IRegisterInfo.GetRegisterInfoById(id);
            if (model == null)
            {
                SRTypelist();
                return View();
            }
            else
            {
                RegisterModel viewModel = new RegisterModel()
                {
                    BeSeekerName = model.BeSeekerName,
                    CaseCode = model.CaseCode,
                    GetTaskDateTime = model.GetTaskDateTime,
                    //getTaskDate=model.GetTaskDateTime.ToShortDateString(),
                    PostLink = model.PostLink,
                    RegisterInfoId = model.RegisterInfoID,
                    RegisterLink = model.RegisterLink,
                    Remarks = model.Remarks,
                    SRTypeId = model.SRTypeID,
                    Title = model.Title
                };
                SRTypelist();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult CreateCase(RegisterModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegisterInfo md = IRegisterInfo.GetRegisterInfoById(model.RegisterInfoId);
                    if (md == null)
                    {
                        // 创建
                        RegisterInfo registerinfoModel = new RegisterInfo()
                        {
                            BeSeekerName = model.BeSeekerName,
                            CaseCode = model.CaseCode,
                            CreateDateTime = DateTime.Now,
                            DNAState = null,
                            GetTaskDateTime = model.GetTaskDateTime,
                            IsBBHJ = "0",
                            IsReturnTask = 0,
                            PostLink = "",
                            RegisterLink = model.RegisterLink,
                            RegisterInfoID = Guid.NewGuid().ToString(),
                            Remarks = model.Remarks,
                            ReturnReason = "",
                            ReturnTaskDateTime = null,
                            SRTypeID = model.SRTypeId,
                            Title = model.Title,
                            UserInfoID = Session["userId"].ToString()
                        };
                        if (IRegisterInfo.CreateRegister(registerinfoModel))
                        {
                            return RedirectToAction("AllCase");
                        }
                    }
                    else
                    {
                        // 修改
                        md.BeSeekerName = model.BeSeekerName;
                        md.CaseCode = model.CaseCode;
                        md.GetTaskDateTime = model.GetTaskDateTime;
                        md.PostLink = "";
                        md.RegisterLink = model.RegisterLink;
                        md.PostLink = model.PostLink==null?"":model.PostLink;
                        md.Remarks = model.Remarks;
                        md.SRTypeID = model.SRTypeId;
                        md.Title = model.Title;
                        md.RegisterInfoID = model.RegisterInfoId;
                        if (IRegisterInfo.UpdateRegisterInfo(md))
                        {
                            return RedirectToAction("AllCase");
                        }
                    }



                }
                SRTypelist();
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                SRTypelist();
                return View(model);
            }
        }

        private void SRTypelist()
        {
            // 获取所有的案例类型
            List<SelectListItem> itemList = new List<SelectListItem>();
            List<SRType> SRTypeList = IRegisterInfo.GetSRType();
            SRTypeList.ForEach(o => {
                SelectListItem item = new SelectListItem()
                {
                    Value = o.SRTypeID.ToString(),
                    Text = o.SRTypeName
                };
                itemList.Add(item);
            });
            SelectList select = new SelectList(itemList, "Value", "Text");
            ViewBag.select = select;
        }

        public ActionResult EditCase(string caseId)
        {
            LinkMan model = IRegisterInfo.GetLinManModelById(caseId);
            if (model == null)
            {
                return View();
            }
            else
            {
                LinkManModel viewModel = new LinkManModel()
                {
                    Address = model.Address,
                    Birthday = model.Birthday,
                    Career = model.Career,
                    Email = model.Email,
                    IdCardNo = model.IdCardNo,
                    LinkManName = model.LinkManName,
                    OtherLink = model.OtherLink,
                    Phone = model.Phone,
                    QQ = model.QQ,
                    Relationship = model.Relationship,
                    Remark = model.Remark,
                    Sex = model.Sex,
                    TelPhone = model.TelPhone,
                    WeiXin = model.WeiXin,
                    LinkManID = model.LinkManID
                };
                return View(viewModel);
            }
        }

        public ActionResult EditLinManInfo(string id)
        {
            LinkMan model = IRegisterInfo.GetLinManModelById(id);
            if (model == null)
            {
                LinkManModel viewModel = new LinkManModel() {
                    RegisterInfoId=id
                };
                return View(viewModel);
            }
            else
            {
                LinkManModel viewModel = new LinkManModel() {
                    Address = model.Address,
                    Birthday=model.Birthday,
                    Career=model.Career,
                    Email=model.Email,
                    IdCardNo=model.IdCardNo,
                    LinkManName=model.LinkManName,
                    OtherLink=model.OtherLink,
                    Phone=model.Phone,
                    QQ=model.QQ,
                    Relationship=model.Relationship,
                    Remark=model.Remark,
                    Sex=model.Sex,
                    TelPhone=model.TelPhone,
                    WeiXin=model.WeiXin,
                    LinkManID=model.LinkManID,
                    RegisterInfoId=model.RegisterInfoId
                };
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult EditLinManInfo(LinkManModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LinkMan LinManmodel = IRegisterInfo.GetLinManModelById(model.RegisterInfoId);

                    if (LinManmodel == null)
                    {
                        // 新建
                        LinkMan linkMan = new LinkMan()
                        {
                            Address = model.Address,
                            Birthday = model.Birthday,
                            Career = model.Career,
                            CreateDateTime = DateTime.Now,
                            Email = model.Email,
                            IdCardNo = model.IdCardNo,
                            LinkManID = System.Guid.NewGuid().ToString(),
                            LinkManName = model.LinkManName,
                            OtherLink = model.OtherLink,
                            Phone = model.Phone,
                            QQ = model.QQ,
                            RegisterInfoId = model.RegisterInfoId,
                            Relationship = model.Relationship,
                            Remark = model.Remark,
                            Sex = model.Sex,
                            TelPhone = model.TelPhone,
                            WeiXin = model.WeiXin
                        };
                        if (IRegisterInfo.CreateLinkMan(linkMan))
                        {
                            ViewBag.Message = "添加联系人成功";
                            return View("EditLinManInfo");
                        }
                    }
                    else
                    {
                        // 编辑信息
                        LinManmodel.Address = model.Address;
                        LinManmodel.Birthday = model.Birthday;
                        LinManmodel.Career = model.Career;
                        LinManmodel.CreateDateTime = DateTime.Now;
                        LinManmodel.Email = model.Email;
                        LinManmodel.IdCardNo = model.IdCardNo;
                        LinManmodel.LinkManID = model.LinkManID;
                        LinManmodel.LinkManName = model.LinkManName;
                        LinManmodel.OtherLink = model.OtherLink;
                        LinManmodel.Phone = model.Phone;
                        LinManmodel.QQ = model.QQ;
                        LinManmodel.RegisterInfoId = model.RegisterInfoId;
                        LinManmodel.Relationship = model.Relationship;
                        LinManmodel.Remark = model.Remark;
                        LinManmodel.Sex = model.Sex;
                        LinManmodel.TelPhone = model.TelPhone;
                        LinManmodel.WeiXin = model.WeiXin;
                        if (IRegisterInfo.UpdateLinkMan(LinManmodel))
                        {
                            ViewBag.Message = "修改联系人成功";
                            return View("EditLinManInfo");
                        }
                    }
                }
                ViewBag.Message = "修改联系人失败";
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View(model);
            }
        }


        public ActionResult ReturnTask(string id)
        {
            RegisterInfo model = IRegisterInfo.GetRegisterInfoById(id);
            if (model == null)
            {
                return View();
            }
            else
            {
                RegisterModel viewModel = new RegisterModel() {
                    ReturnReason=model.ReturnReason,
                    ReturnTaskDateTime=model.ReturnTaskDateTime
                };
                return View(viewModel);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id">要删除任务的ID</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DelRegisterInfo(string Id)
        {
            var obj = new { state=false,message=""};
            try
            {
                if (IRegisterInfo.DelRegisterInfo(Id))
                {
                    obj = new { state = true, message = "删除成功" };
                }
                else
                {
                    obj = new { state = false, message = "删除失败" };
                }
            }
            catch (Exception e)
            {
                obj = new { state = false, message = e.Message };
            }
            return Json(obj);
        }

        public JsonResult ydbbhj(string id)
        {
            var obj = new { state=false,message=""};
            if (!string.IsNullOrEmpty(id))
            {
                if (IRegisterInfo.Bbhj(id))
                {
                    obj = new { state = true, message = "设置为宝贝回家案例成功" };
                }
                else
                {
                    obj = new { state = false, message = "设置为宝贝回家案例失败" };
                }
            }
            else
            {
                obj = new { state = false, message = "案例编号不能为空" };
            }
           return Json(obj);
        }

    }
}