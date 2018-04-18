namespace SRIS.Framework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SRIS.Model;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<SRIS.Framework.SRISContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SRIS.Framework.SRISContext context)
        {
            var SRType = new List<SRType> { 
                new SRType{SRTypeName="��Ѱ����"},
                new SRType{SRTypeName="��Ѱ����"},
                new SRType{SRTypeName="����Ѱ��"},
                new SRType{SRTypeName="ս������"},
                new SRType{SRTypeName="�ж�Ѱ��"},
                new SRType{SRTypeName="Ѱ������"},
                new SRType{SRTypeName="����Ѱ��"},
                new SRType{SRTypeName="̨��Ѱ��"}
            };
            SRType.ForEach(n => context.SRTypes.Add(n));
            context.SaveChanges();
        }
    }
}
