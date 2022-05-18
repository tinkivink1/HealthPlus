﻿// <auto-generated />
using System;
using HealthPlus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthPlus.Migrations
{
    [DbContext(typeof(HealthPlusUsersContext))]
    partial class HealthPlusUsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HealthPlus.Models.Trainings", b =>
                {
                    b.Property<int>("Id_training")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_training"), 1L, 1);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("exercise_list")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("training_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("training_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("usersId")
                        .HasColumnType("int");

                    b.HasKey("Id_training");

                    b.HasIndex("usersId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("HealthPlus.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("client_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("client_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("client_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("client_surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HealthPlus.Models.Trainings", b =>
                {
                    b.HasOne("HealthPlus.Models.Users", "users")
                        .WithMany("trainings")
                        .HasForeignKey("usersId");

                    b.Navigation("users");
                });

            modelBuilder.Entity("HealthPlus.Models.Users", b =>
                {
                    b.Navigation("trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
