using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthPlus.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id_training = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    training_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    training_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exercise_list = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id_training);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingsUsers",
                columns: table => new
                {
                    trainingsId_training = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingsUsers", x => new { x.trainingsId_training, x.usersId });
                    table.ForeignKey(
                        name: "FK_TrainingsUsers_Trainings_trainingsId_training",
                        column: x => x.trainingsId_training,
                        principalTable: "Trainings",
                        principalColumn: "Id_training",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingsUsers_Users_usersId",
                        column: x => x.usersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingsUsers_usersId",
                table: "TrainingsUsers",
                column: "usersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingsUsers");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
