namespace InitDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "ApplicationUser_Id", newName: "Author_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_ApplicationUser_Id", newName: "IX_Author_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_Author_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Posts", name: "Author_Id", newName: "ApplicationUser_Id");
        }
    }
}
