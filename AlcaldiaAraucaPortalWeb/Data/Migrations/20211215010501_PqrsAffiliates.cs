using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlcaldiaAraucaPortalWeb.Data.Migrations
{
    public partial class PqrsAffiliates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserTokens");

            migrationBuilder.DeleteData(
                schema: "Admi",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "442ee045-7a42-4153-908a-ab8cef89d98e");

            migrationBuilder.DeleteData(
                schema: "Admi",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3ce933c-183b-4262-9fee-13b8f60fbf68");

            migrationBuilder.DeleteData(
                schema: "Admi",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711");

            migrationBuilder.DeleteData(
                schema: "Gene",
                table: "DocumentTypes",
                keyColumn: "DocumentTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Gene",
                table: "DocumentTypes",
                keyColumn: "DocumentTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Gene",
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Gene",
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Gene",
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3);

            migrationBuilder.EnsureSchema(
                name: "Proc");

            migrationBuilder.EnsureSchema(
                name: "Acti");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirdDarte",
                schema: "Admi",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Affiliates",
                schema: "Proc",
                columns: table => new
                {
                    AffiliateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TypeUserId = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Nit = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Phone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliates", x => x.AffiliateId);
                    table.ForeignKey(
                        name: "FK_Affiliates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Admi",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Briefcases",
                schema: "Acti",
                columns: table => new
                {
                    BriefcaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BriefcaseTitel = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    BriefcaseImage = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    BriefcaseText = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BriefcaseUrl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BriefcaseDescrption = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    BriefcaseFacebook = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    BriefcaseTwitter = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    BriefcaseSkype = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    BriefcaseGoogle = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Briefcases", x => x.BriefcaseId);
                });

            migrationBuilder.CreateTable(
                name: "PqrsStrategicLines",
                schema: "Gene",
                columns: table => new
                {
                    PqrsStrategicLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsStrategicLineName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqrsStrategicLines", x => x.PqrsStrategicLineId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "Gene",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateType = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    StateName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    StateB = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "GroupCommunities",
                schema: "Proc",
                columns: table => new
                {
                    GroupCommunityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCommunityName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupCommunities", x => x.GroupCommunityId);
                    table.ForeignKey(
                        name: "FK_GroupCommunities_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupProductives",
                schema: "Gene",
                columns: table => new
                {
                    GroupProductiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupProductiveName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProductives", x => x.GroupProductiveId);
                    table.ForeignKey(
                        name: "FK_GroupProductives_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PqrsCategories",
                schema: "Gene",
                columns: table => new
                {
                    PqrsCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsCategoryName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqrsCategories", x => x.PqrsCategoryId);
                    table.ForeignKey(
                        name: "FK_PqrsCategories_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PqrsUserStrategicLines",
                schema: "Gene",
                columns: table => new
                {
                    PqrsUserStrategicLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PqrsStrategicLineId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqrsUserStrategicLines", x => x.PqrsUserStrategicLineId);
                    table.ForeignKey(
                        name: "FK_PqrsUserStrategicLines_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Admi",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PqrsUserStrategicLines_PqrsStrategicLines_PqrsStrategicLineId",
                        column: x => x.PqrsStrategicLineId,
                        principalSchema: "Gene",
                        principalTable: "PqrsStrategicLines",
                        principalColumn: "PqrsStrategicLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PqrsUserStrategicLines_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                schema: "Gene",
                columns: table => new
                {
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProfessionId);
                    table.ForeignKey(
                        name: "FK_Professions_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                schema: "Gene",
                columns: table => new
                {
                    SocialNetworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialNetworkName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.SocialNetworkId);
                    table.ForeignKey(
                        name: "FK_SocialNetworks_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateGroupCommunities",
                schema: "Proc",
                columns: table => new
                {
                    AffiliateGroupCommunityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateId = table.Column<int>(type: "int", nullable: false),
                    GroupCommunityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateGroupCommunities", x => x.AffiliateGroupCommunityId);
                    table.ForeignKey(
                        name: "FK_AffiliateGroupCommunities_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalSchema: "Proc",
                        principalTable: "Affiliates",
                        principalColumn: "AffiliateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AffiliateGroupCommunities_GroupCommunities_GroupCommunityId",
                        column: x => x.GroupCommunityId,
                        principalSchema: "Proc",
                        principalTable: "GroupCommunities",
                        principalColumn: "GroupCommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateGroupProductives",
                schema: "Proc",
                columns: table => new
                {
                    AffiliateGroupProductiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateId = table.Column<int>(type: "int", nullable: false),
                    GroupProductiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateGroupProductives", x => x.AffiliateGroupProductiveId);
                    table.ForeignKey(
                        name: "FK_AffiliateGroupProductives_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalSchema: "Proc",
                        principalTable: "Affiliates",
                        principalColumn: "AffiliateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AffiliateGroupProductives_GroupProductives_GroupProductiveId",
                        column: x => x.GroupProductiveId,
                        principalSchema: "Gene",
                        principalTable: "GroupProductives",
                        principalColumn: "GroupProductiveId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pqrs",
                schema: "Gene",
                columns: table => new
                {
                    PqrsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsCategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PqrsDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PqrsSubject = table.Column<string>(type: "varchar(150)", nullable: false),
                    PqrsMessage = table.Column<string>(type: "varchar(200)", nullable: false),
                    PqrsLocated = table.Column<string>(type: "varchar(20)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pqrs", x => x.PqrsId);
                    table.ForeignKey(
                        name: "FK_Pqrs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Admi",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pqrs_PqrsCategories_PqrsCategoryId",
                        column: x => x.PqrsCategoryId,
                        principalSchema: "Gene",
                        principalTable: "PqrsCategories",
                        principalColumn: "PqrsCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pqrs_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateProfessions",
                schema: "Proc",
                columns: table => new
                {
                    AffiliateProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateId = table.Column<int>(type: "int", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Concept = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DocumentoPath = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateProfessions", x => x.AffiliateProfessionId);
                    table.ForeignKey(
                        name: "FK_AffiliateProfessions_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalSchema: "Proc",
                        principalTable: "Affiliates",
                        principalColumn: "AffiliateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AffiliateProfessions_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalSchema: "Gene",
                        principalTable: "Professions",
                        principalColumn: "ProfessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateSocialNetworks",
                schema: "Proc",
                columns: table => new
                {
                    AffiliateSocialNetworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateId = table.Column<int>(type: "int", nullable: false),
                    SocialNetworkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateSocialNetworks", x => x.AffiliateSocialNetworkId);
                    table.ForeignKey(
                        name: "FK_AffiliateSocialNetworks_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalSchema: "Proc",
                        principalTable: "Affiliates",
                        principalColumn: "AffiliateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AffiliateSocialNetworks_SocialNetworks_SocialNetworkId",
                        column: x => x.SocialNetworkId,
                        principalSchema: "Gene",
                        principalTable: "SocialNetworks",
                        principalColumn: "SocialNetworkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PqrsAttachments",
                schema: "Gene",
                columns: table => new
                {
                    PqrsAttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsId = table.Column<int>(type: "int", nullable: false),
                    PqrsAttachmentsPath = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PqrSend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqrsAttachments", x => x.PqrsAttachmentId);
                    table.ForeignKey(
                        name: "FK_PqrsAttachments_Pqrs_PqrsId",
                        column: x => x.PqrsId,
                        principalSchema: "Gene",
                        principalTable: "Pqrs",
                        principalColumn: "PqrsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PqrsTraceabilities",
                schema: "Gene",
                columns: table => new
                {
                    PqrsTraceabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsId = table.Column<int>(type: "int", nullable: false),
                    PqrsUserStrategicLineId = table.Column<int>(type: "int", nullable: false),
                    PqrsTraceabilityDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Answer = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqrsTraceabilities", x => x.PqrsTraceabilityId);
                    table.ForeignKey(
                        name: "FK_PqrsTraceabilities_Pqrs_PqrsId",
                        column: x => x.PqrsId,
                        principalSchema: "Gene",
                        principalTable: "Pqrs",
                        principalColumn: "PqrsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PqrsTraceabilities_PqrsUserStrategicLines_PqrsUserStrategicLineId",
                        column: x => x.PqrsUserStrategicLineId,
                        principalSchema: "Gene",
                        principalTable: "PqrsUserStrategicLines",
                        principalColumn: "PqrsUserStrategicLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateProfessionGalleries",
                schema: "Proc",
                columns: table => new
                {
                    AffiliateEthnicGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateProfessionId = table.Column<int>(type: "int", nullable: false),
                    AffiliateProfessionGalleryPath = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateProfessionGalleries", x => x.AffiliateEthnicGroupId);
                    table.ForeignKey(
                        name: "FK_AffiliateProfessionGalleries_AffiliateProfessions_AffiliateProfessionId",
                        column: x => x.AffiliateProfessionId,
                        principalSchema: "Proc",
                        principalTable: "AffiliateProfessions",
                        principalColumn: "AffiliateProfessionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AffiliateProfessionGalleries_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateGroupCommunities_GroupCommunityId",
                schema: "Proc",
                table: "AffiliateGroupCommunities",
                column: "GroupCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateGroupCommunity_AffiliateGroupCommunity",
                schema: "Proc",
                table: "AffiliateGroupCommunities",
                columns: new[] { "AffiliateId", "GroupCommunityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateGroupProductive_AffiliateGroupProductive",
                schema: "Proc",
                table: "AffiliateGroupProductives",
                columns: new[] { "AffiliateId", "AffiliateGroupProductiveId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateGroupProductives_GroupProductiveId",
                schema: "Proc",
                table: "AffiliateGroupProductives",
                column: "GroupProductiveId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProfessionGalleries_AffiliateProfessionId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries",
                column: "AffiliateProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProfessionGalleries_StateId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProfession_AffiliateProfession",
                schema: "Proc",
                table: "AffiliateProfessions",
                columns: new[] { "AffiliateId", "AffiliateProfessionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProfessions_ProfessionId",
                schema: "Proc",
                table: "AffiliateProfessions",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Affiliates_UserId",
                schema: "Proc",
                table: "Affiliates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateSocialNetwork_AffiliateSocialNetwork",
                schema: "Proc",
                table: "AffiliateSocialNetworks",
                columns: new[] { "AffiliateId", "AffiliateSocialNetworkId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateSocialNetworks_SocialNetworkId",
                schema: "Proc",
                table: "AffiliateSocialNetworks",
                column: "SocialNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupCommunities_StateId",
                schema: "Proc",
                table: "GroupCommunities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupCommunity_Name",
                schema: "Proc",
                table: "GroupCommunities",
                column: "GroupCommunityName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupProductive_Name",
                schema: "Gene",
                table: "GroupProductives",
                column: "GroupProductiveName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupProductives_StateId",
                schema: "Gene",
                table: "GroupProductives",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Pqrs_PqrsCategoryId",
                schema: "Gene",
                table: "Pqrs",
                column: "PqrsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pqrs_StateId",
                schema: "Gene",
                table: "Pqrs",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Pqrs_UserId",
                schema: "Gene",
                table: "Pqrs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PqrsAttachments_PqrsId",
                schema: "Gene",
                table: "PqrsAttachments",
                column: "PqrsId");

            migrationBuilder.CreateIndex(
                name: "IX_PqrsCategories_StateId",
                schema: "Gene",
                table: "PqrsCategories",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_PqrsCategory_Name",
                schema: "Gene",
                table: "PqrsCategories",
                column: "PqrsCategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PqrsStrategicLine_Name",
                schema: "Gene",
                table: "PqrsStrategicLines",
                column: "PqrsStrategicLineName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PqrsTraceabilities_PqrsId",
                schema: "Gene",
                table: "PqrsTraceabilities",
                column: "PqrsId");

            migrationBuilder.CreateIndex(
                name: "IX_PqrsTraceabilities_PqrsUserStrategicLineId",
                schema: "Gene",
                table: "PqrsTraceabilities",
                column: "PqrsUserStrategicLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PqrsUserStrategicLines_PqrsStrategicLineId",
                schema: "Gene",
                table: "PqrsUserStrategicLines",
                column: "PqrsStrategicLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PqrsUserStrategicLines_StateId",
                schema: "Gene",
                table: "PqrsUserStrategicLines",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_PqrsUserStrategicLines_UserId",
                schema: "Gene",
                table: "PqrsUserStrategicLines",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profession_Name",
                schema: "Gene",
                table: "Professions",
                column: "ProfessionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professions_StateId",
                schema: "Gene",
                table: "Professions",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetwork_Name",
                schema: "Gene",
                table: "SocialNetworks",
                column: "SocialNetworkName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_StateId",
                schema: "Gene",
                table: "SocialNetworks",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_Name",
                schema: "Gene",
                table: "States",
                columns: new[] { "StateName", "StateType" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "Admi",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "Admi",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "DocumentTypeId",
                principalSchema: "Gene",
                principalTable: "DocumentTypes",
                principalColumn: "DocumentTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "GenderId",
                principalSchema: "Gene",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AffiliateGroupCommunities",
                schema: "Proc");

            migrationBuilder.DropTable(
                name: "AffiliateGroupProductives",
                schema: "Proc");

            migrationBuilder.DropTable(
                name: "AffiliateProfessionGalleries",
                schema: "Proc");

            migrationBuilder.DropTable(
                name: "AffiliateSocialNetworks",
                schema: "Proc");

            migrationBuilder.DropTable(
                name: "Briefcases",
                schema: "Acti");

            migrationBuilder.DropTable(
                name: "PqrsAttachments",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "PqrsTraceabilities",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "GroupCommunities",
                schema: "Proc");

            migrationBuilder.DropTable(
                name: "GroupProductives",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "AffiliateProfessions",
                schema: "Proc");

            migrationBuilder.DropTable(
                name: "SocialNetworks",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Pqrs",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "PqrsUserStrategicLines",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Affiliates",
                schema: "Proc");

            migrationBuilder.DropTable(
                name: "Professions",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "PqrsCategories",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "PqrsStrategicLines",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "States",
                schema: "Gene");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirdDarte",
                schema: "Admi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.InsertData(
                schema: "Admi",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Administrador", "Administrador" },
                    { "442ee045-7a42-4153-908a-ab8cef89d98e", "2", "Publicador", "Publidaro" },
                    { "d3ce933c-183b-4262-9fee-13b8f60fbf68", "3", "Usuario", "Usuario" }
                });

            migrationBuilder.InsertData(
                schema: "Gene",
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeId", "DocumentTypeName" },
                values: new object[,]
                {
                    { 1, "Cédula de ciudadanía" },
                    { 2, "Cédula de extranjería" }
                });

            migrationBuilder.InsertData(
                schema: "Gene",
                table: "Genders",
                columns: new[] { "GenderId", "GenderName" },
                values: new object[,]
                {
                    { 1, "Hombre" },
                    { 2, "Mujer" },
                    { 3, "Otro" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "Admi",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "Admi",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "DocumentTypeId",
                principalSchema: "Gene",
                principalTable: "DocumentTypes",
                principalColumn: "DocumentTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "GenderId",
                principalSchema: "Gene",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
