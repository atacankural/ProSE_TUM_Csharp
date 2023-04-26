﻿// <auto-generated />
using System;
using FourDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FourDemo.Migrations
{
    [DbContext(typeof(TransactionContext))]
    partial class TransactionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("FourDemo.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PersonWhoCreate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FourDemo.CreateKitty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MoneyType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CreateKitties");
                });

            modelBuilder.Entity("FourDemo.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SplitDifferently")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SplitEqually")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WhatFor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("When")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("FourDemo.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SplitDifferently")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SplitEqually")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WhatFor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("When")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("FourDemo.MoneyGiven", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecieverId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToWhom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WhatFor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("When")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("MoneyGiven");
                });

            modelBuilder.Entity("FourDemo.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreateKittaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CreateKittyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ParticipantId");

                    b.HasIndex("CreateKittaId");

                    b.HasIndex("CreateKittyId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("FourDemo.Comment", b =>
                {
                    b.HasOne("FourDemo.Participant", "Participant")
                        .WithMany("Comments")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("FourDemo.Expense", b =>
                {
                    b.HasOne("FourDemo.Participant", "Participant")
                        .WithMany("Expenses")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("FourDemo.Income", b =>
                {
                    b.HasOne("FourDemo.Participant", "Participant")
                        .WithMany("Incomes")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("FourDemo.MoneyGiven", b =>
                {
                    b.HasOne("FourDemo.Participant", "Participant")
                        .WithMany("MoneyGiven")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("FourDemo.Participant", b =>
                {
                    b.HasOne("FourDemo.CreateKitty", "CreateKitty")
                        .WithMany("Participants")
                        .HasForeignKey("CreateKittaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FourDemo.CreateKitty", null)
                        .WithMany("ParticipantsList")
                        .HasForeignKey("CreateKittyId");

                    b.Navigation("CreateKitty");
                });

            modelBuilder.Entity("FourDemo.CreateKitty", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("ParticipantsList");
                });

            modelBuilder.Entity("FourDemo.Participant", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Expenses");

                    b.Navigation("Incomes");

                    b.Navigation("MoneyGiven");
                });
#pragma warning restore 612, 618
        }
    }
}