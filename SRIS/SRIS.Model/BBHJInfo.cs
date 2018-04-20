using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Model
{
    /// <summary>
    /// 宝贝回家信息
    /// </summary>
    public class BBHJInfo
    {
        /// <summary>
        /// 宝贝回家信息ID
        /// </summary>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  // Id字段的值由用户生成而不是由数据库生成
        public string BBHJInfoID { get; set; }

        /// <summary>
        /// 登记案例
        /// </summary>
        public string RegisterInfoID { get; set; }

        /// <summary>
        /// 宝贝回家登记编号
        /// </summary>
        [Required]
        [StringLength(20)]
        public string BBHJCode { get; set; }

        /// <summary>
        /// 跟进志愿者
        /// </summary>
        public string Volunteer { get; set; }

        /// <summary>
        /// 引导时间
        /// </summary>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GuideTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 案例登记信息
        /// </summary>
        public virtual RegisterInfo RegisterInfo { get; set; }
    }
}
