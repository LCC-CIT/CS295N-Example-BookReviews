﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReviews.Migrations
{
<<<<<<< HEAD:BookReviews/BookReviews/Migrations/20221110015604_MySqlInitial.cs
    public partial class MySqlInitial : Migration
=======
    public partial class InitialSqlServer : Migration
>>>>>>> 00585bbc52995d7262b6d190da5c90bbb7419666:BookReviews/BookReviews/Migrations/20221109212801_InitialSqlServer.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(nullable: false)
<<<<<<< HEAD:BookReviews/BookReviews/Migrations/20221110015604_MySqlInitial.cs
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
=======
                        .Annotation("SqlServer:Identity", "1, 1"),
>>>>>>> 00585bbc52995d7262b6d190da5c90bbb7419666:BookReviews/BookReviews/Migrations/20221109212801_InitialSqlServer.cs
                    UserName = table.Column<string>(nullable: true),
                    SignUpDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
<<<<<<< HEAD:BookReviews/BookReviews/Migrations/20221110015604_MySqlInitial.cs
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
=======
                        .Annotation("SqlServer:Identity", "1, 1"),
>>>>>>> 00585bbc52995d7262b6d190da5c90bbb7419666:BookReviews/BookReviews/Migrations/20221109212801_InitialSqlServer.cs
                    BookTitle = table.Column<string>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    Isbn = table.Column<int>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    PubDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
<<<<<<< HEAD:BookReviews/BookReviews/Migrations/20221110015604_MySqlInitial.cs
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
=======
                        .Annotation("SqlServer:Identity", "1, 1"),
>>>>>>> 00585bbc52995d7262b6d190da5c90bbb7419666:BookReviews/BookReviews/Migrations/20221109212801_InitialSqlServer.cs
                    BookId = table.Column<int>(nullable: true),
                    ReviewerAppUserId = table.Column<int>(nullable: true),
                    ReviewText = table.Column<string>(nullable: true),
                    ReviewDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AppUsers_ReviewerAppUserId",
                        column: x => x.ReviewerAppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerAppUserId",
                table: "Reviews",
                column: "ReviewerAppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
