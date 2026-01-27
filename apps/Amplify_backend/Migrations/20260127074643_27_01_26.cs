using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amplify_backend.Migrations
{
    /// <inheritdoc />
    public partial class _27_01_26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_liked_songs_Songs_SongId",
                table: "liked_songs");

            migrationBuilder.DropForeignKey(
                name: "FK_liked_songs_Users_UserId",
                table: "liked_songs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlist_songs_Playlists_PlaylistId",
                table: "playlist_songs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlist_songs_Songs_SongId",
                table: "playlist_songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlist_songs",
                table: "playlist_songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_liked_songs",
                table: "liked_songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "display_name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "duration_secs",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "track_number",
                table: "Songs");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "songs");

            migrationBuilder.RenameTable(
                name: "Playlists",
                newName: "playlists");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "artists");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "albums");

            migrationBuilder.RenameColumn(
                name: "AvatarUrl",
                table: "users",
                newName: "avatarUrl");

            migrationBuilder.RenameColumn(
                name: "storage_Type",
                table: "songs",
                newName: "trackNumber");

            migrationBuilder.RenameColumn(
                name: "file_path",
                table: "songs",
                newName: "filePath");

            migrationBuilder.RenameColumn(
                name: "file_extension",
                table: "songs",
                newName: "fileExtension");

            migrationBuilder.RenameColumn(
                name: "cover_image_url",
                table: "playlists",
                newName: "coverImageUrl");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "playlist_songs",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "AddedAt",
                table: "playlist_songs",
                newName: "addedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "liked_songs",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "liked_songs",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "artists",
                newName: "bio");

            migrationBuilder.RenameColumn(
                name: "AvatarUrl",
                table: "artists",
                newName: "imageUrl");

            migrationBuilder.RenameColumn(
                name: "release_date",
                table: "albums",
                newName: "releaseDate");

            migrationBuilder.RenameColumn(
                name: "cover_art_url",
                table: "albums",
                newName: "coverArtUrl");

            migrationBuilder.AddColumn<string>(
                name: "displayName",
                table: "users",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationSeconds",
                table: "songs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "storageType",
                table: "songs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isPublic",
                table: "playlists",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AlterColumn<Guid>(
                name: "SongId",
                table: "liked_songs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "songId",
                table: "liked_songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "albums",
                type: "character varying(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(80)",
                oldMaxLength: 80);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_songs",
                table: "songs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlists",
                table: "playlists",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlist_songs",
                table: "playlist_songs",
                columns: new[] { "playlistId", "songId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_liked_songs",
                table: "liked_songs",
                columns: new[] { "userId", "songId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_artists",
                table: "artists",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_albums",
                table: "albums",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_songs_albumId",
                table: "songs",
                column: "albumId");

            migrationBuilder.CreateIndex(
                name: "IX_songs_artistId",
                table: "songs",
                column: "artistId");

            migrationBuilder.CreateIndex(
                name: "IX_playlists_userId",
                table: "playlists",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_playlist_songs_PlaylistId",
                table: "playlist_songs",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_albums_artistId",
                table: "albums",
                column: "artistId");

            migrationBuilder.AddForeignKey(
                name: "FK_albums_artists_artistId",
                table: "albums",
                column: "artistId",
                principalTable: "artists",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_liked_songs_songs_SongId",
                table: "liked_songs",
                column: "SongId",
                principalTable: "songs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_liked_songs_users_userId",
                table: "liked_songs",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_playlists_users_userId",
                table: "playlists",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_albums_albumId",
                table: "songs",
                column: "albumId",
                principalTable: "albums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_songs_artists_artistId",
                table: "songs",
                column: "artistId",
                principalTable: "artists",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_albums_artists_artistId",
                table: "albums");

            migrationBuilder.DropForeignKey(
                name: "FK_liked_songs_songs_SongId",
                table: "liked_songs");

            migrationBuilder.DropForeignKey(
                name: "FK_liked_songs_users_userId",
                table: "liked_songs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlist_songs_playlists_PlaylistId",
                table: "playlist_songs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlist_songs_songs_SongId",
                table: "playlist_songs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlists_users_userId",
                table: "playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_albums_albumId",
                table: "songs");

            migrationBuilder.DropForeignKey(
                name: "FK_songs_artists_artistId",
                table: "songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_songs",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_albumId",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_artistId",
                table: "songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlists",
                table: "playlists");

            migrationBuilder.DropIndex(
                name: "IX_playlists_userId",
                table: "playlists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlist_songs",
                table: "playlist_songs");

            migrationBuilder.DropIndex(
                name: "IX_playlist_songs_PlaylistId",
                table: "playlist_songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_liked_songs",
                table: "liked_songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_artists",
                table: "artists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_albums",
                table: "albums");

            migrationBuilder.DropIndex(
                name: "IX_albums_artistId",
                table: "albums");

            migrationBuilder.DropColumn(
                name: "displayName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "durationSeconds",
                table: "songs");

            migrationBuilder.DropColumn(
                name: "storageType",
                table: "songs");

            migrationBuilder.DropColumn(
                name: "isPublic",
                table: "playlists");

            migrationBuilder.DropColumn(
                name: "playlistId",
                table: "playlist_songs");

            migrationBuilder.DropColumn(
                name: "songId",
                table: "playlist_songs");

            migrationBuilder.DropColumn(
                name: "songId",
                table: "liked_songs");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "songs",
                newName: "Songs");

            migrationBuilder.RenameTable(
                name: "playlists",
                newName: "Playlists");

            migrationBuilder.RenameTable(
                name: "artists",
                newName: "Artists");

            migrationBuilder.RenameTable(
                name: "albums",
                newName: "Albums");

            migrationBuilder.RenameColumn(
                name: "avatarUrl",
                table: "Users",
                newName: "AvatarUrl");

            migrationBuilder.RenameColumn(
                name: "trackNumber",
                table: "Songs",
                newName: "storage_Type");

            migrationBuilder.RenameColumn(
                name: "filePath",
                table: "Songs",
                newName: "file_path");

            migrationBuilder.RenameColumn(
                name: "fileExtension",
                table: "Songs",
                newName: "file_extension");

            migrationBuilder.RenameColumn(
                name: "coverImageUrl",
                table: "Playlists",
                newName: "cover_image_url");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "playlist_songs",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "addedAt",
                table: "playlist_songs",
                newName: "AddedAt");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "liked_songs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "liked_songs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "bio",
                table: "Artists",
                newName: "Bio");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Artists",
                newName: "AvatarUrl");

            migrationBuilder.RenameColumn(
                name: "releaseDate",
                table: "Albums",
                newName: "release_date");

            migrationBuilder.RenameColumn(
                name: "coverArtUrl",
                table: "Albums",
                newName: "cover_art_url");

            migrationBuilder.AddColumn<string>(
                name: "display_name",
                table: "Users",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "duration_secs",
                table: "Songs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "track_number",
                table: "Songs",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SongId",
                table: "playlist_songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PlaylistId",
                table: "playlist_songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SongId",
                table: "liked_songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<char>(
                name: "title",
                table: "Albums",
                type: "character(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(80)",
                oldMaxLength: 80);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlist_songs",
                table: "playlist_songs",
                columns: new[] { "PlaylistId", "SongId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_liked_songs",
                table: "liked_songs",
                columns: new[] { "UserId", "SongId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_liked_songs_Songs_SongId",
                table: "liked_songs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_liked_songs_Users_UserId",
                table: "liked_songs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlist_songs_Playlists_PlaylistId",
                table: "playlist_songs",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlist_songs_Songs_SongId",
                table: "playlist_songs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
