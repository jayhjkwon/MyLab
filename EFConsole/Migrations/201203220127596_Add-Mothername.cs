namespace EFConsole.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddMothername : DbMigration
    {
        public override void Up()
        {
            AddColumn("Members", "MotherName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Members", "MotherName");
        }
    }
}
