using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "santa1");

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "santa1",
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
                schema: "santa1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                schema: "santa1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
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
                schema: "santa1",
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
                    table.ForeignKey(
                        name: "FK_EventEntity_UserEntity",
                        column: x => x.EventId,
                        principalSchema: "santa1",
                        principalTable: "Event",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Draw",
                schema: "santa1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    GiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecieverId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draw", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Draw_User_GiverId",
                        column: x => x.GiverId,
                        principalSchema: "santa1",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Draw_User_RecieverId",
                        column: x => x.RecieverId,
                        principalSchema: "santa1",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EventId_Index1",
                schema: "santa1",
                table: "Draw",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "GiverId_Index",
                schema: "santa1",
                table: "Draw",
                column: "GiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Draw_RecieverId",
                schema: "santa1",
                table: "Draw",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "ReceiverId_Index",
                schema: "santa1",
                table: "Draw",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "UserId_Index",
                schema: "santa1",
                table: "Gift",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EventId_Index",
                schema: "santa1",
                table: "User",
                column: "EventId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Draw",
                schema: "santa1");

            migrationBuilder.DropTable(
                name: "Gift",
                schema: "santa1");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "santa1");

            migrationBuilder.DropTable(
                name: "User",
                schema: "santa1");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "santa1");
        }
    }
}
