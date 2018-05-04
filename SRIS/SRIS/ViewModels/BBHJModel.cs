using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRIS.ViewModels
{
    public class BBHJModel
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public List<BBHJViewModel> data { get; set; }
    }

    public class BBHJViewModel
    {
        /// <summary>
        /// 宝贝回家ID
        /// </summary>
        [Required]
        public string BBHJId { get; set; }

        /// <summary>
        /// 案例ID
        /// </summary>
        [Required]
        public string RegisterInfoID { get; set; }

        /// <summary>
        /// 案例编号
        /// </summary>
        public string CaseCode { get; set; }

        /// <summary>
        /// 寻亲类别
        /// </summary>
        public string SRTypeName { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 被寻人姓名
        /// </summary>
        public string BXRName { get; set; }

        /// <summary>
        /// 案例登记连接
        /// </summary>
        public string RegisterLink { get; set; }

        /// <summary>
        /// 宝贝回家编号
        /// </summary>
        [Required]
        public string BBHJCode { get; set; }

        /// <summary>
        /// 跟进志愿者
        /// </summary>
        [Required]
        public string Volunteer { get; set; }

        /// <summary>
        /// 备注：退任务原因
        /// </summary>
        public string Remark { get; set; }
    }
}