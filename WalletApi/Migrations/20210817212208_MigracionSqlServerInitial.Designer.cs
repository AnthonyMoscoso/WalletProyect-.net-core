// <auto-generated />
using System;
using Infra.DataAccess.Specifics.DBs.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WalletApi.Migrations
{
    [DbContext(typeof(WalletContext))]
    [Migration("20210817212208_MigracionSqlServerInitial")]
    partial class MigracionSqlServerInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.DbModels.EF.Expense", b =>
                {
                    b.Property<int>("IdExpense")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdType")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<float>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("IdExpense");

                    b.HasIndex("IdType");

                    b.HasIndex("IdUser");

                    b.ToTable("Expense");

                    b.HasCheckConstraint("CK_Expense_Quantity", "Quantity>=0");
                });

            modelBuilder.Entity("Entities.DbModels.EF.ExpenseType", b =>
                {
                    b.Property<int>("IdType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("TypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("IdType");

                    b.HasIndex("IdUser");

                    b.ToTable("ExpenseType");
                });

            modelBuilder.Entity("Entities.DbModels.EF.Ingress", b =>
                {
                    b.Property<int>("IdIngress")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdType")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("IngressDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<float>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("IdIngress");

                    b.HasIndex("IdType");

                    b.HasIndex("IdUser");

                    b.ToTable("Ingress");

                    b.HasCheckConstraint("CK_Ingress_Quantity", "Quantity>=0");
                });

            modelBuilder.Entity("Entities.DbModels.EF.IngressType", b =>
                {
                    b.Property<int>("IdType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("TypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("IdType");

                    b.HasIndex("IdUser");

                    b.ToTable("IngressType");
                });

            modelBuilder.Entity("Entities.DbModels.EF.Users", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastUpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdUser");

                    b.HasAlternateKey("Email");

                    b.HasAlternateKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.DbModels.EF.Expense", b =>
                {
                    b.HasOne("Entities.DbModels.EF.ExpenseType", "ExpenseType")
                        .WithMany("Expense")
                        .HasForeignKey("IdType");

                    b.HasOne("Entities.DbModels.EF.Users", "User")
                        .WithMany("Expense")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("ExpenseType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.DbModels.EF.ExpenseType", b =>
                {
                    b.HasOne("Entities.DbModels.EF.Users", "User")
                        .WithMany("ExpenseType")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.DbModels.EF.Ingress", b =>
                {
                    b.HasOne("Entities.DbModels.EF.IngressType", "IngressType")
                        .WithMany("Ingress")
                        .HasForeignKey("IdType")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Entities.DbModels.EF.Users", "User")
                        .WithMany("Ingress")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("IngressType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.DbModels.EF.IngressType", b =>
                {
                    b.HasOne("Entities.DbModels.EF.Users", "User")
                        .WithMany("IngressType")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.DbModels.EF.ExpenseType", b =>
                {
                    b.Navigation("Expense");
                });

            modelBuilder.Entity("Entities.DbModels.EF.IngressType", b =>
                {
                    b.Navigation("Ingress");
                });

            modelBuilder.Entity("Entities.DbModels.EF.Users", b =>
                {
                    b.Navigation("Expense");

                    b.Navigation("ExpenseType");

                    b.Navigation("Ingress");

                    b.Navigation("IngressType");
                });
#pragma warning restore 612, 618
        }
    }
}
