﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pro2.DB;

#nullable disable

namespace pro2.Migrations
{
    [DbContext(typeof(AirportContext))]
    [Migration("20230524103103_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("pro2.DB.FlightDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EnterTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExitTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("FlightId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
