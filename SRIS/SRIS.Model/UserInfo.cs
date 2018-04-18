using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SRIS.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Description("用户信息")]
    public class UserInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  // Id字段的值由用户生成而不是由数据库生成
        public string UserInfoId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string PassWord { get; set; }

        /// <summary>
        /// 盐值
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Salt { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateDateTime { get; set; }

        public ICollection<RegisterInfo> RegisterInfo { get; set; }
    }
}
