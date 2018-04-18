using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SRIS.ViewModels
{
    public class UserInfos
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [Display(Name = "用户名")]
        [RegularExpression(@"^[A-Za-z0-9]\w{1,24}$", ErrorMessage = "用户名必须以大写字母、小写字母、数字组成，长度在2-25之间")]
        [StringLength(25)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [Display(Name = "密码")]
        [RegularExpression(@"^[a-zA-Z]\w{5,17}$", ErrorMessage = "密码必须以字母开头，长度在6~18之间，只能包含字符、数字和下划线")]
        [StringLength(18)]
        public string PassWord { get; set; }

    }
}