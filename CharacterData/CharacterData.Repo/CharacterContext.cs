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
        public DbSet<Equipment> Equipment => Set<Equipment>();

        /// <summary>
        /// Gets called when the DbContext is configuring itself.
        /// </summary>
        /// <param name="optionsBuilder">The builder for the DbContextOptions.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Read in the connection string from a file named "connectionstring"
            // This is a secret, so it's in a file that's not checked into version control
            string ConnectionString = File.ReadAllText("./connectionstring");

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

            // Setup the relationship between a Character and its HitPoints
            // A character has one set of hit points, and hit points are related to one character
            modelBuilder.Entity<Character>()
                .HasOne(c => c.hitPoints)
                .WithOne(h => h.character)
                .HasForeignKey<HitPoints>(h => h.characterID);

            /// <summary>
            /// Sets up the relationship between a Character and its MagicAttack.
            /// A character has one MagicAttack, and a MagicAttack is related to one character.
            /// </summary>
            /// <param name="modelBuilder">The model builder.</param>
            modelBuilder.Entity<Character>()
                .HasOne(c => c.magicAttack)  // Map the MagicAttack property of the Character entity
                .WithOne(m => m.character)   // Map the Character property of the MagicAttack entity
                .HasForeignKey<MagicAttack>(m => m.characterID);  // Use the characterID property of the MagicAttack entity as the foreign key


            /// <summary>
            /// Sets up the relationship between a Character and its MeleeAttack.
            /// A character has one MeleeAttack, and a MeleeAttack is related to one character.
            /// </summary>
            /// <param name="modelBuilder">The model builder.</param>
            modelBuilder.Entity<Character>()
                .HasOne(c => c.meleeAttack)  // Map the MeleeAttack property of the Character entity
                .WithOne(m => m.character)   // Map the Character property of the MeleeAttack entity
                .HasForeignKey<MeleeAttack>(m => m.characterID);  // Use the characterID property of the MeleeAttack entity as the foreign key


            /// <summary>
            /// Sets up the relationship between a Character and its RangedAttack.
            /// A character has one RangedAttack, and a RangedAttack is related to one character.
            /// </summary>
            /// <param name="modelBuilder">The model builder.</param>
            modelBuilder.Entity<Character>()
                .HasOne(c => c.rangedAttack)  // Map the RangedAttack property of the Character entity
                .WithOne(r => r.character)   // Map the Character property of the RangedAttack entity
                .HasForeignKey<RangedAttack>(r => r.characterID);  // Use the characterID property of the RangedAttack entity as the foreign key


            // Setup the relationship between a Character and its CharacterClass.
            // A character has one CharacterClass, and a CharacterClass is related to one character.
            modelBuilder.Entity<Character>()
                .HasOne(c => c.characterClass)
                .WithOne(f => f.character)
                .HasForeignKey<CharacterClass>(f => f.characterID);

            /// <summary>
            /// Sets up the relationship between a Character and its ArmorClass.
            /// A character has one ArmorClass, and an ArmorClass is related to one character.
            /// </summary>
            /// <param name="modelBuilder">The model builder.</param>
            modelBuilder.Entity<Character>()
                .HasOne(c => c.armorClass)
                .WithOne(g => g.character)
                .HasForeignKey<ArmorClass>(g => g.characterID);

            /// <summary>
            /// Sets up the relationship between a Character and its AbilityScores.
            /// A character has one AbilityScores, and an AbilityScores is related to one character.
            /// </summary>
            /// <param name="modelBuilder">The model builder.</param>
            modelBuilder.Entity<Character>()
                .HasOne(c => c.abilityScores)
                .WithOne(t => t.character)
                .HasForeignKey<AbilityScores>(t => t.characterID);
        }
    }
}
