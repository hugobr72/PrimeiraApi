﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrimeiraApi.Data;

#nullable disable

namespace PrimeiraApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("PrimeiraApi.Models.Alarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Alarm1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Alarm2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Alarm3")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Alarm");
                });

            modelBuilder.Entity("PrimeiraApi.Models.ModelRadioManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlarmsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlarmsId");

                    b.ToTable("Radio");
                });

            modelBuilder.Entity("PrimeiraApi.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Done")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("PrimeiraApi.Models.ModelRadioManager", b =>
                {
                    b.HasOne("PrimeiraApi.Models.Alarm", "Alarms")
                        .WithMany()
                        .HasForeignKey("AlarmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alarms");
                });
#pragma warning restore 612, 618
        }
    }
}
