using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRIS.Model
{
    /// <summary>
    /// 联系人表
    /// </summary>
    public class LinkMan
    {
        /// <summary>
        /// 联系人ID
        /// </summary>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  // Id字段的值由用户生成而不是由数据库生成
        public string LinkManID { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LinkManName { get; set; }

        /// <summary>
        /// 性别(0:空，1：男，2：女)
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 与被寻人关系
        /// </summary>
        [StringLength(50)]
        public string Relationship { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [StringLength(18)]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        [StringLength(50)]
        public string Career { get; set; }

        /// <summary>
        /// 联系人地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Required]
        [StringLength(11)]
        public string Phone { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        public string TelPhone { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        [StringLength(50)]
        public string QQ { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        [StringLength(50)]
        public string WeiXin { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [StringLength(50)]
        public string Email { get; set; }
        /// <summary>
        /// 其他联系方式
        /// </summary>
        [StringLength(50)]
        public string OtherLink { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 登记案例信息
        /// </summary>
        [Key,ForeignKey("RegisterInfo")]
        public string RegisterInfoId { get; set; }

        /// <summary>
        /// 案例登记信息
        /// </summary>
        public virtual RegisterInfo RegisterInfo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateDateTime { get; set; }
    }
}
