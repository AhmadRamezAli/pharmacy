﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pharmacy.Infrastracture.DataContext;

#nullable disable

namespace Pharmacy.Infrastracture.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    [Migration("20240701080538_ADD")]
    partial class ADD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Arabic_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(225)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(225)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(225)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(225)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.CategoryDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.CompanyDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.DiseaseDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Disease", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.DiseaseMedicineDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Disease")
                        .HasColumnType("int");

                    b.Property<int>("Medicine")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Disease");

                    b.HasIndex(new[] { "Medicine", "Disease" }, "IX_PersonMedicine")
                        .IsUnique();

                    b.ToTable("DiseaseMedicine", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.IngredientDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Ingredient", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.MedicienIngredientDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Ingredient")
                        .HasColumnType("int");

                    b.Property<int>("Medicine")
                        .HasColumnType("int");

                    b.Property<decimal>("Ratio")
                        .HasColumnType("numeric(10,7)");

                    b.HasKey("Id");

                    b.HasIndex("Ingredient");

                    b.HasIndex("Medicine");

                    b.ToTable("MedicienIngredient", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.MedicineDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("Company")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Dosage")
                        .HasColumnType("numeric(18,5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ScientificName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Category");

                    b.HasIndex("Company");

                    b.ToTable("Medicine", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.PatientDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.PatientDiseaseDAO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Disease")
                        .HasColumnType("int");

                    b.Property<int>("Patient")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Disease");

                    b.HasIndex("Patient");

                    b.ToTable("PatientDisease", (string)null);
                });

            modelBuilder.Entity("Pharmacy.Presentation.Models.User.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Pharmacy.Presentation.Models.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Pharmacy.Presentation.Models.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pharmacy.Presentation.Models.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Pharmacy.Presentation.Models.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.DiseaseMedicineDAO", b =>
                {
                    b.HasOne("Pharmacy.Infrastracture.Models.DiseaseDAO", "DiseaseNavigation")
                        .WithMany("DiseaseMedicines")
                        .HasForeignKey("Disease")
                        .IsRequired()
                        .HasConstraintName("FK_DiseaseMedicine_Disease");

                    b.HasOne("Pharmacy.Infrastracture.Models.MedicineDAO", "MedicineNavigation")
                        .WithMany("DiseaseMedicines")
                        .HasForeignKey("Medicine")
                        .IsRequired()
                        .HasConstraintName("FK_DiseaseMedicine_Medicine");

                    b.Navigation("DiseaseNavigation");

                    b.Navigation("MedicineNavigation");
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.MedicienIngredientDAO", b =>
                {
                    b.HasOne("Pharmacy.Infrastracture.Models.IngredientDAO", "IngredientNavigation")
                        .WithMany("MedicienIngredients")
                        .HasForeignKey("Ingredient")
                        .IsRequired()
                        .HasConstraintName("FK_MedicienIngredient_Ingredient");

                    b.HasOne("Pharmacy.Infrastracture.Models.MedicineDAO", "MedicineNavigation")
                        .WithMany("MedicienIngredients")
                        .HasForeignKey("Medicine")
                        .IsRequired()
                        .HasConstraintName("FK_MedicienIngredient_Medicine");

                    b.Navigation("IngredientNavigation");

                    b.Navigation("MedicineNavigation");
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.MedicineDAO", b =>
                {
                    b.HasOne("Pharmacy.Infrastracture.Models.CategoryDAO", "CategoryNavigation")
                        .WithMany("Medicines")
                        .HasForeignKey("Category")
                        .IsRequired()
                        .HasConstraintName("FK_Medicine_Category");

                    b.HasOne("Pharmacy.Infrastracture.Models.CompanyDAO", "CompanyNavigation")
                        .WithMany("Medicines")
                        .HasForeignKey("Company")
                        .IsRequired()
                        .HasConstraintName("FK_Medicine_Company");

                    b.Navigation("CategoryNavigation");

                    b.Navigation("CompanyNavigation");
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.PatientDiseaseDAO", b =>
                {
                    b.HasOne("Pharmacy.Infrastracture.Models.DiseaseDAO", "DiseaseNavigation")
                        .WithMany("PatientDiseases")
                        .HasForeignKey("Disease")
                        .IsRequired()
                        .HasConstraintName("FK_PatientDisease_Disease");

                    b.HasOne("Pharmacy.Infrastracture.Models.PatientDAO", "PatientNavigation")
                        .WithMany("PatientDiseases")
                        .HasForeignKey("Patient")
                        .IsRequired()
                        .HasConstraintName("FK_PatientDisease_Patient");

                    b.Navigation("DiseaseNavigation");

                    b.Navigation("PatientNavigation");
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.CategoryDAO", b =>
                {
                    b.Navigation("Medicines");
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.CompanyDAO", b =>
                {
                    b.Navigation("Medicines");
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.DiseaseDAO", b =>
                {
                    b.Navigation("DiseaseMedicines");

                    b.Navigation("PatientDiseases");
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.IngredientDAO", b =>
                {
                    b.Navigation("MedicienIngredients");
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.MedicineDAO", b =>
                {
                    b.Navigation("DiseaseMedicines");

                    b.Navigation("MedicienIngredients");
                });

            modelBuilder.Entity("Pharmacy.Infrastracture.Models.PatientDAO", b =>
                {
                    b.Navigation("PatientDiseases");
                });
#pragma warning restore 612, 618
        }
    }
}
