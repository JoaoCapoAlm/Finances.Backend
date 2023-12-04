using Microsoft.EntityFrameworkCore.Migrations;

namespace Finances.Backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateGroupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupStatus",
                columns: table => new
                {
                    IdGroupStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStatus", x => x.IdGroupStatus);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    IdGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IdStatusIdGroupStatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.IdGroup);
                    table.ForeignKey(
                        name: "FK_Group_GroupStatus_IdStatusIdGroupStatus",
                        column: x => x.IdStatusIdGroupStatus,
                        principalTable: "GroupStatus",
                        principalColumn: "IdGroupStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_IdStatusIdGroupStatus",
                table: "Group",
                column: "IdStatusIdGroupStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "GroupStatus");
        }
    }
}
