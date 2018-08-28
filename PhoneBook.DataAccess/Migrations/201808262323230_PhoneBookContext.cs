namespace PhoneBook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PhoneBookContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Employee",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Surname = c.String(),
                    PhoneNumber = c.String(),
                    Title = c.String(),
                    ManagerInfo = c.String(),
                    DepartmentId = c.Int(nullable: true),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
