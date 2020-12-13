using System;
using FluentMigrator;
using Otus.Crud.Entities;

namespace Otus.Crud.Migrations
{
    [Migration(13122020185600)]
    public class Mig_13122020_Init : Migration
    {
        public override void Up()
        {
            Create.Table(nameof(User))
                  .WithColumn("Id").AsGuid().PrimaryKey()
                  .WithColumn("FirstName").AsString().NotNullable()
                  .WithColumn("LastName").AsString().NotNullable()
                  .WithColumn("Patronymic").AsString().NotNullable()
                  .WithColumn("CreateDate").AsDateTime().NotNullable();

            InsertData();
        }

        public override void Down()
        {
            Delete.Table(nameof(User));
        }

        private void InsertData()
        {
            var user1 = new User
                        {
                            Id         = Guid.NewGuid(),
                            FirstName  = "Иван",
                            LastName   = "Иванов",
                            Patronymic = "Иванович",
                            CreateDate = DateTime.UtcNow
                        };
            
            var user2 = new User
                        {
                            Id         = Guid.NewGuid(),
                            FirstName  = "Петр",
                            LastName   = "Петров",
                            Patronymic = "Петрович",
                            CreateDate = DateTime.UtcNow
                        };
            
            Insert.IntoTable(nameof(User)).Row(user1);
            Insert.IntoTable(nameof(User)).Row(user2);
        }
    }
}