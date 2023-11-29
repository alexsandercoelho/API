using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddDistribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(1419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(3854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Flags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4567),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4801),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(2043));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "EarlyBirds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5102),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Changes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.CreateTable(
                name: "DistributionRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(6252))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistributionGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonQty = table.Column<int>(type: "int", nullable: false),
                    AssociatedVersions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyComparison = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssociatedValues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDistributionRules = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5793))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistributionGroup_DistributionRules_IdDistributionRules",
                        column: x => x.IdDistributionRules,
                        principalTable: "DistributionRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistributionGroup_IdDistributionRules",
                table: "DistributionGroup",
                column: "IdDistributionRules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistributionGroup");

            migrationBuilder.DropTable(
                name: "DistributionRules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(1419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(3854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Flags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(1779),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(2043),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "EarlyBirds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(2385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Changes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 24, 14, 3, 36, 656, DateTimeKind.Local).AddTicks(2761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 29, 8, 40, 2, 77, DateTimeKind.Local).AddTicks(5447));
        }
    }
}
