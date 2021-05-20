using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyFashion.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    SocialSecurityNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArticleNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    UrlSlug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Postcode = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ImgUrl", "Name" },
                values: new object[,]
                {
                    { 1, "/img/bag.jpg", "Rea" },
                    { 2, "/img/sweater.jpg", "Tröjor" },
                    { 3, "/img/shoe.jpg", "Skor" },
                    { 4, "/img/jeans.jpg", "Jeans" },
                    { 5, "/img/jacket.jpg", "Jackor" },
                    { 6, "/img/bag.jpg", "Väskor" },
                    { 7, "/img/dress.jpg", "Klänningar" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "ArticleNumber", "Description", "ImageUrl", "Name", "Price", "UrlSlug" },
                values: new object[,]
                {
                    { 33, "PA28S1", "Beige klackskor med rosett", "/img/shoe5.jpg", "Beige klackskor", 700L, "beige-klack-skor" },
                    { 32, "AH390D", "Röda jeans med slitningar pch hål", "/img/jeans1.jpg", "Röda jeans", 450L, "röda-jeans" },
                    { 31, "91S6D", "Brun jeansjacka", "/img/jacket6.jpg", "Brun jeansjacka", 900L, "brun-jeans-jacka" },
                    { 30, "O1AMCS", "Röd stickad tröja med V-hals", "/img/sweater.jpg", "Röd tröja", 800L, "röd-tröja" },
                    { 27, "OPS3ES", "Svart skinnjacka med silvriga detaljer", "/img/jacket.jpg", "Svart skinnjacka", 1500L, "svart-skinn-jacka" },
                    { 28, "HUS823", "Blå väska", "/img/bag5.jpg", "Blå väska", 400L, "blå-väska" },
                    { 34, "OSDG72", "Röd bomullströja med små detaljer ", "/img/sweater4.jpg", "Röd stickad tröja", 499L, "röd-stickad-tröja" },
                    { 26, "YHWE4W", "Blommig klänning", "/img/dress4.jpg", "Blommig klänning", 800L, "blommig-klänning" },
                    { 29, "IUS62H", "Vita sneaker från Nike", "/img/shoe3.jpg", "Nike sneakers", 1600L, "vita-nike-sneakers" },
                    { 35, "BNS534", "Brun hand väska", "/img/bag4.jpg", "Brun väska", 300L, "brun-hand-väska" },
                    { 39, "A83BDH", "Ljus-rosa stickad tröja", "/img/sweater6.jpg", "Ljus-rosa tröja", 399L, "ljus-rosa-tröja" },
                    { 37, "MD7392", "Ljus-blå jeans jacka", "/img/jacket1.jpg", "Ljus-blå jeansjacka", 700L, "ljus-blå-jeans-jacka" },
                    { 38, "AO02D4", "Svarta jeans med hål och fiskenät", "/img/jeans5.jpg", "Svarta jeans", 500L, "svarta-jeans" },
                    { 25, "H829KL", "Brun väska", "/img/bag3.jpg", "Brun väska", 250L, "brun-väska" },
                    { 40, "O1AN5T", "Vit klänning med genomskinliga armar", "/img/dress6.jpg", "Vit klänning", 899L, "vit-klänning" },
                    { 41, "R5T2C3", "Beige kappa med svarta knappar", "/img/jacket5.jpg", "Beige kappa", 1500L, "beige-kappa" },
                    { 42, "O27DBF", "Ljus-blå jeans med hål", "/img/jeans7.jpg", "Ljus-blå jeans", 599L, "ljus-blå-jeans" },
                    { 43, "FR1NC6", "Vita sneakers med svarta detaljer", "/img/shoe1.jpg", "Vita sneakers", 399L, "vita-sneakers" },
                    { 44, "OADB73", "Röd polotröja med små detaljer ", "/img/sweater7.jpg", "Röd polotröja", 550L, "röd-polo-tröja" },
                    { 45, "CG6234", "Ljus-blå jeans med hål", "/img/jeans.jpg", "Ljus-blå jeans", 499L, "ljus-blå-jeans-med-hål" },
                    { 46, "QAMO93", "Olive packpack med små detaljer", "/img/bag7.jpg", "Olive väska", 599L, "olive-väska" },
                    { 36, "1A9SDE", "Blå klänning", "/img/dress5.jpg", "Blå klänning", 1200L, "blå-klänning" },
                    { 24, "HB7382", "Rosa stickad polotröja", "/img/sweater3.jpg", "Rosa polotröja", 799L, "rosa-polo-tröja" },
                    { 21, "AW4X50", "Grå tyg väska med varg motiv", "/img/bag6.jpg", "Grå väska", 1100L, "grå-väska" },
                    { 22, "TYC543", "Cool Vit klänning", "/img/dress1.jpg", "Vit klänning", 999L, "vit-klänning" },
                    { 1, "AWE321", "Brun läder väska med rem", "/img/bag.jpg", "Brun väska", 899L, "brun-läder-väska" },
                    { 2, "13K34S", "Svart klänning med vita prickar", "/img/dress.jpg", "Svart klänning", 649L, "svart-klänning" },
                    { 3, "7UR432", "Gul vindjacka med gore-tex material", "/img/jacket2.jpg", "Gul vindjacka", 1100L, "gul-vind-jacka" },
                    { 4, "UI8923", "Ljus-blå jeans med hål", "/img/jeans4.jpg", "Ljus-blå jeans", 799L, "ljus-blå-jeans" },
                    { 5, "Q32SDR", "Multi färgad sneaker från Nike", "/img/shoe4.jpg", "Nike sneakers", 1800L, "multifärgad-nike-sneakers" },
                    { 6, "Q8H53D", "Gul limiterad väska med svarta bin och bruna detaljer", "/img/bag1.jpg", "Gul väska", 2499L, "gul-väska" },
                    { 7, "GD02DB", "Svart klänning med vita prickar", "/img/dress7.jpg", "Svart klänning", 1499L, "svart-klänning-med-prickar" },
                    { 8, "TG023A", "Grå jeans med slitningar", "/img/jeans3.jpg", "Gråa jeans", 699L, "gråa-jeans" },
                    { 9, "1EF56G", "Svarta militär stövlar", "/img/shoe.jpg", "Svarta stövlar", 999L, "svarta-stövlar" },
                    { 10, "WE58XC", "Vit bomullströja med små detaljer ", "/img/sweater1.jpg", "Vit tröja", 789L, "vit-tröja" },
                    { 11, "TYG4D5", "Ljus-rosa väska", "/img/bag2.jpg", "Ljus-rosa väska", 400L, "ljus-rosa-väska" },
                    { 12, "HU90D3", "Gul off-shoulder klänning", "/img/dress2.jpg", "Gul klänning", 499L, "gul-klänning" },
                    { 13, "3DR5GC", "Ljus-brun jacka med snöre", "/img/jacket3.jpg", "Ljus-brun jacka", 699L, "ljus-brun-jacka" },
                    { 14, "B76SXW", "Ljus-blå jeans med slitningar, band på sidorna", "/img/jeans6.jpg", "Ljus-blå jeans", 699L, "ljus-blåa-jeans-med-band" },
                    { 15, "E35FGB", "Blå stickad tröja", "/img/sweater2.jpg", "Blå tröja", 500L, "blå-tröja" },
                    { 16, "WD780C", "Ljus-rosa off-shoulder klänning", "/img/dress3.jpg", "Ljus-rosa klänning", 899L, "ljus-rosa-klänning" },
                    { 17, "T5DESW", "Grå träningsjacka från Adidias", "/img/jacket4.jpg", "Adidas träningsjacka", 1499L, "adidas-tränings-jacka" },
                    { 18, "7UGSRA", "Vita straight jeans", "/img/jeans2.jpg", "Vita jeans", 399L, "vita-jeans" },
                    { 19, "EQ98SX", "Ljus-rosa sneakers med fake diamanter", "/img/shoe7.jpg", "Ljus-rosa sneakers", 399L, "ljus-rosa-sneakers" },
                    { 20, "WH68CS", "Grå polotröja med små detaljer ", "/img/sweater5.jpg", "Grå polotröja", 550L, "grå-polo-tröja" },
                    { 47, "GANCG4", "Gula converse", "/img/shoe6.jpg", "Gula converse", 850L, "gula-converse" },
                    { 23, "7UR432", "Röda klackskor med 20 cm klack", "/img/shoe2.jpg", "Röda klack skor", 800L, "röda-klack-skor" },
                    { 48, "AB634D", "Rutig mångfärgad jacka", "/img/jacket7.jpg", "Rutig jacka", 1100L, "rutig-jacka" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "ProductId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 27, 5 },
                    { 28, 6 },
                    { 29, 3 },
                    { 30, 2 },
                    { 31, 5 },
                    { 32, 4 },
                    { 33, 3 },
                    { 34, 2 },
                    { 35, 6 },
                    { 26, 7 },
                    { 36, 7 },
                    { 38, 4 },
                    { 39, 2 },
                    { 40, 7 },
                    { 41, 5 },
                    { 42, 4 },
                    { 43, 3 },
                    { 44, 2 },
                    { 45, 4 },
                    { 46, 6 },
                    { 37, 5 },
                    { 25, 6 },
                    { 24, 2 },
                    { 23, 3 },
                    { 2, 7 },
                    { 3, 5 },
                    { 4, 4 },
                    { 5, 3 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 4 },
                    { 9, 3 },
                    { 10, 2 },
                    { 11, 6 },
                    { 12, 7 },
                    { 13, 5 },
                    { 14, 4 },
                    { 15, 2 },
                    { 16, 7 },
                    { 17, 5 },
                    { 18, 4 },
                    { 19, 3 },
                    { 20, 2 },
                    { 21, 6 },
                    { 22, 7 },
                    { 47, 3 },
                    { 48, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
