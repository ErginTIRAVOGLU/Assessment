using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assessment.Kisiler.Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    Firma = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "IletisimBilgisi",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    BilgiTipi = table.Column<int>(type: "integer", nullable: false),
                    Icerik = table.Column<string>(type: "text", nullable: false),
                    KisiId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimBilgisi", x => x.UUID);
                    table.ForeignKey(
                        name: "FK_IletisimBilgisi_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisiler",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kisiler",
                columns: new[] { "UUID", "Ad", "Firma", "Soyad" },
                values: new object[,]
                {
                    { new Guid("136ce6bf-5eeb-468d-ba30-bb7ce1843cd0"), "Kenyon", "Twitterwire", "Waylen" },
                    { new Guid("1bd60b22-87bb-4163-b47c-07426928e89f"), "Rosalie", "Flashpoint", "O'Neill" },
                    { new Guid("36aec2e1-3aa7-4d9e-91f3-d0efbee71b87"), "Linea", "Fivechat", "Duigan" },
                    { new Guid("3f174232-8ecd-4908-a239-d080e6749e97"), "Therine", "Quire", "Bancroft" },
                    { new Guid("5e0adc61-cc87-4ad3-9462-5d1364dbe598"), "Reed", "Livetube", "Saynor" },
                    { new Guid("684fc466-b6de-4214-a4db-856c63703eb6"), "Rene", "Shufflebeat", "Faley" },
                    { new Guid("77c6a1e7-f295-497f-9d4b-31b18c8d73f6"), "Priscella", "Photobean", "Eul" },
                    { new Guid("8b746864-eff7-49f6-ac4e-79a48fbf7c39"), "Lock", "Feedfish", "Molyneaux" },
                    { new Guid("9a70a61b-d2db-4b1a-b3d3-1cb70eff0239"), "Kristofer", "Mycat", "Salzberg" },
                    { new Guid("a0bf6b9e-05d6-4675-8d25-0b72aa0a0735"), "Prescott", "Twitterwire", "Tinsey" },
                    { new Guid("adaedde8-a3ae-4b1f-8130-70dce3ab1b11"), "Dulcie", "Pixoboo", "Heintze" },
                    { new Guid("b7e13b1a-be3f-4d7b-b170-38d696e47d0b"), "Melva", "Thoughtbeat", "Simnor" },
                    { new Guid("b97cb918-e9c2-42d2-8934-5cd420a0d86c"), "Carlota", "Photobug", "Semble" },
                    { new Guid("c90207e1-352a-4dbd-96a4-1cb914a5b936"), "Kyrstin", "Rhyzio", "Yea" },
                    { new Guid("c9adfe33-ac0f-438e-b4bf-149a0b68e809"), "Romeo", "Quamba", "Paterno" },
                    { new Guid("cf9b359d-8097-48c2-8a74-85619aecc868"), "Kandy", "Rhyzio", "Hairs" },
                    { new Guid("da1319dd-4e81-4f50-9d4b-846b83abf0a3"), "Amanda", "Edgewire", "Youngs" },
                    { new Guid("e128ad20-dc81-4cd1-81de-e5e7d9dfe53f"), "Pincus", "Riffwire", "Portingale" },
                    { new Guid("ecadbd93-39f9-43a7-9c76-eea2be8686b0"), "Jarrad", "Devshare", "Agglione" },
                    { new Guid("ed7cf807-35d3-481b-8525-540a02b4f68d"), "Dario", "Camido", "Jobey" }
                });

            migrationBuilder.InsertData(
                table: "IletisimBilgisi",
                columns: new[] { "UUID", "BilgiTipi", "Icerik", "KisiId" },
                values: new object[,]
                {
                    { new Guid("05de750b-a805-499e-990d-b018e008001d"), 0, "410-174-8583", new Guid("136ce6bf-5eeb-468d-ba30-bb7ce1843cd0") },
                    { new Guid("3e3b853e-a4e9-4283-b272-505ef422920c"), 0, "584-128-3271", new Guid("da1319dd-4e81-4f50-9d4b-846b83abf0a3") },
                    { new Guid("4bf05cab-47ca-4857-bb44-9eff101eb420"), 2, "İzmir", new Guid("136ce6bf-5eeb-468d-ba30-bb7ce1843cd0") },
                    { new Guid("4e551c2c-c0ec-473f-89a7-ced43d2cdbfb"), 1, "Jarrad.Agglione@Devshare.com", new Guid("ecadbd93-39f9-43a7-9c76-eea2be8686b0") },
                    { new Guid("538bf86e-3f2e-4c1b-bed7-37834a0ab63f"), 0, "744-961-7350", new Guid("8b746864-eff7-49f6-ac4e-79a48fbf7c39") },
                    { new Guid("76c33942-34ef-4cdd-864b-9c6eb0295b91"), 2, "İstanbul", new Guid("da1319dd-4e81-4f50-9d4b-846b83abf0a3") },
                    { new Guid("8eb0abe2-27d8-4b6a-9a88-2338c918c037"), 2, "İstanbul", new Guid("8b746864-eff7-49f6-ac4e-79a48fbf7c39") },
                    { new Guid("b39be259-0623-4c6e-b6a5-b4e6f74d6457"), 1, "Amanda.Youngs@Edgewire.com", new Guid("da1319dd-4e81-4f50-9d4b-846b83abf0a3") },
                    { new Guid("c20b4040-ca01-4441-a983-8c49cfdc190e"), 2, "İstanbul", new Guid("ecadbd93-39f9-43a7-9c76-eea2be8686b0") },
                    { new Guid("ceea15f2-74e5-4c4e-bf41-8c12c776d9ea"), 2, "İstanbul", new Guid("36aec2e1-3aa7-4d9e-91f3-d0efbee71b87") },
                    { new Guid("dbb87f77-0f32-4872-a393-c7fef63a012c"), 1, "Kenyon.Waylen@Twitterwire.com", new Guid("136ce6bf-5eeb-468d-ba30-bb7ce1843cd0") },
                    { new Guid("e5762cb6-b204-4395-8de4-5e9362abb948"), 1, "Linea.Duigan@Fivechat.com", new Guid("36aec2e1-3aa7-4d9e-91f3-d0efbee71b87") },
                    { new Guid("f1bb3f17-940a-4c33-a391-bc01d16fe699"), 1, "Lock.Molyneaux@Feedfish.com", new Guid("8b746864-eff7-49f6-ac4e-79a48fbf7c39") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IletisimBilgisi_KisiId",
                table: "IletisimBilgisi",
                column: "KisiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IletisimBilgisi");

            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
