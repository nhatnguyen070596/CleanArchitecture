using Bogus;
using Member.Domain.Entities;
using Member.Infrastructure.Persistence.Contexts;
using Microsoft.Data.Sqlite;
using Member.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace Member.IntegrationTests
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        private string dbName = "Member.db";

        public SharedDatabaseFixture()
        {
            Connection = new SqliteConnection($"Filename={dbName}");

            Seed();

            Connection.Open();
        }

        public DbConnection Connection { get; }

        public StoreContext CreateContext(DbTransaction? transaction = null)
        {
            var context = new StoreContext(new DbContextOptionsBuilder<StoreContext>().UseSqlite(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        SeedData(context); 
                    }

                    _databaseInitialized = true;
                }
            }
        }

        private void SeedData(StoreContext context)
        {
            var productIds = 1;
            var userIds = 1;
            int totalProducts = 10;
         
            var productFakerList = GenerateProducts(totalProducts,5, productIds);
            context.AddRange(productFakerList);
            context.SaveChanges();
            var userFakerList = GenerateUser(10, userIds);
            context.AddRange(userFakerList);
            context.SaveChanges();
        }
        private static List<User> GenerateUser(int count, int userIds)
        {
            var fakeUsers = new Faker<User>()
                           .RuleFor(o => o.FullName, f => $"User FullName {userIds}")
                           .RuleFor(o => o.Description, f => $"Description {userIds}")
                           .RuleFor(o => o.Id, f => userIds++)
                           .RuleFor(o => o.IsActive, f => true)
                           .RuleFor(o => o.CreatedAt, f => DateUtil.GetCurrentDate())
                           .RuleFor(o => o.UpdatedAt, f => DateUtil.GetCurrentDate());

            return fakeUsers.Generate(count);

        }
        private static List<Product> GenerateProducts(int count,int QuantityProductGreaterThanFive, int productIds)
        {
            var fakerProductsWithQuantityGreaterThanFive = new Faker<Product>()
                .RuleFor(o => o.Name, f => $"Product {productIds}")
                .RuleFor(o => o.Description, f => $"Description {productIds}")
                .RuleFor(o => o.Id, f => productIds++)
                .RuleFor(o => o.Stock, f => f.Random.Number(0, 5))
                .RuleFor(o => o.Price, f => f.Random.Double(0.01, 100))
                .RuleFor(o => o.CreatedAt, f => DateUtil.GetCurrentDate())
                .RuleFor(o => o.UpdatedAt, f => DateUtil.GetCurrentDate()).Generate(QuantityProductGreaterThanFive);

            var fakerProductsWithQuantityLowerThanFive = new Faker<Product>()
               .RuleFor(o => o.Name, f => $"Product {productIds}")
               .RuleFor(o => o.Description, f => $"Description {productIds}")
               .RuleFor(o => o.Id, f => productIds++)
               .RuleFor(o => o.Stock, f => f.Random.Number(6, 10))
               .RuleFor(o => o.Price, f => f.Random.Double(0.01, 100))
               .RuleFor(o => o.CreatedAt, f => DateUtil.GetCurrentDate())
               .RuleFor(o => o.UpdatedAt, f => DateUtil.GetCurrentDate()).Generate(count - QuantityProductGreaterThanFive);

            return fakerProductsWithQuantityGreaterThanFive.Concat(fakerProductsWithQuantityLowerThanFive).ToList();
        }

        public void Dispose() => Connection.Dispose();
    }
}

