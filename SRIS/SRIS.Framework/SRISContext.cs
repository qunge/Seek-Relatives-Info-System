using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRIS.Model;

namespace SRIS.Framework
{
    public class SRISContext:DbContext
    {
        public SRISContext():base("SRISContext")
        { }
        /// <summary>
        /// 用户信息表
        /// </summary>
        public DbSet<UserInfo> UserInfos { get; set; }

        /// <summary>
        /// 案例登记信息表
        /// </summary>
        public DbSet<RegisterInfo> RegisterInfos { get; set; }

        /// <summary>
        /// 寻亲类型表
        /// </summary>
        public DbSet<SRType> SRTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
