using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SerialNumbers.Migrations
{
    /// <summary>
    /// InitialCreate migration
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Migrations.Migration" />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sn");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "sn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "sn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schemas",
                schema: "sn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schemas_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "sn",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchemaDefinitions",
                schema: "sn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Increment = table.Column<int>(nullable: false),
                    Mask = table.Column<string>(maxLength: 255, nullable: false),
                    SchemaId = table.Column<int>(nullable: false),
                    Seed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemaDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchemaDefinitions_Schemas_SchemaId",
                        column: x => x.SchemaId,
                        principalSchema: "sn",
                        principalTable: "Schemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchemaValues",
                schema: "sn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchemaDefinitionId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemaValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchemaValues_SchemaDefinitions_SchemaDefinitionId",
                        column: x => x.SchemaDefinitionId,
                        principalSchema: "sn",
                        principalTable: "SchemaDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchemaValues_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "sn",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Name",
                schema: "sn",
                table: "Customers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchemaDefinitions_SchemaId",
                schema: "sn",
                table: "SchemaDefinitions",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Schemas_CustomerId",
                schema: "sn",
                table: "Schemas",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Schemas_Name_CustomerId",
                schema: "sn",
                table: "Schemas",
                columns: new[] { "Name", "CustomerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchemaValues_SubjectId",
                schema: "sn",
                table: "SchemaValues",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemaValues_SchemaDefinitionId_SubjectId_Value",
                schema: "sn",
                table: "SchemaValues",
                columns: new[] { "SchemaDefinitionId", "SubjectId", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Name",
                schema: "sn",
                table: "Subjects",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchemaValues",
                schema: "sn");

            migrationBuilder.DropTable(
                name: "SchemaDefinitions",
                schema: "sn");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "sn");

            migrationBuilder.DropTable(
                name: "Schemas",
                schema: "sn");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "sn");
        }
    }
}