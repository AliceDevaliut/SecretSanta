using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TemplateService.Infrastructure.Persistence.Providers.Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class DbContex_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TMP_Metas",
                schema: "XXATACH_TMP");

            migrationBuilder.DropTable(
                name: "TMP_Documents",
                schema: "XXATACH_TMP");

            migrationBuilder.DropTable(
                name: "TMP_MetaTypes",
                schema: "XXATACH_TMP");

            migrationBuilder.EnsureSchema(
                name: "santa");

            migrationBuilder.CreateTable(
                name: "Draw",
                schema: "santa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Event_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Giver_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Receiver_Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draw", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "santa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gift",
                schema: "santa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    User_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                schema: "santa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Event_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    User_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Notification_Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Sent = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "santa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telegram = table.Column<string>(type: "text", nullable: false),
                    Wishlist = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "EventId_Index",
                schema: "santa",
                table: "User",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Draw",
                schema: "santa");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "santa");

            migrationBuilder.DropTable(
                name: "Gift",
                schema: "santa");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "santa");

            migrationBuilder.DropTable(
                name: "User",
                schema: "santa");

            migrationBuilder.EnsureSchema(
                name: "XXATACH_TMP");

            migrationBuilder.CreateTable(
                name: "TMP_Documents",
                schema: "XXATACH_TMP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMP_Documents", x => x.Id);
                },
                comment: "Документы");

            migrationBuilder.CreateTable(
                name: "TMP_MetaTypes",
                schema: "XXATACH_TMP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMP_MetaTypes", x => x.Id);
                },
                comment: "Тип мета-данных");

            migrationBuilder.CreateTable(
                name: "TMP_Metas",
                schema: "XXATACH_TMP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uuid", nullable: false),
                    MetaTypeId = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMP_Metas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TMP_Metas_TMP_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "XXATACH_TMP",
                        principalTable: "TMP_Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TMP_Metas_TMP_MetaTypes_MetaTypeId",
                        column: x => x.MetaTypeId,
                        principalSchema: "XXATACH_TMP",
                        principalTable: "TMP_MetaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Мета-описание документа");

            migrationBuilder.InsertData(
                schema: "XXATACH_TMP",
                table: "TMP_MetaTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "ID документа в СЭД АТАЧ", "atachdocumentid" },
                    { 2, "Регистрационный номер", "regnumber" },
                    { 3, "Дата регистрации", "regdate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TMP_Documents_Number",
                schema: "XXATACH_TMP",
                table: "TMP_Documents",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TMP_Metas_DocumentId",
                schema: "XXATACH_TMP",
                table: "TMP_Metas",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TMP_Metas_MetaTypeId",
                schema: "XXATACH_TMP",
                table: "TMP_Metas",
                column: "MetaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TMP_MetaTypes_Name",
                schema: "XXATACH_TMP",
                table: "TMP_MetaTypes",
                column: "Name",
                unique: true);
        }
    }
}
