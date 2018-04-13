﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using noshadow.api.Context;
using System;

namespace noshadow.api.Migrations
{
    [DbContext(typeof(NoShadowContext))]
    [Migration("20180413190952_1.0.0")]
    partial class _100
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("noshadow.api.Model.Entity.DeviceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DeviceName");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("noshadow.api.Model.Entity.LogEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DeviceId");

                    b.Property<double>("Height");

                    b.Property<double>("Latitude");

                    b.Property<DateTime>("LogDate");

                    b.Property<double>("Longitude");

                    b.Property<double>("Speed");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("noshadow.api.Model.Entity.LogEntity", b =>
                {
                    b.HasOne("noshadow.api.Model.Entity.DeviceEntity", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}