using Finances.Backend.Model;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finances.Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateGroupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupStatus",
                columns: table => new
                {
                    IdGroupStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 256, nullable: false),
                }, constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStatus", x => x.IdGroupStatus);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    IdGroup = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IdStatus = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: 1),
                }, constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.IdGroup);
                    table.ForeignKey(
                        name: "FK_Group_GroupStatus_IdGroupStatus",
                        column: x => x.IdStatus,
                        principalTable: "GroupStatus",
                        principalColumn: "IdGroupStatus",
                        onDelete: ReferentialAction.Restrict,
                        onUpdate: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Group");
            migrationBuilder.DropTable("GroupStatus");
        }
    }
}
