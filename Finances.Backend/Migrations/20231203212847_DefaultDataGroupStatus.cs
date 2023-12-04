using Microsoft.EntityFrameworkCore.Migrations;

namespace Finances.Backend.Migrations
{
    /// <inheritdoc />
    public partial class DefaultDataGroupStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroupStatus",
                columns: ["IdGroupStatus", "Name"],
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Archived" },
                    { 3, "Deleted" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupStatus",
                keyColumn: "IdGroupStatus",
                keyColumnType: "tinyint",
                keyValues: [1, 2, 3]);
        }
    }
}
