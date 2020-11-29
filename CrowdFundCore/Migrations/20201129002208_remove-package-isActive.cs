using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowdFundCore.Migrations
{
    public partial class removepackageisActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "FundingProjects",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "reward",
                table: "FundingProjects",
                newName: "Reward");

            migrationBuilder.RenameColumn(
                name: "projectid",
                table: "FundingProjects",
                newName: "Projectid");

            migrationBuilder.RenameColumn(
                name: "packageid",
                table: "FundingProjects",
                newName: "Packageid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "FundingProjects",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Reward",
                table: "FundingProjects",
                newName: "reward");

            migrationBuilder.RenameColumn(
                name: "Projectid",
                table: "FundingProjects",
                newName: "projectid");

            migrationBuilder.RenameColumn(
                name: "Packageid",
                table: "FundingProjects",
                newName: "packageid");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Packages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
