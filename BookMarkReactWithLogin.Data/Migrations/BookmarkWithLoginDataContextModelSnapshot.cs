﻿// <auto-generated />
using BookMarkReactWithLogin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookMarkReactWithLogin.Data.Migrations
{
    [DbContext(typeof(BookmarkWithLoginDataContext))]
    partial class BookmarkWithLoginDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookMarkReactWithLogin.Data.Bookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("BookMarkReactWithLogin.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookMarkReactWithLogin.Data.UsersBookmarks", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BookmarkId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BookmarkId");

                    b.HasIndex("BookmarkId");

                    b.ToTable("UsersBookmarks");
                });

            modelBuilder.Entity("BookMarkReactWithLogin.Data.UsersBookmarks", b =>
                {
                    b.HasOne("BookMarkReactWithLogin.Data.Bookmark", "Bokmark")
                        .WithMany("UsersBookmarks")
                        .HasForeignKey("BookmarkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BookMarkReactWithLogin.Data.User", "User")
                        .WithMany("UsersBookmarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bokmark");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookMarkReactWithLogin.Data.Bookmark", b =>
                {
                    b.Navigation("UsersBookmarks");
                });

            modelBuilder.Entity("BookMarkReactWithLogin.Data.User", b =>
                {
                    b.Navigation("UsersBookmarks");
                });
#pragma warning restore 612, 618
        }
    }
}
