﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Questionary.Database.Context;

namespace Questionary.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Questionary.Database.Entity.QuestionChoiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Choice")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsAnswer")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionChoiceModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Choice = "schema",
                            IsAnswer = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Choice = "$schema",
                            IsAnswer = true,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 3,
                            Choice = "JsonSchema",
                            IsAnswer = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 4,
                            Choice = "JSONschema",
                            IsAnswer = false,
                            QuestionId = 1
                        },
                        new
                        {
                            Id = 5,
                            Choice = "JSON.parse()",
                            IsAnswer = false,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 6,
                            Choice = "JSON.stringify()",
                            IsAnswer = true,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 7,
                            Choice = "JSON.toString()",
                            IsAnswer = false,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 8,
                            Choice = "JSON.objectify()",
                            IsAnswer = false,
                            QuestionId = 2
                        },
                        new
                        {
                            Id = 9,
                            Choice = "string",
                            IsAnswer = true,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 10,
                            Choice = "number",
                            IsAnswer = true,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 11,
                            Choice = "date",
                            IsAnswer = false,
                            QuestionId = 3
                        },
                        new
                        {
                            Id = 12,
                            Choice = "array",
                            IsAnswer = true,
                            QuestionId = 3
                        });
                });

            modelBuilder.Entity("Questionary.Database.Entity.QuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Group")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuestionModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Group = 0,
                            Question = "By convention, what name is used for the first key in a JSON schema?",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Group = 0,
                            Question = "Which JavaScript method converts a JavaScript value to Json?",
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Group = 0,
                            Question = "Which data type is part of JSON standard?",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Questionary.Database.Entity.QuizAnswerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateAnswerd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("QuestionChoiceId")
                        .HasColumnType("int");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionChoiceId");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizAnswerModels");
                });

            modelBuilder.Entity("Questionary.Database.Entity.QuizModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("DateEnded")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateStarted")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("QuestionGroup")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("QuizModels");
                });

            modelBuilder.Entity("Questionary.Database.Entity.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("Questionary.Database.Entity.QuestionChoiceModel", b =>
                {
                    b.HasOne("Questionary.Database.Entity.QuestionModel", "QuestionModel")
                        .WithMany("QuestionChoiceModels")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionModel");
                });

            modelBuilder.Entity("Questionary.Database.Entity.QuizAnswerModel", b =>
                {
                    b.HasOne("Questionary.Database.Entity.QuestionChoiceModel", "QuestionChoiceModel")
                        .WithMany("QuizAnswerModels")
                        .HasForeignKey("QuestionChoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Questionary.Database.Entity.QuizModel", "QuizModel")
                        .WithMany("QuizAnswerModels")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionChoiceModel");

                    b.Navigation("QuizModel");
                });

            modelBuilder.Entity("Questionary.Database.Entity.QuizModel", b =>
                {
                    b.HasOne("Questionary.Database.Entity.UserModel", "UserModel")
                        .WithMany("Collection")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("Questionary.Database.Entity.QuestionChoiceModel", b =>
                {
                    b.Navigation("QuizAnswerModels");
                });

            modelBuilder.Entity("Questionary.Database.Entity.QuestionModel", b =>
                {
                    b.Navigation("QuestionChoiceModels");
                });

            modelBuilder.Entity("Questionary.Database.Entity.QuizModel", b =>
                {
                    b.Navigation("QuizAnswerModels");
                });

            modelBuilder.Entity("Questionary.Database.Entity.UserModel", b =>
                {
                    b.Navigation("Collection");
                });
#pragma warning restore 612, 618
        }
    }
}
