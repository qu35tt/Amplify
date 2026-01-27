using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amplify_backend.Migrations
{
    /// <inheritdoc />
    public partial class _27_01_26v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_liked_songs_songs_SongId",
                table: "liked_songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_liked_songs",
                table: "liked_songs");

            migrationBuilder.DropColumn(
                name: "songId",
                table: "liked_songs");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "liked_songs",
                newName: "songId");

            migrationBuilder.RenameIndex(
                name: "IX_liked_songs_SongId",
                table: "liked_songs",
                newName: "IX_liked_songs_songId");

            migrationBuilder.AlterColumn<Guid>(
                name: "songId",
                table: "liked_songs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_liked_songs",
                table: "liked_songs",
                columns: new[] { "userId", "songId" });

            migrationBuilder.AddForeignKey(
                name: "FK_liked_songs_songs_songId",
                table: "liked_songs",
                column: "songId",
                principalTable: "songs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_liked_songs_songs_songId",
                table: "liked_songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_liked_songs",
                table: "liked_songs");

            migrationBuilder.RenameColumn(
                name: "songId",
                table: "liked_songs",
                newName: "SongId");

            migrationBuilder.RenameIndex(
                name: "IX_liked_songs_songId",
                table: "liked_songs",
                newName: "IX_liked_songs_SongId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_liked_songs",
                table: "liked_songs",
                columns: new[] { "userId", "songId" });

            migrationBuilder.AddForeignKey(
                name: "FK_liked_songs_songs_SongId",
                table: "liked_songs",
                column: "SongId",
                principalTable: "songs",
                principalColumn: "id");
        }
    }
}
