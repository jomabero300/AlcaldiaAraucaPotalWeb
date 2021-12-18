using Microsoft.EntityFrameworkCore.Migrations;

namespace AlcaldiaAraucaPortalWeb.Data.Migrations
{
    public partial class SocialNetworkUrl : Migration
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
                name: "AffiliateSocialNetworURL",
                schema: "Proc",
                table: "AffiliateSocialNetworks",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserTokens");

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

            migrationBuilder.DropColumn(
                name: "AffiliateSocialNetworURL",
                schema: "Proc",
                table: "AffiliateSocialNetworks");

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
