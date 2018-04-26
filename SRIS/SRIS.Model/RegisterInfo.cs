using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SRIS.Model
{
    /// <summary>
    /// 案例登记信息
    /// </summary>
    public class RegisterInfo
    {
        /// <summary>
        /// 案例登记信息ID
        /// </summary>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  // Id字段的值由用户生成而不是由数据库生成
        public string RegisterInfoID { get; set; }

        /// <summary>
        /// 案例编号
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CaseCode { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        /// <summary>
        /// 被寻人姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string BeSeekerName { get; set; }
        /// <summary>
        /// 领任务时间
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GetTaskDateTime { get; set; }
        /// <summary>
        /// 登记链接
        /// </summary>
        [Required]
        public string RegisterLink { get; set; }
        /// <summary>
        /// 发帖链接
        /// </summary>
        public string PostLink { get; set; }

        /// <summary>
        /// DNA状态(0:未采血)
        /// </summary>
        public int? DNAState { get; set; }
        /// <summary>
        /// 是否退任务(0:未退任务，1：已退任务)
        /// </summary>
        public int IsReturnTask { get; set; }
        /// <summary>
        /// 退任务时间
        /// </summary>
        public DateTime? ReturnTaskDateTime { get; set; }

        /// <summary>
        /// 退任务原因
        /// </summary>
        [StringLength(50)]
        public string ReturnReason { get; set; }
        /// <summary>
        /// 是否引导去宝贝回家登记
        /// </summary>]
        public string IsBBHJ { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 是否删除（0：未删除  1：已删除）
        /// </summary>
        [DefaultValue(0)]
        public int IsDelete { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 跟进志愿者
        ///// </summary>
        [Required]
        [StringLength(50)]
        public string UserInfoID { get; set; }

        /// <summary>
        /// 寻亲类别
        /// </summary>
        public int? SRTypeID { get; set; }

        /// <summary>
        /// 志愿者
        /// </summary>
        public virtual UserInfo UserInfo { get; set; }

        /// <summary>
        /// 联系人信息
        /// </summary>
        public virtual LinkMan LinkMan { get; set; }

        /// <summary>
        /// 寻亲类别
        /// </summary>
        public virtual SRType SRType { get; set; }

        
    }
}
