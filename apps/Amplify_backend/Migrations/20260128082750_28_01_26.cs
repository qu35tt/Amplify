using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amplify_backend.Migrations
{
    /// <inheritdoc />
    public partial class _28_01_26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlist_songs_playlists_PlaylistId",
                table: "playlist_songs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlist_songs_songs_SongId",
                table: "playlist_songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlist_songs",
                table: "playlist_songs");

            migrationBuilder.DropIndex(
                name: "IX_playlist_songs_PlaylistId",
                table: "playlist_songs");

            migrationBuilder.DropColumn(
                name: "playlistId",
                table: "playlist_songs");

            migrationBuilder.DropColumn(
                name: "songId",
                table: "playlist_songs");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "playlist_songs",
                newName: "songId");

            migrationBuilder.RenameColumn(
                name: "PlaylistId",
                table: "playlist_songs",
                newName: "playlistId");

            migrationBuilder.RenameIndex(
                name: "IX_playlist_songs_SongId",
                table: "playlist_songs",
                newName: "IX_playlist_songs_songId");

            migrationBuilder.AlterColumn<Guid>(
                name: "songId",
                table: "playlist_songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "playlistId",
                table: "playlist_songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlist_songs",
                table: "playlist_songs",
                columns: new[] { "playlistId", "songId" });

            migrationBuilder.AddForeignKey(
                name: "FK_playlist_songs_playlists_playlistId",
                table: "playlist_songs",
                column: "playlistId",
                principalTable: "playlists",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlist_songs_songs_songId",
                table: "playlist_songs",
                column: "songId",
                principalTable: "songs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlist_songs_playlists_playlistId",
                table: "playlist_songs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlist_songs_songs_songId",
                table: "playlist_songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlist_songs",
                table: "playlist_songs");

            migrationBuilder.RenameColumn(
                name: "songId",
                table: "playlist_songs",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "playlistId",
                table: "playlist_songs",
                newName: "PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_playlist_songs_songId",
                table: "playlist_songs",
                newName: "IX_playlist_songs_SongId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SongId",
                table: "playlist_songs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlaylistId",
                table: "playlist_songs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "playlistId",
                table: "playlist_songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "songId",
                table: "playlist_songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlist_songs",
                table: "playlist_songs",
                columns: new[] { "playlistId", "songId" });

            migrationBuilder.CreateIndex(
                name: "IX_playlist_songs_PlaylistId",
                table: "playlist_songs",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_playlist_songs_playlists_PlaylistId",
                table: "playlist_songs",
                column: "PlaylistId",
                principalTable: "playlists",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_playlist_songs_songs_SongId",
                table: "playlist_songs",
                column: "SongId",
                principalTable: "songs",
                principalColumn: "id");
        }
    }
}
