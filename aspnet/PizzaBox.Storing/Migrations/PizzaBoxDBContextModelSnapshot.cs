﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxDBContext))]
    partial class PizzaBoxDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("PizzaBox.Domain.Models.CrustModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id")
                        .HasName("PK_CrustId");

                    b.ToTable("Crusts");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.CustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerSubmittedId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<DateTime>("PurchaseDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2(0)")
                        .HasDefaultValue(new DateTime(2021, 1, 19, 23, 23, 21, 444, DateTimeKind.Utc).AddTicks(9935));

                    b.Property<int>("StoreSubmittedId")
                        .HasColumnType("int");

                    b.Property<bool>("Submitted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id")
                        .HasName("PK_OrderId");

                    b.HasIndex("CustomerSubmittedId");

                    b.HasIndex("StoreSubmittedId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaMenuModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CrustId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_MenuPizzaId");

                    b.HasIndex("CrustId");

                    b.ToTable("PizzasMenu");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaMenuToppingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PizzaMenuId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_PizzaMenuToppingId");

                    b.HasIndex("PizzaMenuId");

                    b.HasIndex("ToppingId");

                    b.ToTable("MenuPizzaToppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CrustId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_PizzaId");

                    b.HasIndex("CrustId");

                    b.HasIndex("OrderId");

                    b.HasIndex("SizeId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaToppingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_PizzaToppingId");

                    b.HasIndex("PizzaId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaToppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.SizeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id")
                        .HasName("PK_SizeId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.StoreModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.ToppingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id")
                        .HasName("PK_ToppingId");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.OrderModel", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.CustomerModel", "CustomerSubmitted")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerSubmittedId")
                        .HasConstraintName("FK_CustomerSubmittedId")
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.StoreModel", "StoreSubmitted")
                        .WithMany("Orders")
                        .HasForeignKey("StoreSubmittedId")
                        .HasConstraintName("FK_StoreSubmittedId")
                        .IsRequired();

                    b.Navigation("CustomerSubmitted");

                    b.Navigation("StoreSubmitted");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaMenuModel", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.CrustModel", "Crust")
                        .WithMany("MenuPizzas")
                        .HasForeignKey("CrustId")
                        .HasConstraintName("FK_MenuCrustId");

                    b.Navigation("Crust");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaMenuToppingModel", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.PizzaMenuModel", "PizzaMenu")
                        .WithMany("PizzaMenuToppings")
                        .HasForeignKey("PizzaMenuId")
                        .HasConstraintName("FK_MenuPizzaId")
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.ToppingModel", "Topping")
                        .WithMany("PizzaMenuToppings")
                        .HasForeignKey("ToppingId")
                        .HasConstraintName("FK_MenuToppingId")
                        .IsRequired();

                    b.Navigation("PizzaMenu");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaModel", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.CrustModel", "Crust")
                        .WithMany("Pizzas")
                        .HasForeignKey("CrustId")
                        .HasConstraintName("FK_PizzaCrustId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.OrderModel", "Order")
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderId")
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.SizeModel", "Size")
                        .WithMany("Pizzas")
                        .HasForeignKey("SizeId")
                        .HasConstraintName("FK_PizzaSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crust");

                    b.Navigation("Order");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaToppingModel", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.PizzaModel", "Pizza")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("FK_PizzaId")
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.ToppingModel", "Topping")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("ToppingId")
                        .HasConstraintName("FK_ToppingId")
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.CrustModel", b =>
                {
                    b.Navigation("MenuPizzas");

                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.CustomerModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.OrderModel", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaMenuModel", b =>
                {
                    b.Navigation("PizzaMenuToppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaModel", b =>
                {
                    b.Navigation("PizzaToppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.SizeModel", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.StoreModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.ToppingModel", b =>
                {
                    b.Navigation("PizzaMenuToppings");

                    b.Navigation("PizzaToppings");
                });
#pragma warning restore 612, 618
        }
    }
}
