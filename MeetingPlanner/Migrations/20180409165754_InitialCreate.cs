using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MeetingPlanner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bulletin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ClosingPrayerName = table.Column<string>(nullable: true),
                    ClosingSongNumber = table.Column<int>(nullable: false),
                    MeetingConductor = table.Column<string>(nullable: true),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    OpeningPrayerName = table.Column<string>(nullable: true),
                    OpeningSongNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BulletinID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "FK_Speaker_Bulletin_BulletinID",
                        column: x => x.BulletinID,
                        principalTable: "Bulletin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_BulletinID",
                table: "Speaker",
                column: "BulletinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Bulletin");
        }
    }
}
