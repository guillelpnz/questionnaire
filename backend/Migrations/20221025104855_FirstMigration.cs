using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerType = table.Column<int>(type: "int", nullable: false),
                    AnswerContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Choices = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "AnswerContent", "AnswerType", "Choices", "Label" },
                values: new object[,]
                {
                    { 1, "", 2, "", "From 1 to 10 how much do you know about Blockchain?" },
                    { 2, "", 2, "", "From 1 to 10 how interested are you about Blockchain?" },
                    { 3, "", 1, "Yes, No", "Do you know about Blockchain?" },
                    { 4, "", 0, "A lot, Regular user, I have heard about it, Nothing", "How much do you know about Web3?" },
                    { 5, "", 2, "", "From 1 to 10 how much do you know about Ethereum?" },
                    { 6, "", 1, "Yes, No", "Do you know what Mining means?" },
                    { 7, "", 2, "", "From 1 to 10 how much do you know about cryptocurrencies?" },
                    { 8, "", 2, "", "From 1 to 10 how much do you know about Bitcoin?" },
                    { 9, "", 2, "Yes, No", "Have you ever heard about Smart contracts?" },
                    { 10, "", 2, "", "From 1 to 10 how much do you know about Smart contracts?" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { 1, "a@a.es", "Pepe", "Papa", "123456", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
