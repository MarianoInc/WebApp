using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientRegister.Data.Migrations
{
    public partial class CreateClientsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverLicense = table.Column<bool>(type: "bit", nullable: false),
                    UseGlasses = table.Column<bool>(type: "bit", nullable: false),
                    IsDiabetic = table.Column<bool>(type: "bit", nullable: false),
                    OtherDisease = table.Column<bool>(type: "bit", nullable: false),
                    Disease = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Age", "DNI", "DeletedAt", "Disease", "DriverLicense", "FullName", "Gender", "IsActive", "IsDiabetic", "ModifiedAt", "OtherDisease", "Properties", "UseGlasses" },
                values: new object[,]
                {
                    { 1, 21, 12345672, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Client Name1", "Female", true, false, new DateTime(2022, 5, 6, 21, 43, 49, 809, DateTimeKind.Local).AddTicks(5733), false, null, true },
                    { 2, 22, 12345673, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Client Name2", "Male", true, false, new DateTime(2022, 5, 6, 21, 43, 49, 812, DateTimeKind.Local).AddTicks(2278), false, null, true },
                    { 3, 23, 12345674, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Client Name3", "Female", true, false, new DateTime(2022, 5, 6, 21, 43, 49, 812, DateTimeKind.Local).AddTicks(2423), false, null, true },
                    { 4, 24, 12345675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Client Name4", "Male", true, false, new DateTime(2022, 5, 6, 21, 43, 49, 812, DateTimeKind.Local).AddTicks(2432), false, null, true },
                    { 5, 25, 12345676, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Client Name5", "Female", true, false, new DateTime(2022, 5, 6, 21, 43, 49, 812, DateTimeKind.Local).AddTicks(2438), false, null, true },
                    { 6, 26, 12345677, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Client Name6", "Male", true, false, new DateTime(2022, 5, 6, 21, 43, 49, 812, DateTimeKind.Local).AddTicks(2448), false, null, true },
                    { 7, 27, 12345678, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Client Name7", "Female", true, false, new DateTime(2022, 5, 6, 21, 43, 49, 812, DateTimeKind.Local).AddTicks(2453), false, null, true },
                    { 8, 28, 12345679, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Client Name8", "Male", true, false, new DateTime(2022, 5, 6, 21, 43, 49, 812, DateTimeKind.Local).AddTicks(2459), false, null, true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeletedAt", "Description", "IsActive", "ModifiedAt", "Name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator rol type", true, new DateTime(2022, 5, 6, 21, 43, 49, 818, DateTimeKind.Local).AddTicks(1712), "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedAt", "IsActive", "ModifiedAt", "Password", "RolesId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 5, 6, 21, 43, 49, 817, DateTimeKind.Local).AddTicks(5635), "e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a", 1, "Admin 1" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 5, 6, 21, 43, 49, 817, DateTimeKind.Local).AddTicks(6312), "e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a", 1, "Admin 2" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 5, 6, 21, 43, 49, 817, DateTimeKind.Local).AddTicks(6396), "e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a", 1, "Admin 3" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 5, 6, 21, 43, 49, 817, DateTimeKind.Local).AddTicks(6490), "e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a", 1, "Admin 4" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2022, 5, 6, 21, 43, 49, 817, DateTimeKind.Local).AddTicks(6610), "e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a", 1, "Admin 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesId",
                table: "Users",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
