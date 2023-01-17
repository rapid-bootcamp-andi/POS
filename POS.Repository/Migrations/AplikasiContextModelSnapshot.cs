﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.Repository;

#nullable disable

namespace POS.Repository.Migrations
{
    [DbContext(typeof(AplikasiContext))]
    partial class AplikasiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("POS.Repository.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("picture");

                    b.HasKey("CategoryId");

                    b.ToTable("tbl_category");
                });

            modelBuilder.Entity("POS.Repository.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("company_name");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_name");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_title");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fax");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("region");

                    b.HasKey("CustomerId");

                    b.ToTable("tbl_customer");
                });

            modelBuilder.Entity("POS.Repository.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("extension");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hire_date");

                    b.Property<string>("HomePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("home_phone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("notes");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("photo");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("photo_path");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("region");

                    b.Property<int>("ReportsTo")
                        .HasColumnType("int")
                        .HasColumnName("reports_to");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<string>("TitleOfCourtesy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title_of_courtesy");

                    b.HasKey("EmployeeId");

                    b.ToTable("tbl_employee");
                });

            modelBuilder.Entity("POS.Repository.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<int>("Freight")
                        .HasColumnType("int")
                        .HasColumnName("freight");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("order_date");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("required_date");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_address");

                    b.Property<string>("ShipCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_city");

                    b.Property<string>("ShipCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_country");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_name");

                    b.Property<string>("ShipPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_postal_code");

                    b.Property<string>("ShipRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ship_region");

                    b.Property<int>("ShipVia")
                        .HasColumnType("int")
                        .HasColumnName("ship_via");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("shipped_date");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("tbl_order");
                });

            modelBuilder.Entity("POS.Repository.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_detail_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"), 1L, 1);

                    b.Property<int>("Discount")
                        .HasColumnType("int")
                        .HasColumnName("discount");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int")
                        .HasColumnName("unit_price");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("tbl_order_detail");
                });

            modelBuilder.Entity("POS.Repository.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int>("Discontinued")
                        .HasColumnType("int")
                        .HasColumnName("discontinued");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("product_name");

                    b.Property<string>("QuantityPerUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("quantity_per_unit");

                    b.Property<int>("RecorderLevel")
                        .HasColumnType("int")
                        .HasColumnName("recorder_level");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("supplier_id");

                    b.Property<int>("UnitInStock")
                        .HasColumnType("int")
                        .HasColumnName("unit_in_stock");

                    b.Property<int>("UnitOnOrder")
                        .HasColumnType("int")
                        .HasColumnName("unit_on_order");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int")
                        .HasColumnName("unit_price");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("tbl_product");
                });

            modelBuilder.Entity("POS.Repository.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("supplier_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("company_name");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_name");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_title");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fax");

                    b.Property<string>("Homepage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("homepage");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("region");

                    b.HasKey("SupplierId");

                    b.ToTable("tbl_supplier");
                });

            modelBuilder.Entity("POS.Repository.Order", b =>
                {
                    b.HasOne("POS.Repository.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("POS.Repository.OrderDetail", b =>
                {
                    b.HasOne("POS.Repository.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.Product", "Product")
                        .WithMany("OrderDetail")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("POS.Repository.Product", b =>
                {
                    b.HasOne("POS.Repository.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.Supplier", "Supplier")
                        .WithMany("Product")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("POS.Repository.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("POS.Repository.Customer", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("POS.Repository.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("POS.Repository.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("POS.Repository.Product", b =>
                {
                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("POS.Repository.Supplier", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
