namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        factura_FacturaID = c.Int(),
                        producto_ProductoID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Facturas", t => t.factura_FacturaID)
                .ForeignKey("dbo.Productoes", t => t.producto_ProductoID)
                .Index(t => t.factura_FacturaID)
                .Index(t => t.producto_ProductoID);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaID = c.Int(nullable: false, identity: true),
                        FechaFactura = c.DateTime(nullable: false),
                        NombreVendedor = c.String(nullable: false),
                        NombreCliente = c.String(nullable: false),
                        IGV = c.Double(nullable: false),
                        subTotal = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FacturaID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Precio = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleFacturas", "producto_ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.DetalleFacturas", "factura_FacturaID", "dbo.Facturas");
            DropIndex("dbo.DetalleFacturas", new[] { "producto_ProductoID" });
            DropIndex("dbo.DetalleFacturas", new[] { "factura_FacturaID" });
            DropTable("dbo.Productoes");
            DropTable("dbo.Facturas");
            DropTable("dbo.DetalleFacturas");
        }
    }
}
