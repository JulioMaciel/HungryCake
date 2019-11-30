using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HungryCake.API.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedsHtml",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastSuccess = table.Column<DateTime>(nullable: false),
                    LastFail = table.Column<DateTime>(nullable: false),
                    Icon = table.Column<byte[]>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UTCoffset = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UrlSite = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LoadedLastTime = table.Column<bool>(nullable: false),
                    HasPayWall = table.Column<bool>(nullable: false),
                    PatternTitle = table.Column<string>(nullable: true),
                    PatternLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedsHtml", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedsReddit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastSuccess = table.Column<DateTime>(nullable: false),
                    LastFail = table.Column<DateTime>(nullable: false),
                    Icon = table.Column<byte[]>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UTCoffset = table.Column<string>(nullable: true),
                    reddit = table.Column<string>(nullable: true),
                    Users = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedsReddit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedsRss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastSuccess = table.Column<DateTime>(nullable: false),
                    LastFail = table.Column<DateTime>(nullable: false),
                    Icon = table.Column<byte[]>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UTCoffset = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UrlRss = table.Column<string>(nullable: true),
                    UrlSite = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HasPayWall = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedsRss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedsTwitter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastSuccess = table.Column<DateTime>(nullable: false),
                    LastFail = table.Column<DateTime>(nullable: false),
                    Icon = table.Column<byte[]>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UTCoffset = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedsTwitter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    UTCoffset = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Percentage = table.Column<int>(nullable: false),
                    CaseSensitive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filter_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    QuantColumns = table.Column<int>(nullable: false),
                    QuantRows = table.Column<int>(nullable: false),
                    FontSize = table.Column<int>(nullable: false),
                    Template = table.Column<int>(nullable: false),
                    RowHeightLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grids_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GridId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RowPos = table.Column<int>(nullable: false),
                    ColumnPos = table.Column<int>(nullable: false),
                    MaxItems = table.Column<int>(nullable: false),
                    ShowSummary = table.Column<bool>(nullable: false),
                    ShowFeedIcon = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Columns_Grids_GridId",
                        column: x => x.GridId,
                        principalTable: "Grids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColumnReddit",
                columns: table => new
                {
                    ColumnId = table.Column<int>(nullable: false),
                    FeedRedditId = table.Column<int>(nullable: false),
                    FilterId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    TopRange = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnReddit", x => new { x.ColumnId, x.FeedRedditId });
                    table.ForeignKey(
                        name: "FK_ColumnReddit_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnReddit_FeedsReddit_FeedRedditId",
                        column: x => x.FeedRedditId,
                        principalTable: "FeedsReddit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnReddit_Filter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColumnRegex",
                columns: table => new
                {
                    ColumnId = table.Column<int>(nullable: false),
                    FeedRegexId = table.Column<int>(nullable: false),
                    FilterId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnRegex", x => new { x.ColumnId, x.FeedRegexId });
                    table.ForeignKey(
                        name: "FK_ColumnRegex_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnRegex_FeedsHtml_FeedRegexId",
                        column: x => x.FeedRegexId,
                        principalTable: "FeedsHtml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnRegex_Filter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColumnRss",
                columns: table => new
                {
                    ColumnId = table.Column<int>(nullable: false),
                    FeedRssId = table.Column<int>(nullable: false),
                    FilterId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnRss", x => new { x.ColumnId, x.FeedRssId });
                    table.ForeignKey(
                        name: "FK_ColumnRss_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnRss_FeedsRss_FeedRssId",
                        column: x => x.FeedRssId,
                        principalTable: "FeedsRss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnRss_Filter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColumnTwitter",
                columns: table => new
                {
                    ColumnId = table.Column<int>(nullable: false),
                    FeedTwitterId = table.Column<int>(nullable: false),
                    FilterId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnTwitter", x => new { x.ColumnId, x.FeedTwitterId });
                    table.ForeignKey(
                        name: "FK_ColumnTwitter_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnTwitter_FeedsTwitter_FeedTwitterId",
                        column: x => x.FeedTwitterId,
                        principalTable: "FeedsTwitter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnTwitter_Filter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColumnReddit_FeedRedditId",
                table: "ColumnReddit",
                column: "FeedRedditId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnReddit_FilterId",
                table: "ColumnReddit",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnRegex_FeedRegexId",
                table: "ColumnRegex",
                column: "FeedRegexId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnRegex_FilterId",
                table: "ColumnRegex",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnRss_FeedRssId",
                table: "ColumnRss",
                column: "FeedRssId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnRss_FilterId",
                table: "ColumnRss",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_Columns_GridId",
                table: "Columns",
                column: "GridId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnTwitter_FeedTwitterId",
                table: "ColumnTwitter",
                column: "FeedTwitterId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnTwitter_FilterId",
                table: "ColumnTwitter",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_UserId",
                table: "Filter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Grids_UserId",
                table: "Grids",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnReddit");

            migrationBuilder.DropTable(
                name: "ColumnRegex");

            migrationBuilder.DropTable(
                name: "ColumnRss");

            migrationBuilder.DropTable(
                name: "ColumnTwitter");

            migrationBuilder.DropTable(
                name: "FeedsReddit");

            migrationBuilder.DropTable(
                name: "FeedsHtml");

            migrationBuilder.DropTable(
                name: "FeedsRss");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "FeedsTwitter");

            migrationBuilder.DropTable(
                name: "Filter");

            migrationBuilder.DropTable(
                name: "Grids");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
