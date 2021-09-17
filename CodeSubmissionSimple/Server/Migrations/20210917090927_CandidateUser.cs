using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeSubmissionSimple.Server.Migrations
{
    public partial class CandidateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubmissionId",
                table: "AppUser",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "Discriminator", "Email", "PasswordHash", "Role" },
                values: new object[] { 2, "AppUser", "hi@ngn.com", "1254wsdeu9632fgty", "Developer" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "PasswordHash", "Role", "SubmissionId", "Surname" },
                values: new object[] { 3, "Candidate", "chux05@hotmail.com", "Promise", "1254wsdeu96sads2fgty", "Candidate", 1, "Email" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "Discriminator", "Email", "PasswordHash", "Role" },
                values: new object[] { 1, "AppUser", "ashton@gmail.com", "1254wsde9632fgty", "Admin" });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "SubmissionId", "isCompleted" },
                values: new object[] { 2, false });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "PasswordHash", "Role", "SubmissionId", "Surname" },
                values: new object[] { 4, "Candidate", "ajdk@gmail.com", "Tshgo", "12sf343sads2fgty", "Candidate", 2, "Mochaki" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_SubmissionId",
                table: "AppUser",
                column: "SubmissionId",
                unique: true,
                filter: "[SubmissionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Submissions_SubmissionId",
                table: "AppUser",
                column: "SubmissionId",
                principalTable: "Submissions",
                principalColumn: "SubmissionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Submissions_SubmissionId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_SubmissionId",
                table: "AppUser");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "SubmissionId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "SubmissionId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AppUser");

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_Candidates_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "SubmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "CandidateId", "Email", "Name", "SubmissionId", "Surname" },
                values: new object[] { 1, "chux05@hotmail.com", "Promise", 1, "Email" });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_SubmissionId",
                table: "Candidates",
                column: "SubmissionId",
                unique: true);
        }
    }
}
