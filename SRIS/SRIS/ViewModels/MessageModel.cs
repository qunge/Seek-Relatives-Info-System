using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRIS.ViewModels
{
    public class MessageModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}