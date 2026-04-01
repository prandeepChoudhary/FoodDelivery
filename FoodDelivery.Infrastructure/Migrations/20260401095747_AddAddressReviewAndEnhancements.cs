using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressReviewAndEnhancements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsOpen",
                table: "restaurants",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "restaurants",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "restaurants",
                type: "numeric(3,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "restaurants",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "restaurants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Cuisine",
                table: "restaurants",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryFee",
                table: "restaurants",
                type: "numeric(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "restaurants",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedDeliveryTime",
                table: "restaurants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "restaurants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "restaurants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TotalReviews",
                table: "restaurants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "restaurants",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveredAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryAddressId",
                table: "orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialInstructions",
                table: "orders",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "menu_items",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "menu_items",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "menu_items",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "menu_items",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreparationTime",
                table: "menu_items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "menu_items",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "menu_categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Label = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(10,7)", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(10,7)", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviews_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviews_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_City",
                table: "restaurants",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_Cuisine",
                table: "restaurants",
                column: "Cuisine");

            migrationBuilder.CreateIndex(
                name: "IX_restaurants_OwnerId",
                table: "restaurants",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliveryAddressId",
                table: "orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_MenuItemId",
                table: "order_items",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_CategoryId",
                table: "menu_items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_items_RestaurantId",
                table: "menu_items",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_categories_RestaurantId",
                table: "menu_categories",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_UserId",
                table: "addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_OrderId",
                table: "reviews",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_RestaurantId",
                table: "reviews",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserId",
                table: "reviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_categories_restaurants_RestaurantId",
                table: "menu_categories",
                column: "RestaurantId",
                principalTable: "restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_menu_items_menu_categories_CategoryId",
                table: "menu_items",
                column: "CategoryId",
                principalTable: "menu_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_menu_items_restaurants_RestaurantId",
                table: "menu_items",
                column: "RestaurantId",
                principalTable: "restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_menu_items_MenuItemId",
                table: "order_items",
                column: "MenuItemId",
                principalTable: "menu_items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_orders_OrderId",
                table: "order_items",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_addresses_DeliveryAddressId",
                table: "orders",
                column: "DeliveryAddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_restaurants_RestaurantId",
                table: "orders",
                column: "RestaurantId",
                principalTable: "restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_UserId",
                table: "orders",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_categories_restaurants_RestaurantId",
                table: "menu_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_items_menu_categories_CategoryId",
                table: "menu_items");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_items_restaurants_RestaurantId",
                table: "menu_items");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_menu_items_MenuItemId",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_order_items_orders_OrderId",
                table: "order_items");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_addresses_DeliveryAddressId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_restaurants_RestaurantId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_UserId",
                table: "orders");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_users_Email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_restaurants_City",
                table: "restaurants");

            migrationBuilder.DropIndex(
                name: "IX_restaurants_Cuisine",
                table: "restaurants");

            migrationBuilder.DropIndex(
                name: "IX_restaurants_OwnerId",
                table: "restaurants");

            migrationBuilder.DropIndex(
                name: "IX_orders_DeliveryAddressId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_order_items_MenuItemId",
                table: "order_items");

            migrationBuilder.DropIndex(
                name: "IX_menu_items_CategoryId",
                table: "menu_items");

            migrationBuilder.DropIndex(
                name: "IX_menu_items_RestaurantId",
                table: "menu_items");

            migrationBuilder.DropIndex(
                name: "IX_menu_categories_RestaurantId",
                table: "menu_categories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "City",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "Cuisine",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "DeliveryFee",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "EstimatedDeliveryTime",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "TotalReviews",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "restaurants");

            migrationBuilder.DropColumn(
                name: "DeliveredAt",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "SpecialInstructions",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "menu_items");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "menu_items");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "menu_items");

            migrationBuilder.DropColumn(
                name: "PreparationTime",
                table: "menu_items");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "menu_items");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "menu_categories");

            migrationBuilder.AlterColumn<bool>(
                name: "IsOpen",
                table: "restaurants",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "menu_items",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);
        }
    }
}
