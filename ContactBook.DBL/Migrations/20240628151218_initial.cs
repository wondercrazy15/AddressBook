﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactBook.DBL.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FisrtName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "VARBINARY(max)", nullable: true),
                    Company = table.Column<string>(type: "varchar(200)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Address = table.Column<string>(type: "varchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    birthdate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Note = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblContacts",
                columns: new[] { "Id", "Address", "Company", "Email", "FisrtName", "LastName", "Latitude", "Longitude", "Note", "Phone", "ProfileImage", "birthdate" },
                values: new object[] { 1, null, "Test Company", "Jonathan@gmail.com", "Jonathan", "Corbett", null, null, null, "1234567891", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 100, 0, 0, 0, 100, 8, 6, 0, 0, 0, 112, 226, 149, 84, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 2, 98, 73, 68, 65, 84, 120, 94, 237, 217, 193, 145, 163, 48, 20, 0, 81, 242, 34, 25, 82, 33, 17, 242, 32, 14, 7, 196, 216, 179, 75, 173, 215, 214, 23, 96, 131, 212, 80, 125, 120, 55, 96, 106, 212, 66, 2, 220, 220, 110, 183, 73, 28, 6, 129, 49, 8, 140, 65, 96, 12, 2, 99, 16, 24, 131, 192, 24, 4, 198, 32, 48, 6, 129, 49, 8, 140, 65, 96, 12, 2, 99, 16, 24, 131, 192, 24, 4, 198, 32, 48, 6, 129, 49, 8, 140, 65, 96, 12, 2, 99, 16, 24, 131, 192, 24, 4, 198, 32, 48, 6, 129, 49, 8, 140, 65, 96, 12, 2, 99, 16, 24, 131, 192, 24, 4, 198, 32, 48, 200, 32, 99, 223, 78, 77, 211, 188, 232, 166, 33, 113, 236, 178, 113, 234, 219, 215, 107, 61, 105, 251, 105, 76, 158, 87, 199, 101, 131, 164, 175, 145, 215, 13, 233, 107, 149, 116, 193, 32, 195, 212, 189, 157, 187, 65, 229, 59, 230, 90, 65, 198, 126, 106, 223, 206, 251, 64, 197, 40, 215, 9, 178, 87, 140, 89, 55, 164, 255, 206, 193, 46, 18, 100, 97, 227, 110, 218, 169, 31, 223, 207, 91, 218, 103, 106, 236, 41, 151, 8, 146, 27, 216, 182, 31, 147, 231, 252, 147, 137, 89, 97, 233, 186, 64, 144, 120, 19, 95, 142, 49, 139, 174, 145, 190, 179, 142, 116, 254, 32, 67, 151, 56, 246, 110, 227, 236, 142, 238, 178, 245, 81, 247, 113, 250, 32, 67, 247, 122, 220, 31, 219, 7, 242, 233, 46, 241, 41, 235, 127, 235, 131, 68, 235, 127, 249, 165, 102, 47, 39, 15, 18, 173, 253, 209, 126, 195, 119, 238, 32, 209, 187, 71, 229, 183, 237, 111, 24, 4, 198, 32, 48, 6, 129, 49, 8, 204, 185, 131, 248, 148, 85, 198, 250, 32, 123, 190, 135, 252, 189, 86, 165, 175, 188, 179, 162, 65, 158, 7, 58, 247, 37, 53, 253, 246, 157, 158, 245, 187, 189, 169, 39, 150, 191, 210, 159, 77, 30, 142, 15, 18, 124, 107, 218, 28, 36, 218, 23, 14, 254, 150, 85, 250, 142, 57, 62, 72, 176, 241, 198, 179, 47, 88, 134, 194, 1, 222, 225, 107, 111, 244, 112, 112, 87, 250, 55, 145, 106, 65, 194, 141, 55, 58, 62, 51, 83, 195, 217, 125, 183, 28, 37, 14, 90, 227, 225, 160, 192, 30, 146, 249, 1, 232, 237, 31, 142, 7, 39, 63, 83, 115, 131, 250, 144, 222, 228, 163, 253, 103, 118, 205, 61, 228, 46, 55, 131, 215, 89, 49, 83, 51, 203, 206, 71, 42, 189, 203, 20, 9, 178, 60, 131, 243, 86, 175, 227, 187, 69, 41, 191, 84, 205, 10, 5, 185, 251, 112, 176, 182, 47, 27, 223, 197, 175, 25, 227, 161, 92, 144, 95, 219, 6, 235, 155, 39, 156, 79, 150, 201, 26, 123, 198, 171, 194, 65, 102, 185, 48, 123, 255, 218, 183, 52, 9, 234, 222, 17, 175, 42, 5, 81, 196, 32, 48, 6, 129, 49, 8, 140, 65, 96, 12, 2, 99, 16, 24, 131, 192, 24, 4, 198, 32, 48, 6, 129, 49, 8, 140, 65, 96, 12, 2, 99, 16, 24, 131, 192, 24, 4, 198, 32, 48, 6, 129, 49, 8, 140, 65, 96, 12, 2, 99, 16, 24, 131, 192, 24, 4, 198, 32, 48, 6, 129, 49, 8, 140, 65, 96, 12, 2, 99, 16, 24, 131, 192, 24, 4, 198, 32, 48, 6, 129, 49, 8, 140, 65, 96, 12, 130, 114, 155, 126, 0, 134, 183, 61, 95, 181, 3, 154, 148, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblContacts");
        }
    }
}