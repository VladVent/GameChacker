﻿// <auto-generated />
using GameChacker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameChacker.Data.Migrations
{
    [DbContext(typeof(GameLibraryContext))]
    partial class GameLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameChacker.Entites.CompletedGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsGameCompleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CompletedGames");
                });

            modelBuilder.Entity("GameChacker.Entites.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompletedGameId")
                        .HasColumnType("int");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatformID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompletedGameId");

                    b.HasIndex("PlatformID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameChacker.Entites.GamePlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PlatformName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GamePlatforms");
                });

            modelBuilder.Entity("GameChacker.Entites.Game", b =>
                {
                    b.HasOne("GameChacker.Entites.CompletedGame", "CompletedGames")
                        .WithMany()
                        .HasForeignKey("CompletedGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameChacker.Entites.GamePlatform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompletedGames");

                    b.Navigation("Platform");
                });
#pragma warning restore 612, 618
        }
    }
}
