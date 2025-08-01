﻿// <auto-generated />
using System;
using AirlineBookingSystem.Invoices.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirlineBookingSystem.Invoices.Infrastructure.Migrations
{
    [DbContext(typeof(InvoicesDbContext))]
    partial class InvoicesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.7");

            modelBuilder.Entity("AirlineBookingSystem.Invoices.Core.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 199.99m,
                            CustomerEmail = "user1@example.com",
                            CustomerName = "Alice Smith",
                            FlightNumber = "DY1550",
                            PaymentDate = new DateTime(2025, 10, 12, 14, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amount = 149.50m,
                            CustomerEmail = "user2@example.com",
                            CustomerName = "Bob Johnson",
                            FlightNumber = "LH2021",
                            PaymentDate = new DateTime(2025, 10, 13, 9, 15, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amount = 275.20m,
                            CustomerEmail = "user3@example.com",
                            CustomerName = "Charlie Williams",
                            FlightNumber = "AF1133",
                            PaymentDate = new DateTime(2025, 11, 1, 17, 45, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amount = 189.00m,
                            CustomerEmail = "user4@example.com",
                            CustomerName = "Diana Brown",
                            FlightNumber = "BA804",
                            PaymentDate = new DateTime(2025, 11, 5, 6, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amount = 129.45m,
                            CustomerEmail = "user5@example.com",
                            CustomerName = "Ethan Jones",
                            FlightNumber = "SK1502",
                            PaymentDate = new DateTime(2025, 10, 20, 12, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            Amount = 215.80m,
                            CustomerEmail = "user6@example.com",
                            CustomerName = "Fiona Garcia",
                            FlightNumber = "AY432",
                            PaymentDate = new DateTime(2025, 11, 8, 10, 10, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            Amount = 305.00m,
                            CustomerEmail = "user7@example.com",
                            CustomerName = "George Martinez",
                            FlightNumber = "TK1891",
                            PaymentDate = new DateTime(2025, 12, 2, 21, 45, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            Amount = 170.10m,
                            CustomerEmail = "user8@example.com",
                            CustomerName = "Hannah Davis",
                            FlightNumber = "KLM1187",
                            PaymentDate = new DateTime(2025, 10, 27, 13, 20, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            Amount = 112.75m,
                            CustomerEmail = "user9@example.com",
                            CustomerName = "Ian Rodriguez",
                            FlightNumber = "W61302",
                            PaymentDate = new DateTime(2025, 11, 3, 7, 10, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            Amount = 225.30m,
                            CustomerEmail = "user10@example.com",
                            CustomerName = "Julia Lopez",
                            FlightNumber = "LO285",
                            PaymentDate = new DateTime(2025, 11, 10, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            Amount = 160.00m,
                            CustomerEmail = "user1@example.com",
                            CustomerName = "Alice Smith",
                            FlightNumber = "IB3517",
                            PaymentDate = new DateTime(2025, 10, 30, 15, 50, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            Amount = 198.88m,
                            CustomerEmail = "user2@example.com",
                            CustomerName = "Bob Johnson",
                            FlightNumber = "AZ6051",
                            PaymentDate = new DateTime(2025, 12, 12, 22, 15, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 13,
                            Amount = 142.60m,
                            CustomerEmail = "user3@example.com",
                            CustomerName = "Charlie Williams",
                            FlightNumber = "LX1624",
                            PaymentDate = new DateTime(2025, 11, 14, 8, 40, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 14,
                            Amount = 134.00m,
                            CustomerEmail = "user4@example.com",
                            CustomerName = "Diana Brown",
                            FlightNumber = "EZY4283",
                            PaymentDate = new DateTime(2025, 10, 31, 5, 55, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 15,
                            Amount = 210.75m,
                            CustomerEmail = "user5@example.com",
                            CustomerName = "Ethan Jones",
                            FlightNumber = "DY1963",
                            PaymentDate = new DateTime(2025, 11, 18, 16, 10, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
