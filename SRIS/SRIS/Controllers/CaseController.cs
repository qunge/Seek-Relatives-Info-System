using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRIS.SPI;
using SRIS.ViewModels;

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
        public JsonResult GetAllCase ()
        {
            RegisterCaseInfo modelList = new RegisterCaseInfo();
            modelList.data = IRegisterInfo.GetAllCaseInfo();
            return Json(modelList);
        }

        public ActionResult CreateCase()
        {
            return View();
        }
    }
}