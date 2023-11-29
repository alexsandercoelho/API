using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddFuncionalities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 679, DateTimeKind.Local).AddTicks(9182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 679, DateTimeKind.Local).AddTicks(8779),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Flags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 679, DateTimeKind.Local).AddTicks(9465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 679, DateTimeKind.Local).AddTicks(9725),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "EarlyBirds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 680, DateTimeKind.Local).AddTicks(63),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "DistributionRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 680, DateTimeKind.Local).AddTicks(912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "DistributionGroup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 680, DateTimeKind.Local).AddTicks(665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Changes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 680, DateTimeKind.Local).AddTicks(369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5447));

            migrationBuilder.CreateTable(
                name: "Funcionalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProfile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 680, DateTimeKind.Local).AddTicks(1179))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionalities_Profiles_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionalities_IdProfile",
                table: "Funcionalities",
                column: "IdProfile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionalities");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 679, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(3854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 679, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Flags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4567),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 679, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4801),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 679, DateTimeKind.Local).AddTicks(9725));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "EarlyBirds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5102),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 680, DateTimeKind.Local).AddTicks(63));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "DistributionRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(6252),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 680, DateTimeKind.Local).AddTicks(912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "DistributionGroup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 680, DateTimeKind.Local).AddTicks(665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Changes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 52, 46, 680, DateTimeKind.Local).AddTicks(369));
        }
    }
}
