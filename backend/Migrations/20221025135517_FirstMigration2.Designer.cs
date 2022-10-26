﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221025135517_FirstMigration2")]
    partial class FirstMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi.Entities.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<string>("AnswerContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnswerType")
                        .HasColumnType("int");

                    b.Property<string>("Choices")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionnaireId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            AnswerContent = "",
                            AnswerType = 2,
                            Choices = "",
                            Label = "From 1 to 10 how much do you know about Blockchain?",
                            QuestionnaireId = 1
                        },
                        new
                        {
                            QuestionId = 2,
                            AnswerContent = "",
                            AnswerType = 2,
                            Choices = "",
                            Label = "From 1 to 10 how interested are you about Blockchain?",
                            QuestionnaireId = 1
                        },
                        new
                        {
                            QuestionId = 3,
                            AnswerContent = "",
                            AnswerType = 1,
                            Choices = "Yes, No",
                            Label = "Do you know about Blockchain?",
                            QuestionnaireId = 1
                        },
                        new
                        {
                            QuestionId = 4,
                            AnswerContent = "",
                            AnswerType = 0,
                            Choices = "A lot, Regular user, I have heard about it, Nothing",
                            Label = "How much do you know about Web3?",
                            QuestionnaireId = 1
                        },
                        new
                        {
                            QuestionId = 5,
                            AnswerContent = "",
                            AnswerType = 2,
                            Choices = "",
                            Label = "From 1 to 10 how much do you know about Ethereum?",
                            QuestionnaireId = 1
                        },
                        new
                        {
                            QuestionId = 6,
                            AnswerContent = "",
                            AnswerType = 1,
                            Choices = "Yes, No",
                            Label = "Do you know what Mining means?",
                            QuestionnaireId = 1
                        },
                        new
                        {
                            QuestionId = 7,
                            AnswerContent = "",
                            AnswerType = 2,
                            Choices = "",
                            Label = "From 1 to 10 how much do you know about cryptocurrencies?",
                            QuestionnaireId = 1
                        },
                        new
                        {
                            QuestionId = 8,
                            AnswerContent = "",
                            AnswerType = 2,
                            Choices = "",
                            Label = "From 1 to 10 how much do you know about Bitcoin?",
                            QuestionnaireId = 1
                        },
                        new
                        {
                            QuestionId = 9,
                            AnswerContent = "",
                            AnswerType = 2,
                            Choices = "Yes, No",
                            Label = "Have you ever heard about Smart contracts?",
                            QuestionnaireId = 1
                        },
                        new
                        {
                            QuestionId = 10,
                            AnswerContent = "",
                            AnswerType = 2,
                            Choices = "",
                            Label = "From 1 to 10 how much do you know about Smart contracts?",
                            QuestionnaireId = 1
                        });
                });

            modelBuilder.Entity("WebApi.Entities.Questionnaire", b =>
                {
                    b.Property<int>("QuestionnaireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionnaireId"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("QuestionnaireId");

                    b.ToTable("Questionnaire");

                    b.HasData(
                        new
                        {
                            QuestionnaireId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "a@a.es",
                            FirstName = "Pepe",
                            LastName = "Papa",
                            Password = "123456",
                            Role = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
