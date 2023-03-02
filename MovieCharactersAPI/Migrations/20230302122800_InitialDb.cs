using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieCharactersAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieCharacter",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCharacter", x => new { x.MovieId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "Gender", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, "Spider Ham", "Pig", "Peter Porker", "https://www.shutterstock.com/image-vector/cartoon-pig-thumb-up-vector-260nw-277426448.jpg" },
                    { 2, "Harry Plopper", "Pig", "Harry Porker", "https://static.simpsonswiki.com/images/7/7a/Plopper.png" },
                    { 3, "Peter", "Pig", "Peter Griffin", "https://static.wikia.nocookie.net/familyguy/images/a/aa/FamilyGuy_Single_PeterDrink_R7.jpg/revision/latest/scale-to-width-down/1000?cb=20200526171842" },
                    { 4, "Lois", "Female", "Lois Griffin", "https://static.wikia.nocookie.net/familyguy/images/7/7c/FamilyGuy_Single_LoisPose_R7.jpg/revision/latest/scale-to-width-down/1000?cb=20200526171843" },
                    { 5, "Meg", "Unknown", "Meg Griffin", "https://static.wikia.nocookie.net/familyguy/images/1/1b/FamilyGuy_Single_MegMakeup_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171840" },
                    { 6, "Chris", "Male", "Chris Griffin", "https://static.wikia.nocookie.net/familyguy/images/e/ee/FamilyGuy_Single_ChrisText_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171839" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The Marvel Cinematic Universe (MCU) is an American media franchise.", "Marvel Cinematic Universe" },
                    { 2, "Funny cartoons for family.", "Family Guy" },
                    { 3, "Funny cartoons for family.", "The Simpsons" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[,]
                {
                    { 1, "Kristian Wink", 3, "Sci-fi, Fantasy, Food", "https://static.simpsonswiki.com/images/archive/7/7a/20110905195950%21Plopper.png", 2099, "Harry Plopper and the bacon in the owen", "https://www.youtube.com/watch?v=MQBUfxrDN4Q&themeRefresh=1" },
                    { 2, "Marco Angeli", 1, "Sci-fi, Fantasy, Horror", "https://static.wikia.nocookie.net/marveldatabase/images/f/f6/Spider-Ham_Vol_1_1_Textless.jpg/revision/latest/scale-to-width-down/1000?cb=20190911100619", 2080, "Spider-Ham: Caught in a Ham", "https://www.youtube.com/watch?v=MY15_rcd-IQ" },
                    { 3, "Marco Angeli", 1, "Sci-fi, Fantasy, Horror", "http://www.localhero.org.uk/wp-content/uploads/2011/06/ringohamblack.jpg", 2081, "Spider-Ham 2: Revenge of the pork", "https://www.youtube.com/watch?v=MY15_rcd-IQ" },
                    { 4, "Greg Colton", 2, "Animation, Comedy", "https://www.wired.com/images_blogs/underwire/2009/12/familyguy_somethingsomethin.jpg", 2080, "Family Guy: Star wars", "https://www.imdb.com/video/vi4188209433/?playlistId=tt0888817&ref_=tt_pr_ov_vi" }
                });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCharacter_CharacterId",
                table: "MovieCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCharacter");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
