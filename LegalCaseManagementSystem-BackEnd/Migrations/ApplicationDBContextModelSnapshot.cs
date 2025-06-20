﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace LegalCaseManagementSystem_BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Case", b =>
                {
                    b.Property<int>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaseId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LawyerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CaseId");

                    b.HasIndex("ClientId");

                    b.HasIndex("LawyerId");

                    b.HasIndex("Status");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.CaseTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<int?>("AssignedToLawyerId")
                        .HasColumnType("int");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("AssignedToLawyerId");

                    b.HasIndex("CaseId");

                    b.HasIndex("Status");

                    b.ToTable("CaseTasks");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.HasIndex("UserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("DocumentId");

                    b.HasIndex("CaseId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Hearing", b =>
                {
                    b.Property<int>("HearingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HearingId"));

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HearingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Outcome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HearingId");

                    b.HasIndex("CaseId");

                    b.ToTable("Hearings");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CaseId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Lawyer", b =>
                {
                    b.Property<int>("LawyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LawyerId"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LawyerId");

                    b.HasIndex("UserId");

                    b.ToTable("Lawyers");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Case", b =>
                {
                    b.HasOne("LegalCaseManagementSystem_BackEnd.Models.Client", "Client")
                        .WithMany("Cases")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LegalCaseManagementSystem_BackEnd.Models.Lawyer", "Lawyer")
                        .WithMany("AssignedCases")
                        .HasForeignKey("LawyerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Lawyer");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.CaseTask", b =>
                {
                    b.HasOne("LegalCaseManagementSystem_BackEnd.Models.Lawyer", "AssignedToLawyer")
                        .WithMany()
                        .HasForeignKey("AssignedToLawyerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LegalCaseManagementSystem_BackEnd.Models.Case", "Case")
                        .WithMany("CaseTasks")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedToLawyer");

                    b.Navigation("Case");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Client", b =>
                {
                    b.HasOne("LegalCaseManagementSystem_BackEnd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Document", b =>
                {
                    b.HasOne("LegalCaseManagementSystem_BackEnd.Models.Case", "Case")
                        .WithMany("Documents")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Hearing", b =>
                {
                    b.HasOne("LegalCaseManagementSystem_BackEnd.Models.Case", "Case")
                        .WithMany("Hearings")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Invoice", b =>
                {
                    b.HasOne("LegalCaseManagementSystem_BackEnd.Models.Case", "Case")
                        .WithMany("Invoices")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Lawyer", b =>
                {
                    b.HasOne("LegalCaseManagementSystem_BackEnd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Case", b =>
                {
                    b.Navigation("CaseTasks");

                    b.Navigation("Documents");

                    b.Navigation("Hearings");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Client", b =>
                {
                    b.Navigation("Cases");
                });

            modelBuilder.Entity("LegalCaseManagementSystem_BackEnd.Models.Lawyer", b =>
                {
                    b.Navigation("AssignedCases");
                });
#pragma warning restore 612, 618
        }
    }
}
