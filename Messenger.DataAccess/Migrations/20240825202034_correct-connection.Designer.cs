﻿// <auto-generated />
using System;
using Messenger.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Messenger.DataAccess.Migrations
{
    [DbContext(typeof(ProductStoreDBcontext))]
    [Migration("20240825202034_correct-connection")]
    partial class correctconnection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatEntityMessageEntity", b =>
                {
                    b.Property<Guid>("ChatsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessagesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatsId", "MessagesId");

                    b.HasIndex("MessagesId");

                    b.ToTable("ChatEntityMessageEntity");
                });

            modelBuilder.Entity("ChatEntityUserEntity", b =>
                {
                    b.Property<Guid>("ChatsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ChatEntityUserEntity");
                });

            modelBuilder.Entity("Messenger.DataAccess.Entities.ChatEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Messenger.DataAccess.Entities.ConnectionEntity", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("stingConnection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConnectionId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("Messenger.DataAccess.Entities.MessageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Messenger.DataAccess.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Seller"
                        });
                });

            modelBuilder.Entity("Messenger.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"),
                            PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
                            Phone = "+380964674274",
                            UserName = "Vlad Gromovij"
                        },
                        new
                        {
                            Id = new Guid("57322de4-860d-4c50-950a-0e88f87d096c"),
                            PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
                            Phone = "+380963554053",
                            UserName = "Saller"
                        },
                        new
                        {
                            Id = new Guid("a248c062-819b-4a1f-87d7-be0d354f6862"),
                            PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
                            Phone = "+380961111111",
                            UserName = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("9608fbda-4b7b-4610-871c-7b95f9a0ced9"),
                            PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
                            Phone = "+380962222222",
                            UserName = "Jane Smith"
                        },
                        new
                        {
                            Id = new Guid("0240bc5b-04f1-4fcd-8f07-9863110c3d84"),
                            PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
                            Phone = "+380963333333",
                            UserName = "Alice Johnson"
                        },
                        new
                        {
                            Id = new Guid("6900d124-517a-4b7f-98e9-9e32910bdee7"),
                            PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
                            Phone = "+380964444444",
                            UserName = "Bob Brown"
                        },
                        new
                        {
                            Id = new Guid("92e8b77d-dc4c-43ce-9c22-4a89f5458db2"),
                            PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
                            Phone = "+380965555555",
                            UserName = "Charlie Davis"
                        },
                        new
                        {
                            Id = new Guid("f251a53c-5a87-4e39-8d0b-577d4e0d9eb0"),
                            PasswordHash = "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a",
                            Phone = "+380966666666",
                            UserName = "David Evans"
                        });
                });

            modelBuilder.Entity("Messenger.DataAccess.Entities.UserRoleEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"),
                            RoleId = 1
                        },
                        new
                        {
                            UserId = new Guid("57322de4-860d-4c50-950a-0e88f87d096c"),
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleEntityUserEntity");
                });

            modelBuilder.Entity("ChatEntityMessageEntity", b =>
                {
                    b.HasOne("Messenger.DataAccess.Entities.ChatEntity", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.DataAccess.Entities.MessageEntity", null)
                        .WithMany()
                        .HasForeignKey("MessagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatEntityUserEntity", b =>
                {
                    b.HasOne("Messenger.DataAccess.Entities.ChatEntity", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.DataAccess.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Messenger.DataAccess.Entities.MessageEntity", b =>
                {
                    b.HasOne("Messenger.DataAccess.Entities.UserEntity", "Sender")
                        .WithMany("Messages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.HasOne("Messenger.DataAccess.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.DataAccess.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Messenger.DataAccess.Entities.UserEntity", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}