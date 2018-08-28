namespace PhoneBook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "ManagerId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "ManagerId", c => c.String());
        }
    }
}
