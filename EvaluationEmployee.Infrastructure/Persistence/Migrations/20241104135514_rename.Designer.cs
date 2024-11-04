﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _5W2H.Infrastructure.Persistence;

#nullable disable

namespace _5W2H.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AvaliationDbContext))]
    [Migration("20241104135514_rename")]
    partial class rename
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_5W2H.Core.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnswerNumber")
                        .HasColumnType("int");

                    b.Property<int>("AvaliationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("AvaliationId", "QuestionId")
                        .IsUnique();

                    b.ToTable("UserAnswers");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("GestorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LiderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GestorId");

                    b.HasIndex("LiderId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.LeaderAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnswerNumber")
                        .HasColumnType("int");

                    b.Property<int>("AvaliationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("AvaliationId", "QuestionId")
                        .IsUnique();

                    b.ToTable("LeaderAnswers");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.LeaderAvaliation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluatorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("LeaderAvaliations");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.LeaderQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LeaderAvaliationId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LeaderAvaliationId");

                    b.ToTable("LeaderQuestions");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodFuncionario")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeMo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.UserAvaliation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluatorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserAvaliations");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.UserQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserAvaliationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAvaliationId");

                    b.ToTable("UserQuestions");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.Answer", b =>
                {
                    b.HasOne("_5W2H.Core.Entities.UserAvaliation", "UserAvaliation")
                        .WithMany("Answers")
                        .HasForeignKey("AvaliationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_5W2H.Core.Entities.UserQuestion", "UserQuestion")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAvaliation");

                    b.Navigation("UserQuestion");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.Department", b =>
                {
                    b.HasOne("_5W2H.Core.Entities.User", "Gestor")
                        .WithMany()
                        .HasForeignKey("GestorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_5W2H.Core.Entities.User", "Lider")
                        .WithMany()
                        .HasForeignKey("LiderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Gestor");

                    b.Navigation("Lider");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.LeaderAnswer", b =>
                {
                    b.HasOne("_5W2H.Core.Entities.LeaderAvaliation", "LeaderAvaliation")
                        .WithMany("LeaderAnswers")
                        .HasForeignKey("AvaliationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_5W2H.Core.Entities.LeaderQuestion", "LeaderQuestion")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaderAvaliation");

                    b.Navigation("LeaderQuestion");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.LeaderQuestion", b =>
                {
                    b.HasOne("_5W2H.Core.Entities.LeaderAvaliation", null)
                        .WithMany("LeaderQuestions")
                        .HasForeignKey("LeaderAvaliationId");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.User", b =>
                {
                    b.HasOne("_5W2H.Core.Entities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.UserQuestion", b =>
                {
                    b.HasOne("_5W2H.Core.Entities.UserAvaliation", null)
                        .WithMany("Questions")
                        .HasForeignKey("UserAvaliationId");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.LeaderAvaliation", b =>
                {
                    b.Navigation("LeaderAnswers");

                    b.Navigation("LeaderQuestions");
                });

            modelBuilder.Entity("_5W2H.Core.Entities.UserAvaliation", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
