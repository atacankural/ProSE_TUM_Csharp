using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreateKitties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventName = table.Column<string>(type: "TEXT", nullable: false),
                    MoneyType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateKitties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CreateKittaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateKittyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participants_CreateKitties_CreateKittaId",
                        column: x => x.CreateKittaId,
                        principalTable: "CreateKitties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_CreateKitties_CreateKittyId",
                        column: x => x.CreateKittyId,
                        principalTable: "CreateKitties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonWhoCreate = table.Column<string>(type: "TEXT", nullable: false),
                    CommentText = table.Column<string>(type: "TEXT", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    WhatFor = table.Column<string>(type: "TEXT", nullable: false),
                    When = table.Column<string>(type: "TEXT", nullable: false),
                    SplitEqually = table.Column<bool>(type: "INTEGER", nullable: false),
                    SplitDifferently = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    WhatFor = table.Column<string>(type: "TEXT", nullable: false),
                    When = table.Column<string>(type: "TEXT", nullable: false),
                    SplitEqually = table.Column<bool>(type: "INTEGER", nullable: false),
                    SplitDifferently = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoneyGiven",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    WhatFor = table.Column<string>(type: "TEXT", nullable: false),
                    When = table.Column<string>(type: "TEXT", nullable: false),
                    ToWhom = table.Column<string>(type: "TEXT", nullable: false),
                    RecieverId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyGiven", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyGiven_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParticipantId",
                table: "Comments",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ParticipantId",
                table: "Expenses",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ParticipantId",
                table: "Incomes",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyGiven_ParticipantId",
                table: "MoneyGiven",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_CreateKittaId",
                table: "Participants",
                column: "CreateKittaId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_CreateKittyId",
                table: "Participants",
                column: "CreateKittyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "MoneyGiven");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "CreateKitties");
        }
    }
}
