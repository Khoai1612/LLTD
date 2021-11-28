namespace LLTD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_QLMonHoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QLMonHoc",
                c => new
                    {
                        MaMH = c.String(nullable: false, maxLength: 128),
                        TenMH = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaMH);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QLMonHoc");
        }
    }
}
