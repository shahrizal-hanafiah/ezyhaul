﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Context;

namespace api.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20201212092414_AddRunningNoTable")]
    partial class AddRunningNoTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("api.Models.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .HasColumnType("TEXT");

                    b.Property<long>("DeliveryDateTime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeliveryLocationName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoadDetail1")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoadDetail2")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoadDetail3")
                        .HasColumnType("TEXT");

                    b.Property<long>("PickupDateTime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PickupLocationName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShipmentNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehicleBuildUp")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehicleSize")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("api.Models.RunningNo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TodayDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<int>("referenceNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("RunningNo");
                });
#pragma warning restore 612, 618
        }
    }
}