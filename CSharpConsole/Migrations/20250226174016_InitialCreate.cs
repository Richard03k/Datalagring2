using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpConsole.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fornamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Epostadress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gatuadress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
