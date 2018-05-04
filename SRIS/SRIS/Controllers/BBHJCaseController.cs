using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRIS.SPI;
using SRIS.Model;
using SRIS.ViewModels;
using Newtonsoft.Json;

namespace SRIS.Controllers
{
    public class BBHJCaseController:Controller
    {
        IBBHJ IBBHJ;
        public BBHJCaseController()
        {
            IBBHJ = new BLL.BBHJBLL();
        }
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取全部宝贝回家案例
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBbhjCase()
        {
            List<BBHJInfo> list = IBBHJ.GetBBHJInfoList();
            List<BBHJViewModel> viewModelList = new List<BBHJViewModel>();
            foreach (BBHJInfo item in list)
            {
                BBHJViewModel model = new BBHJViewModel() {
                    BBHJCode=item.BBHJCode,
                    BBHJId=item.BBHJInfoID,
                    BXRName=item.RegisterInfo.BeSeekerName,
                    RegisterInfoID=item.RegisterInfoID,
                    Remark=item.Remark,
                    SRTypeName=item.RegisterInfo.SRType.SRTypeName,
                    Title=item.RegisterInfo.Title,
                    Volunteer="",
                    CaseCode=item.RegisterInfo.CaseCode
                };
                viewModelList.Add(model);
            }
            BBHJModel modelList = new BBHJModel()
            {
                code = 0,
                count = list.Count,
                data = viewModelList,
                msg = ""
            };
            return Json(modelList);
        }
    }
}