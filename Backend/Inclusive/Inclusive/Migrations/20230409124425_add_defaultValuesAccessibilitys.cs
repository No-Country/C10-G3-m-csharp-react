using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inclusive.Migrations
{
    public partial class add_defaultValuesAccessibilitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string Sql = @"GO
            BEGIN TRANSACTION

            IF NOT EXISTS (SELECT 1 FROM [dbo].Accessibilitys)
            BEGIN
                INSERT INTO [dbo].Accessibilitys ([AccessibilityId], [Name], [OrderNumber])
                VALUES 
		            (CAST(N'2A181CB8-1C51-4807-92A5-0F8E2226A77D' AS uniqueidentifier), N'Rampa', 1),
		            (CAST(N'FA369D7F-06D5-47F8-8D23-30AB96F9D3BA' AS uniqueidentifier), N'Ángulo de rampa', 2),
		            (CAST(N'D1526E5F-09E1-4E9C-9F11-5DD5C5D0CC0C' AS uniqueidentifier), N'Mobiliario', 3),
		            (CAST(N'C9BEE811-72FD-4B4C-AB7D-2D0AAFA2A8C1' AS uniqueidentifier), N'Personal asistente', 4),
		            (CAST(N'A843AED5-1DE5-4073-BF1A-11E542BDA9DA' AS uniqueidentifier), N'Ancho de pasillo (mínimo 140 cm)', 5),
		            (CAST(N'F78EC4B4-F0C8-47E8-9BC6-8B5DBEC9EF50' AS uniqueidentifier), N'Ascensor', 6),
		            (CAST(N'E108D6C7-946C-452D-B3BB-3B096BE1EE09' AS uniqueidentifier), N'Baño accesible', 7),
		            (CAST(N'B719FC5E-722A-436C-BBFE-76806ABACEF8' AS uniqueidentifier), N'Altura de mostrador (85 cm aprox.)', 8),
		            (CAST(N'E0EC6D9F-9E34-4A7C-BF05-4A7C4A72670C' AS uniqueidentifier), N'Estacionamiento adaptado', 9),
		            (CAST(N'2BFB21C5-7C70-44D1-A7E5-33CEB726FFC3' AS uniqueidentifier), N'Otros (Escríbelo)', 10);

                IF @@ERROR <> 0
                BEGIN
                    ROLLBACK TRANSACTION
                    PRINT 'Error en la transacción - revertiendo cambios'
                END
                ELSE
                BEGIN
                    COMMIT TRANSACTION
                    PRINT 'Transacción completada'
                END
            END
            ELSE
            BEGIN
                PRINT 'La tabla ya contiene valores'
            END
            GO";

            migrationBuilder.Sql(Sql);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
