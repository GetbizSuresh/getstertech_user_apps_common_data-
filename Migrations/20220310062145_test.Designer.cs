// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using getstertech_user_apps_common_data.GetsterTech_DbContext;

namespace getstertech_user_apps_common_data.Migrations
{
    [DbContext(typeof(UserAppsCommonDataDb_DbContext))]
    [Migration("20220310062145_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("getstertech_user_apps_common_data.Models.audit_trail_for_business_specific_launch_screen_images", b =>
                {
                    b.Property<int>("activity_by_user_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("activity_local_timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("business_category_image_id")
                        .HasColumnType("int");

                    b.Property<string>("user_activity")
                        .HasColumnType("longtext");

                    b.ToTable("audit_trail_for_business_specific_launch_screen_images");
                });

            modelBuilder.Entity("getstertech_user_apps_common_data.Models.audit_trail_for_generic_launch_screen_images", b =>
                {
                    b.Property<int>("activity_by_user_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("activity_timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("generic_image_id")
                        .HasColumnType("int");

                    b.Property<string>("user_activity")
                        .HasColumnType("longtext");

                    b.ToTable("audit_trail_for_generic_launch_screen_images");
                });

            modelBuilder.Entity("getstertech_user_apps_common_data.Models.business_specific_launch_screen_images", b =>
                {
                    b.Property<int>("business_category_image_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("business_category_image_name")
                        .HasColumnType("longtext");

                    b.Property<string>("business_category_image_storage_path")
                        .HasColumnType("longtext");

                    b.Property<string>("default_text_colour")
                        .HasColumnType("longtext");

                    b.Property<bool>("deleted_status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("upload_timestamp")
                        .HasColumnType("longtext");

                    b.Property<int>("uploaded_by_user_id")
                        .HasColumnType("int");

                    b.Property<int>("user_app_business_category_id")
                        .HasColumnType("int");

                    b.HasKey("business_category_image_id");

                    b.ToTable("business_specific_launch_screen_images");
                });

            modelBuilder.Entity("getstertech_user_apps_common_data.Models.generic_launch_screen_images", b =>
                {
                    b.Property<int>("generic_image_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("default_text_colour")
                        .HasColumnType("longtext");

                    b.Property<bool>("deleted_status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("generic_image_name")
                        .HasColumnType("longtext");

                    b.Property<string>("generic_image_storage_path")
                        .HasColumnType("longtext");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("generic_image_id");

                    b.ToTable("generic_launch_screen_images");
                });
#pragma warning restore 612, 618
        }
    }
}
