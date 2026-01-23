using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amplify_backend.Migrations
{
    /// <inheritdoc />
    public partial class _23_01_2026v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    artistId = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<char>(type: "character(80)", maxLength: 80, nullable: false),
                    cover_art_url = table.Column<string>(type: "text", nullable: true),
                    release_date = table.Column<DateOnly>(type: "date", nullable: true),
                    genre = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userId = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    cover_image_url = table.Column<string>(type: "text", nullable: true),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    artistId = table.Column<Guid>(type: "uuid", nullable: false),
                    albumId = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    duration_secs = table.Column<int>(type: "integer", nullable: true),
                    track_number = table.Column<int>(type: "integer", nullable: true),
                    storage_Type = table.Column<int>(type: "integer", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    file_extension = table.Column<string>(type: "text", nullable: false),
                    bitrate = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "liked_songs",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SongId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_liked_songs", x => new { x.UserId, x.SongId });
                    table.ForeignKey(
                        name: "FK_liked_songs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_liked_songs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playlist_songs",
                columns: table => new
                {
                    PlaylistId = table.Column<Guid>(type: "uuid", nullable: false),
                    SongId = table.Column<Guid>(type: "uuid", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlist_songs", x => new { x.PlaylistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_playlist_songs_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playlist_songs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_liked_songs_SongId",
                table: "liked_songs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_playlist_songs_SongId",
                table: "playlist_songs",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "liked_songs");

            migrationBuilder.DropTable(
                name: "playlist_songs");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
