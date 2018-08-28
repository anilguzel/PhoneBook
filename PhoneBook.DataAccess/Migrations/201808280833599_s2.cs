namespace PhoneBook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "ManagerId", c => c.String());
            DropColumn("dbo.Employee", "ManagerInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "ManagerInfo", c => c.String());
            DropColumn("dbo.Employee", "ManagerId");
        }
    }
}
