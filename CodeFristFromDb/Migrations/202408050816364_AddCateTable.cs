namespace CodeFristFromDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("Insert into Categories(name) values ('Nghiadz')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
