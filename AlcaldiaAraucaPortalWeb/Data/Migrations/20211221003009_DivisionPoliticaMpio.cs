using Microsoft.EntityFrameworkCore.Migrations;

namespace AlcaldiaAraucaPortalWeb.Data.Migrations
{
    public partial class DivisionPoliticaMpio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateGroupCommunities_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateGroupCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateGroupCommunities_GroupCommunities_GroupCommunityId",
                schema: "Proc",
                table: "AffiliateGroupCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateGroupProductives_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateGroupProductives");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateGroupProductives_GroupProductives_GroupProductiveId",
                schema: "Proc",
                table: "AffiliateGroupProductives");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateProfessionGalleries_AffiliateProfessions_AffiliateProfessionId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateProfessionGalleries_States_StateId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateProfessions_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateProfessions");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateProfessions_Professions_ProfessionId",
                schema: "Proc",
                table: "AffiliateProfessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Affiliates_AspNetUsers_UserId",
                schema: "Proc",
                table: "Affiliates");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateSocialNetworks_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateSocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateSocialNetworks_SocialNetworks_SocialNetworkId",
                schema: "Proc",
                table: "AffiliateSocialNetworks");

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

            migrationBuilder.DropForeignKey(
                name: "FK_BriefcaseSocialNetworks_Briefcases_BriefcaseId",
                schema: "Acti",
                table: "BriefcaseSocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_BriefcaseSocialNetworks_SocialNetworks_SocialNetworkId",
                schema: "Acti",
                table: "BriefcaseSocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupCommunities_States_StateId",
                schema: "Proc",
                table: "GroupCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupProductives_States_StateId",
                schema: "Gene",
                table: "GroupProductives");

            migrationBuilder.DropForeignKey(
                name: "FK_Pqrs_AspNetUsers_UserId",
                schema: "Gene",
                table: "Pqrs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pqrs_PqrsCategories_PqrsCategoryId",
                schema: "Gene",
                table: "Pqrs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pqrs_States_StateId",
                schema: "Gene",
                table: "Pqrs");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsAttachments_Pqrs_PqrsId",
                schema: "Gene",
                table: "PqrsAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsCategories_States_StateId",
                schema: "Gene",
                table: "PqrsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsProjectActivities_PqrsProjects_PqrsProjectId",
                schema: "Gene",
                table: "PqrsProjectActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsProjects_AspNetUsers_UserId",
                schema: "Gene",
                table: "PqrsProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsProponents_PqrsProjects_PqrsProjectId",
                schema: "Gene",
                table: "PqrsProponents");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsTraceabilities_Pqrs_PqrsId",
                schema: "Gene",
                table: "PqrsTraceabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsTraceabilities_PqrsUserStrategicLines_PqrsUserStrategicLineId",
                schema: "Gene",
                table: "PqrsTraceabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsUserStrategicLines_AspNetUsers_UserId",
                schema: "Gene",
                table: "PqrsUserStrategicLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsUserStrategicLines_PqrsStrategicLines_PqrsStrategicLineId",
                schema: "Gene",
                table: "PqrsUserStrategicLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsUserStrategicLines_States_StateId",
                schema: "Gene",
                table: "PqrsUserStrategicLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Professions_States_StateId",
                schema: "Gene",
                table: "Professions");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetworks_States_StateId",
                schema: "Gene",
                table: "SocialNetworks");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Length",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodSidewalkiD",
                schema: "Admi",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Gene",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                schema: "Gene",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                schema: "Gene",
                columns: table => new
                {
                    MunicipalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    MunicipalityName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.MunicipalityId);
                    table.ForeignKey(
                        name: "FK_Municipalities_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Gene",
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommuneTownships",
                schema: "Gene",
                columns: table => new
                {
                    CommuneTownshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    CommuneTownshipName = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommuneTownships", x => x.CommuneTownshipId);
                    table.ForeignKey(
                        name: "FK_CommuneTownships_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalSchema: "Gene",
                        principalTable: "Municipalities",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommuneTownships_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Gene",
                        principalTable: "Zones",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NeighborhoodSidewalks",
                schema: "Gene",
                columns: table => new
                {
                    NeighborhoodSidewalkiD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommuneTownshipId = table.Column<int>(type: "int", nullable: false),
                    NeighborhoodSidewalkName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighborhoodSidewalks", x => x.NeighborhoodSidewalkiD);
                    table.ForeignKey(
                        name: "FK_NeighborhoodSidewalks_CommuneTownships_CommuneTownshipId",
                        column: x => x.CommuneTownshipId,
                        principalSchema: "Gene",
                        principalTable: "CommuneTownships",
                        principalColumn: "CommuneTownshipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NeighborhoodSidewalkiD",
                schema: "Admi",
                table: "AspNetUsers",
                column: "NeighborhoodSidewalkiD");

            migrationBuilder.CreateIndex(
                name: "IX_CommuneTownship_Name",
                schema: "Gene",
                table: "CommuneTownships",
                columns: new[] { "MunicipalityId", "ZoneId", "CommuneTownshipName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommuneTownships_ZoneId",
                schema: "Gene",
                table: "CommuneTownships",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Name",
                schema: "Gene",
                table: "Departments",
                column: "DepartmentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_Name",
                schema: "Gene",
                table: "Municipalities",
                columns: new[] { "DepartmentId", "MunicipalityName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NeighborhoodSidewalk_Name",
                schema: "Gene",
                table: "NeighborhoodSidewalks",
                columns: new[] { "CommuneTownshipId", "NeighborhoodSidewalkName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zone_Name",
                schema: "Gene",
                table: "Zones",
                column: "ZoneName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateGroupCommunities_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateGroupCommunities",
                column: "AffiliateId",
                principalSchema: "Proc",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateGroupCommunities_GroupCommunities_GroupCommunityId",
                schema: "Proc",
                table: "AffiliateGroupCommunities",
                column: "GroupCommunityId",
                principalSchema: "Proc",
                principalTable: "GroupCommunities",
                principalColumn: "GroupCommunityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateGroupProductives_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateGroupProductives",
                column: "AffiliateId",
                principalSchema: "Proc",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateGroupProductives_GroupProductives_GroupProductiveId",
                schema: "Proc",
                table: "AffiliateGroupProductives",
                column: "GroupProductiveId",
                principalSchema: "Gene",
                principalTable: "GroupProductives",
                principalColumn: "GroupProductiveId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateProfessionGalleries_AffiliateProfessions_AffiliateProfessionId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries",
                column: "AffiliateProfessionId",
                principalSchema: "Proc",
                principalTable: "AffiliateProfessions",
                principalColumn: "AffiliateProfessionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateProfessionGalleries_States_StateId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateProfessions_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateProfessions",
                column: "AffiliateId",
                principalSchema: "Proc",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateProfessions_Professions_ProfessionId",
                schema: "Proc",
                table: "AffiliateProfessions",
                column: "ProfessionId",
                principalSchema: "Gene",
                principalTable: "Professions",
                principalColumn: "ProfessionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Affiliates_AspNetUsers_UserId",
                schema: "Proc",
                table: "Affiliates",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateSocialNetworks_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateSocialNetworks",
                column: "AffiliateId",
                principalSchema: "Proc",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateSocialNetworks_SocialNetworks_SocialNetworkId",
                schema: "Proc",
                table: "AffiliateSocialNetworks",
                column: "SocialNetworkId",
                principalSchema: "Gene",
                principalTable: "SocialNetworks",
                principalColumn: "SocialNetworkId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_AspNetUsers_NeighborhoodSidewalks_NeighborhoodSidewalkiD",
                schema: "Admi",
                table: "AspNetUsers",
                column: "NeighborhoodSidewalkiD",
                principalSchema: "Gene",
                principalTable: "NeighborhoodSidewalks",
                principalColumn: "NeighborhoodSidewalkiD",
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

            migrationBuilder.AddForeignKey(
                name: "FK_BriefcaseSocialNetworks_Briefcases_BriefcaseId",
                schema: "Acti",
                table: "BriefcaseSocialNetworks",
                column: "BriefcaseId",
                principalSchema: "Acti",
                principalTable: "Briefcases",
                principalColumn: "BriefcaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BriefcaseSocialNetworks_SocialNetworks_SocialNetworkId",
                schema: "Acti",
                table: "BriefcaseSocialNetworks",
                column: "SocialNetworkId",
                principalSchema: "Gene",
                principalTable: "SocialNetworks",
                principalColumn: "SocialNetworkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupCommunities_States_StateId",
                schema: "Proc",
                table: "GroupCommunities",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProductives_States_StateId",
                schema: "Gene",
                table: "GroupProductives",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pqrs_AspNetUsers_UserId",
                schema: "Gene",
                table: "Pqrs",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pqrs_PqrsCategories_PqrsCategoryId",
                schema: "Gene",
                table: "Pqrs",
                column: "PqrsCategoryId",
                principalSchema: "Gene",
                principalTable: "PqrsCategories",
                principalColumn: "PqrsCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pqrs_States_StateId",
                schema: "Gene",
                table: "Pqrs",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsAttachments_Pqrs_PqrsId",
                schema: "Gene",
                table: "PqrsAttachments",
                column: "PqrsId",
                principalSchema: "Gene",
                principalTable: "Pqrs",
                principalColumn: "PqrsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsCategories_States_StateId",
                schema: "Gene",
                table: "PqrsCategories",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsProjectActivities_PqrsProjects_PqrsProjectId",
                schema: "Gene",
                table: "PqrsProjectActivities",
                column: "PqrsProjectId",
                principalSchema: "Gene",
                principalTable: "PqrsProjects",
                principalColumn: "PqrsProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsProjects_AspNetUsers_UserId",
                schema: "Gene",
                table: "PqrsProjects",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsProponents_PqrsProjects_PqrsProjectId",
                schema: "Gene",
                table: "PqrsProponents",
                column: "PqrsProjectId",
                principalSchema: "Gene",
                principalTable: "PqrsProjects",
                principalColumn: "PqrsProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsTraceabilities_Pqrs_PqrsId",
                schema: "Gene",
                table: "PqrsTraceabilities",
                column: "PqrsId",
                principalSchema: "Gene",
                principalTable: "Pqrs",
                principalColumn: "PqrsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsTraceabilities_PqrsUserStrategicLines_PqrsUserStrategicLineId",
                schema: "Gene",
                table: "PqrsTraceabilities",
                column: "PqrsUserStrategicLineId",
                principalSchema: "Gene",
                principalTable: "PqrsUserStrategicLines",
                principalColumn: "PqrsUserStrategicLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsUserStrategicLines_AspNetUsers_UserId",
                schema: "Gene",
                table: "PqrsUserStrategicLines",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsUserStrategicLines_PqrsStrategicLines_PqrsStrategicLineId",
                schema: "Gene",
                table: "PqrsUserStrategicLines",
                column: "PqrsStrategicLineId",
                principalSchema: "Gene",
                principalTable: "PqrsStrategicLines",
                principalColumn: "PqrsStrategicLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsUserStrategicLines_States_StateId",
                schema: "Gene",
                table: "PqrsUserStrategicLines",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_States_StateId",
                schema: "Gene",
                table: "Professions",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetworks_States_StateId",
                schema: "Gene",
                table: "SocialNetworks",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateGroupCommunities_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateGroupCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateGroupCommunities_GroupCommunities_GroupCommunityId",
                schema: "Proc",
                table: "AffiliateGroupCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateGroupProductives_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateGroupProductives");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateGroupProductives_GroupProductives_GroupProductiveId",
                schema: "Proc",
                table: "AffiliateGroupProductives");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateProfessionGalleries_AffiliateProfessions_AffiliateProfessionId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateProfessionGalleries_States_StateId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateProfessions_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateProfessions");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateProfessions_Professions_ProfessionId",
                schema: "Proc",
                table: "AffiliateProfessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Affiliates_AspNetUsers_UserId",
                schema: "Proc",
                table: "Affiliates");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateSocialNetworks_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateSocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_AffiliateSocialNetworks_SocialNetworks_SocialNetworkId",
                schema: "Proc",
                table: "AffiliateSocialNetworks");

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
                name: "FK_AspNetUsers_NeighborhoodSidewalks_NeighborhoodSidewalkiD",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_BriefcaseSocialNetworks_Briefcases_BriefcaseId",
                schema: "Acti",
                table: "BriefcaseSocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_BriefcaseSocialNetworks_SocialNetworks_SocialNetworkId",
                schema: "Acti",
                table: "BriefcaseSocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupCommunities_States_StateId",
                schema: "Proc",
                table: "GroupCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupProductives_States_StateId",
                schema: "Gene",
                table: "GroupProductives");

            migrationBuilder.DropForeignKey(
                name: "FK_Pqrs_AspNetUsers_UserId",
                schema: "Gene",
                table: "Pqrs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pqrs_PqrsCategories_PqrsCategoryId",
                schema: "Gene",
                table: "Pqrs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pqrs_States_StateId",
                schema: "Gene",
                table: "Pqrs");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsAttachments_Pqrs_PqrsId",
                schema: "Gene",
                table: "PqrsAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsCategories_States_StateId",
                schema: "Gene",
                table: "PqrsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsProjectActivities_PqrsProjects_PqrsProjectId",
                schema: "Gene",
                table: "PqrsProjectActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsProjects_AspNetUsers_UserId",
                schema: "Gene",
                table: "PqrsProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsProponents_PqrsProjects_PqrsProjectId",
                schema: "Gene",
                table: "PqrsProponents");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsTraceabilities_Pqrs_PqrsId",
                schema: "Gene",
                table: "PqrsTraceabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsTraceabilities_PqrsUserStrategicLines_PqrsUserStrategicLineId",
                schema: "Gene",
                table: "PqrsTraceabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsUserStrategicLines_AspNetUsers_UserId",
                schema: "Gene",
                table: "PqrsUserStrategicLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsUserStrategicLines_PqrsStrategicLines_PqrsStrategicLineId",
                schema: "Gene",
                table: "PqrsUserStrategicLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PqrsUserStrategicLines_States_StateId",
                schema: "Gene",
                table: "PqrsUserStrategicLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Professions_States_StateId",
                schema: "Gene",
                table: "Professions");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetworks_States_StateId",
                schema: "Gene",
                table: "SocialNetworks");

            migrationBuilder.DropTable(
                name: "NeighborhoodSidewalks",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "CommuneTownships",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Municipalities",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Zones",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Gene");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NeighborhoodSidewalkiD",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Length",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NeighborhoodSidewalkiD",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateGroupCommunities_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateGroupCommunities",
                column: "AffiliateId",
                principalSchema: "Proc",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateGroupCommunities_GroupCommunities_GroupCommunityId",
                schema: "Proc",
                table: "AffiliateGroupCommunities",
                column: "GroupCommunityId",
                principalSchema: "Proc",
                principalTable: "GroupCommunities",
                principalColumn: "GroupCommunityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateGroupProductives_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateGroupProductives",
                column: "AffiliateId",
                principalSchema: "Proc",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateGroupProductives_GroupProductives_GroupProductiveId",
                schema: "Proc",
                table: "AffiliateGroupProductives",
                column: "GroupProductiveId",
                principalSchema: "Gene",
                principalTable: "GroupProductives",
                principalColumn: "GroupProductiveId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateProfessionGalleries_AffiliateProfessions_AffiliateProfessionId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries",
                column: "AffiliateProfessionId",
                principalSchema: "Proc",
                principalTable: "AffiliateProfessions",
                principalColumn: "AffiliateProfessionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateProfessionGalleries_States_StateId",
                schema: "Proc",
                table: "AffiliateProfessionGalleries",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateProfessions_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateProfessions",
                column: "AffiliateId",
                principalSchema: "Proc",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateProfessions_Professions_ProfessionId",
                schema: "Proc",
                table: "AffiliateProfessions",
                column: "ProfessionId",
                principalSchema: "Gene",
                principalTable: "Professions",
                principalColumn: "ProfessionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Affiliates_AspNetUsers_UserId",
                schema: "Proc",
                table: "Affiliates",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateSocialNetworks_Affiliates_AffiliateId",
                schema: "Proc",
                table: "AffiliateSocialNetworks",
                column: "AffiliateId",
                principalSchema: "Proc",
                principalTable: "Affiliates",
                principalColumn: "AffiliateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AffiliateSocialNetworks_SocialNetworks_SocialNetworkId",
                schema: "Proc",
                table: "AffiliateSocialNetworks",
                column: "SocialNetworkId",
                principalSchema: "Gene",
                principalTable: "SocialNetworks",
                principalColumn: "SocialNetworkId",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BriefcaseSocialNetworks_Briefcases_BriefcaseId",
                schema: "Acti",
                table: "BriefcaseSocialNetworks",
                column: "BriefcaseId",
                principalSchema: "Acti",
                principalTable: "Briefcases",
                principalColumn: "BriefcaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BriefcaseSocialNetworks_SocialNetworks_SocialNetworkId",
                schema: "Acti",
                table: "BriefcaseSocialNetworks",
                column: "SocialNetworkId",
                principalSchema: "Gene",
                principalTable: "SocialNetworks",
                principalColumn: "SocialNetworkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupCommunities_States_StateId",
                schema: "Proc",
                table: "GroupCommunities",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupProductives_States_StateId",
                schema: "Gene",
                table: "GroupProductives",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pqrs_AspNetUsers_UserId",
                schema: "Gene",
                table: "Pqrs",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pqrs_PqrsCategories_PqrsCategoryId",
                schema: "Gene",
                table: "Pqrs",
                column: "PqrsCategoryId",
                principalSchema: "Gene",
                principalTable: "PqrsCategories",
                principalColumn: "PqrsCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pqrs_States_StateId",
                schema: "Gene",
                table: "Pqrs",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsAttachments_Pqrs_PqrsId",
                schema: "Gene",
                table: "PqrsAttachments",
                column: "PqrsId",
                principalSchema: "Gene",
                principalTable: "Pqrs",
                principalColumn: "PqrsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsCategories_States_StateId",
                schema: "Gene",
                table: "PqrsCategories",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsProjectActivities_PqrsProjects_PqrsProjectId",
                schema: "Gene",
                table: "PqrsProjectActivities",
                column: "PqrsProjectId",
                principalSchema: "Gene",
                principalTable: "PqrsProjects",
                principalColumn: "PqrsProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsProjects_AspNetUsers_UserId",
                schema: "Gene",
                table: "PqrsProjects",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsProponents_PqrsProjects_PqrsProjectId",
                schema: "Gene",
                table: "PqrsProponents",
                column: "PqrsProjectId",
                principalSchema: "Gene",
                principalTable: "PqrsProjects",
                principalColumn: "PqrsProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsTraceabilities_Pqrs_PqrsId",
                schema: "Gene",
                table: "PqrsTraceabilities",
                column: "PqrsId",
                principalSchema: "Gene",
                principalTable: "Pqrs",
                principalColumn: "PqrsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsTraceabilities_PqrsUserStrategicLines_PqrsUserStrategicLineId",
                schema: "Gene",
                table: "PqrsTraceabilities",
                column: "PqrsUserStrategicLineId",
                principalSchema: "Gene",
                principalTable: "PqrsUserStrategicLines",
                principalColumn: "PqrsUserStrategicLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsUserStrategicLines_AspNetUsers_UserId",
                schema: "Gene",
                table: "PqrsUserStrategicLines",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsUserStrategicLines_PqrsStrategicLines_PqrsStrategicLineId",
                schema: "Gene",
                table: "PqrsUserStrategicLines",
                column: "PqrsStrategicLineId",
                principalSchema: "Gene",
                principalTable: "PqrsStrategicLines",
                principalColumn: "PqrsStrategicLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PqrsUserStrategicLines_States_StateId",
                schema: "Gene",
                table: "PqrsUserStrategicLines",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_States_StateId",
                schema: "Gene",
                table: "Professions",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetworks_States_StateId",
                schema: "Gene",
                table: "SocialNetworks",
                column: "StateId",
                principalSchema: "Gene",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
