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
        public string GetAllCase ()
        {
            string userId = Session["userId"].ToString();
            List<RegisterInfo> list= IRegisterInfo.GetAllCaseInfo(userId);
            RegisterCaseInfo modelList = new RegisterCaseInfo() {
                code=0,
                count=list.Count,
                data=list,
                msg=""
            };
            return JsonConvert.SerializeObject(modelList);
        }

        public ActionResult CreateCase()
        {
            SRTypelist();
            return View();
        }

        [HttpPost]
        public ActionResult CreateCase(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                RegisterInfo registerinfoModel = new RegisterInfo() {
                    BeSeekerName = model.BeSeekerName,
                    CaseCode = model.CaseCode,
                    CreateDateTime = DateTime.Now,
                    DNAState = null,
                    GetTaskDateTime=model.GetTaskDateTime,
                    IsBBHJ="0",
                    IsReturnTask=0,
                    PostLink="",
                    RegisterLink=model.RegisterLink,
                    RegisterInfoID=Guid.NewGuid().ToString(),
                    Remarks=model.Remarks,
                    ReturnReason="",
                    ReturnTaskDateTime=null,
                    SRTypeID=model.SRTypeId.ToString(),
                    Title=model.Title,
                    UserInfoID=Session["userId"].ToString()
                };
                if (IRegisterInfo.CreateRegister(registerinfoModel))
                {
                    return RedirectToAction("AllCase");
                }

            }
            SRTypelist();
            return View(model);
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

        public ActionResult EditCase()
        {
            return View();
        }
    }
}