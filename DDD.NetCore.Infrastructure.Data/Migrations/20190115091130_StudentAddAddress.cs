﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DDD.NetCore.Infrastructure.Data.Migrations
{
    public partial class StudentAddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_County",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Province",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address_County",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address_Province",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Students");
        }
    }
}
