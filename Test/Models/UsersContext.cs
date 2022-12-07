using Microsoft.EntityFrameworkCore;

namespace Test.Models;

public class UsersContext : DbContext
{
    public DbSet<Client> Clients => Set<Client>();
    public UsersContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=shop.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Иван", Age = 21, Email = "ivan@gmail.com", Address = "Курчатова 8", Telephone = "33 1245623" },
                new Client { Id = 2, Name = "Анна", Age = 18, Email = "anna@gmail.com", Address = "Каменногорская улица 13", Telephone = "29 8932091" },
                new Client { Id = 3, Name = "Дмитрий", Age = 28, Email = "dmitry@gmail.com", Address = "Петровщина 25", Telephone = "33 6829129" },
                new Client { Id = 4, Name = "Александр", Age = 35, Email = "alexander@gmail.com", Address = "ул. Братьев Райт 4", Telephone = "29 0195167" },
                new Client { Id = 5, Name = "Алиса", Age = 27, Email = "alice@gmail.com", Address = "ул. Наполеона Орды 12", Telephone = "29 5913523" },
                new Client { Id = 6, Name = "Вадим", Age = 31, Email = "vadim@gmail.com", Address = "пр. Независимости 4", Telephone = "33 1920140" },
                new Client { Id = 7, Name = "Денис", Age = 20, Email = "denis@gmail.com", Address = "ул. Притыцкого 156", Telephone = "33 6731254" },
                new Client { Id = 8, Name = "Анастасия", Age = 45, Email = "nastya@gmail.com", Address = "ул. Кирова 3", Telephone = "29 9982362" },
                new Client { Id = 9, Name = "Николай", Age = 26, Email = "nikolay@gmail.com", Address = "ул. Петруся Бровки 6", Telephone = "33 1870345" },
                new Client { Id = 10, Name = "Сергей", Age = 32, Email = "sergei@gmail.com", Address = "ул. Каролинская 5", Telephone = "29 9726423" }
        );
    }
}