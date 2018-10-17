using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Open.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AddressLine = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ID = table.Column<string>(nullable: false),
                    Definition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RateType",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ID = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CityOrAreaCode = table.Column<string>(nullable: true),
                    RegionOrStateOrCountryCode = table.Column<string>(nullable: true),
                    ZipOrPostCodeOrExtension = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CountryID = table.Column<string>(nullable: true),
                    NationalDirectDialingPrefix = table.Column<string>(nullable: true),
                    Device = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NationalCurrency",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    CountryID = table.Column<string>(nullable: false),
                    CurrencyID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalCurrency", x => new { x.CountryID, x.CurrencyID });
                    table.ForeignKey(
                        name: "FK_NationalCurrency_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NationalCurrency_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    DailyLimit = table.Column<decimal>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Issue = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    CurrencyID = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Payee = table.Column<string>(nullable: true),
                    CreditLimit = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    CurrencyID = table.Column<string>(nullable: true),
                    RateTypeID = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rate_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rate_RateType_RateTypeID",
                        column: x => x.RateTypeID,
                        principalTable: "RateType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelecomDeviceRegistration",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    AddressID = table.Column<string>(nullable: false),
                    DeviceID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelecomDeviceRegistration", x => new { x.AddressID, x.DeviceID });
                    table.ForeignKey(
                        name: "FK_TelecomDeviceRegistration_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TelecomDeviceRegistration_Address_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    DateDue = table.Column<DateTime>(nullable: false),
                    DateMade = table.Column<DateTime>(nullable: false),
                    CurrencyID = table.Column<string>(nullable: true),
                    PaymentMethodID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payment_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentMethod_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    DateMade = table.Column<DateTime>(nullable: false),
                    Explanation = table.Column<string>(nullable: true),
                    TransactionAccountNr = table.Column<string>(nullable: true),
                    PaymentMethodID = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CurrencyID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_PaymentMethod_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethod",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryID",
                table: "Address",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_NationalCurrency_CurrencyID",
                table: "NationalCurrency",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CurrencyID",
                table: "Payment",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentMethodID",
                table: "Payment",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_CurrencyID",
                table: "PaymentMethod",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_CurrencyID",
                table: "Rate",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_RateTypeID",
                table: "Rate",
                column: "RateTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TelecomDeviceRegistration_DeviceID",
                table: "TelecomDeviceRegistration",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ApplicationUserId",
                table: "Transactions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrencyID",
                table: "Transactions",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PaymentMethodID",
                table: "Transactions",
                column: "PaymentMethodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NationalCurrency");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "TelecomDeviceRegistration");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "RateType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
