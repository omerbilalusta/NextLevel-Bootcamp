using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vk.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               
INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Password]
           ,[UserTypeID])
     VALUES
           ('Ahmet'
           ,'Coban'
           ,'coban@mail.com'
           ,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'
           ,2)
INSERT INTO [dbo].[Questions]
           ([Content]
           ,[Status]
           ,[Approved])
     VALUES
           ('En iyi yemek?'
           ,'True'
           ,'True')
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}