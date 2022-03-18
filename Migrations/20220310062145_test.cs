using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace getstertech_user_apps_common_data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "audit_trail_for_business_specific_launch_screen_images",
                columns: table => new
                {
                    business_category_image_id = table.Column<int>(type: "int", nullable: false),
                    user_activity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activity_by_user_id = table.Column<int>(type: "int", nullable: false),
                    activity_local_timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "audit_trail_for_generic_launch_screen_images",
                columns: table => new
                {
                    generic_image_id = table.Column<int>(type: "int", nullable: false),
                    user_activity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    activity_by_user_id = table.Column<int>(type: "int", nullable: false),
                    activity_timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "business_specific_launch_screen_images",
                columns: table => new
                {
                    business_category_image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_app_business_category_id = table.Column<int>(type: "int", nullable: false),
                    business_category_image_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    business_category_image_storage_path = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uploaded_by_user_id = table.Column<int>(type: "int", nullable: false),
                    upload_timestamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deleted_status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    default_text_colour = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_business_specific_launch_screen_images", x => x.business_category_image_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "generic_launch_screen_images",
                columns: table => new
                {
                    generic_image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    generic_image_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    generic_image_storage_path = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deleted_status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    default_text_colour = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_launch_screen_images", x => x.generic_image_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit_trail_for_business_specific_launch_screen_images");

            migrationBuilder.DropTable(
                name: "audit_trail_for_generic_launch_screen_images");

            migrationBuilder.DropTable(
                name: "business_specific_launch_screen_images");

            migrationBuilder.DropTable(
                name: "generic_launch_screen_images");
        }
    }
}
