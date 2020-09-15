using Fizzle.Data;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzleTest.Data
{
    [TestClass]
    public class NumberContextTest
    {
        private DbContextOptions<NumberContext> SqlLiteMemoryContextOptions()
        {
            var connection = new SqliteConnection(new SqliteConnectionStringBuilder
            {
                DataSource = ":memory:"
            }.ToString());         
            connection.Open();

            return new DbContextOptionsBuilder<NumberContext>()
                    .UseSqlite(connection)
                    .Options;
        }

        [TestMethod]
        public void NumberContextShouldHaveSomeSeedData_WhenIntialized()
        {
            // Arrange
            using (var context = new NumberContext(SqlLiteMemoryContextOptions()))
            {
                context.Database.EnsureCreated();

                // Act
                context.Initialize();
                var result = context.Numbers;               

                // Assert
                result.Should().HaveCountGreaterThan(1);
            }
        }

        [TestMethod]
        public void NumberContextShouldHaveAllSeedData_WhenIntialized()
        {
            // Arrange
            using (var context = new NumberContext(SqlLiteMemoryContextOptions()))
            {
                context.Database.EnsureCreated();

                // Act
                context.Initialize();
                var result = context.Numbers;

                // Assert
                // Update the test if the seed data is ever updated
                // If this is a regular occurance or you plan to allow seed data to be configurable
                // Update this test and the context to accept it in another way
                result.Should().HaveCount(100);
            }
        }
    }
}
