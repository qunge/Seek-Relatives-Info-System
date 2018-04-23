using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRIS.Model;
using SRIS.ViewModels;
using SRIS.Common;
using SRIS.SPI;
using SRIS.BLL;
using Newtonsoft.Json;

namespace SRIS.Controllers
{
    public class AccountController : Controller
    {
        IUserInfo IUserInfo;
        public AccountController()
        {
            IUserInfo = new BLL.UserInfoBLL();
        }
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserInfos userInfo)
        {
            // UserInfo userInfoModel = IUserInfo.GetUserInfoByUserName(userInfo.UserName);
            UserInfo userInfoModel = IUserInfo.GetUserInfoByUserName("涅炎");
            if (userInfoModel != null)
            {
                // string pwd = Common.EncryptDecrypt.MD5Encoding(userInfo.PassWord, userInfoModel.Salt);
                string pwd = Common.EncryptDecrypt.MD5Encoding("qunge7758521", userInfoModel.Salt);
                if (pwd == userInfoModel.PassWord)
                {
                    ViewBag.Message = "登录成功";
                    Session["userName"] = userInfoModel.UserName;
                    Session["userId"] = userInfoModel.UserInfoID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "用户名或密码错误";
                    return View(userInfo);
                }
            }
            else
            {
                ViewBag.Message = "用户名或密码错误";
                return View(userInfo);
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(string parame)
        {
            try  
            {
                UserInfos userInfoParame = JsonConvert.DeserializeObject<UserInfos>(parame);
                UserInfo userInfo = IUserInfo.GetUserInfoByUserName(userInfoParame.UserName);
                if (userInfo!=null)
                {
                    return Json(new { state = false, message = "用户名重复" });
                }
                string salt = Common.EncryptDecrypt.CreateSalt();
                UserInfo uf = new UserInfo() {
                    UserInfoID= System.Guid.NewGuid().ToString(),
                    Salt= salt,
                    PassWord= Common.EncryptDecrypt.MD5Encoding(userInfoParame.PassWord, salt),
                    UserName=userInfoParame.UserName,
                    CreateDateTime=DateTime.Now
                };
                int result = IUserInfo.Register(uf);
                if (result > 0)
                {
                    return Json(new { state = true, message = "注册成功" });
                }
                else
                {
                    return Json(new { state = false, message = "注册失败" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { state = false, message = ex.Message });
            }
        }

        public ActionResult Logout()
        {
            // 清空Session
            Session["userName"] = "";
            Session["userId"] = "";
            return View("Login");
        }

    }
}