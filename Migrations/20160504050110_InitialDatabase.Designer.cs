using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Covert_sation_Server.Models;

namespace CovertsationServer.Migrations
{
    [DbContext(typeof(CovertContext))]
    [Migration("20160504050110_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Covert_sation_Server.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdminId");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Covert_sation_Server.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int>("Timer");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Covert_sation_Server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<string>("Email");

                    b.Property<int?>("GroupId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Password");

                    b.Property<string>("PublicKey");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Covert_sation_Server.Models.UserMessage", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("MessageId");

                    b.HasKey("UserId", "MessageId");
                });

            modelBuilder.Entity("Covert_sation_Server.Models.Group", b =>
                {
                    b.HasOne("Covert_sation_Server.Models.User")
                        .WithMany()
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("Covert_sation_Server.Models.User", b =>
                {
                    b.HasOne("Covert_sation_Server.Models.Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Covert_sation_Server.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Covert_sation_Server.Models.UserMessage", b =>
                {
                    b.HasOne("Covert_sation_Server.Models.Message")
                        .WithMany()
                        .HasForeignKey("MessageId");

                    b.HasOne("Covert_sation_Server.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
