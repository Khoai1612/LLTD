namespace LLTD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_QLLop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QLLops",
                c => new
                    {
                        MaLop = c.String(nullable: false, maxLength: 128),
                        TenLop = c.String(),
                        NienKhoa = c.String(),
                        SiSo = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaLop);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QLLops");
        }
    }
}
