using System;
using Microsoft.EntityFrameworkCore;
using CharacterData.Models;

namespace CharacterData.Repo
{
    /// <summary>
    /// A class that contains the database context for the CharacterData application.
    /// </summary>
    public class CharacterContext : DbContext
    {
        /// <summary>
        /// A set of all characters in the database.
        /// </summary>
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Item> Item => Set<Item>();

        /// <summary>
        /// Gets called when the DbContext is configuring itself.
        /// </summary>
        /// <param name="optionsBuilder">The builder for the DbContextOptions.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Read in the connection string from a file named "connectionstring"
            // This is a secret, so it's in a file that's not checked into version control
            string ConnectionString = File.ReadAllText(@"./connectionstring");

            // Use the connection string to connect to the database
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        /// <summary>
        /// Gets called when the DbContext is building its model.
        /// This is a place to add fluent API configuration to the model.
        /// </summary>
        /// <param name="modelBuilder">The builder for the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
