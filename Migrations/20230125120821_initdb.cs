using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using razorweb.models;

#nullable disable

namespace razorweb.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.ID);
                });
                //Insert Data
                //Fake Data: Bogus
                Randomizer.Seed = new Random(8675309);
                var fakerArticle = new Faker<Article>();
                //phat sinh Article title cua no phat sinh tu 5 den 10 tu
                fakerArticle.RuleFor(a => a.Title,f => f.Lorem.Sentence(5,5) );
                //phat sinh ngay thang trong 1 khoang nao do
                fakerArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2023,1,29), new DateTime(2023,2,8)));
                //phat sinh noi dung van ban co chua nhieu doan van
                fakerArticle.RuleFor(a =>a.Content,f => f.Lorem.Paragraphs(1,4));
                //phat sinh article ngau nhien
                Article article = fakerArticle.Generate();
                for (int i = 0; i < 150; i++)
                {
                    migrationBuilder.InsertData(
                        table : "articles",
                        columns : new[] {"Title", "Created", "Content"},
                        values : new object[]{
                            article.Title,
                            article.Created,
                            article.Content

                        }
                    
                    );
                }
                
                
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
