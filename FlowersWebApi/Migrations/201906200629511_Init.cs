namespace FlowersWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderFlowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Long(nullable: false),
                        FlowerId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.FlowerId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Bdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderFlowers", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.OrderFlowers", "FlowerId", "dbo.Flowers");
            DropIndex("dbo.Orders", new[] { "ManagerId" });
            DropIndex("dbo.OrderFlowers", new[] { "OrderId" });
            DropIndex("dbo.OrderFlowers", new[] { "FlowerId" });
            DropTable("dbo.Managers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderFlowers");
            DropTable("dbo.Flowers");
        }
    }
}
