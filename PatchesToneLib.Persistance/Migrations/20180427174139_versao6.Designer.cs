﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using PatchesToneLib.Persistance;
using System;

namespace PatchesToneLib.Persistance.Migrations
{
    [DbContext(typeof(DatabaseService))]
    [Migration("20180427174139_versao6")]
    partial class versao6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("PatchesToneLib.Domain.Patches.Patch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist")
                        .HasMaxLength(255);

                    b.Property<byte[]>("File");

                    b.Property<string>("FileName");

                    b.Property<string>("Genre")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Patches");
                });
#pragma warning restore 612, 618
        }
    }
}
