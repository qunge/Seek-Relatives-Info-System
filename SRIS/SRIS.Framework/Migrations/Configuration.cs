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
                new SRType{SRTypeName="家寻亲人"},
                new SRType{SRTypeName="家寻送养"},
                new SRType{SRTypeName="亲人寻家"},
                new SRType{SRTypeName="战友情深"},
                new SRType{SRTypeName="感恩寻人"},
                new SRType{SRTypeName="寻找老友"},
                new SRType{SRTypeName="其他寻人"},
                new SRType{SRTypeName="台海寻亲"}
            };
            SRType.ForEach(n => context.SRTypes.Add(n));
            context.SaveChanges();
        }
    }
}
