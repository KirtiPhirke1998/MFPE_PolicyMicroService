using Microsoft.EntityFrameworkCore.Migrations;

namespace MFPE_PolicyMicroService.Migrations
{
    public partial class InitialModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyMasters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BussinessValue = table.Column<int>(type: "int", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssuredSum = table.Column<int>(type: "int", nullable: false),
                    Tenure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerPolicies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerId = table.Column<int>(type: "int", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BussinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BussinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    PolicyStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerPolicies", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConsumerPolicies_PolicyMasters_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "PolicyMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerPolicies_PolicyId",
                table: "ConsumerPolicies",
                column: "PolicyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerPolicies");

            migrationBuilder.DropTable(
                name: "PolicyMasters");
        }
    }
}
