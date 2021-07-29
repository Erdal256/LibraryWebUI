using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Cities_CityId",
                table: "UserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Countries_CountryId",
                table: "UserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDetails_UserDetailId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "LibraryUsers");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "LibraryUserDetails");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "LibraryRoles");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "LibraryCountries");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "LibraryCities");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "LibraryCategories");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "LibraryBooks");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserDetailId",
                table: "LibraryUsers",
                newName: "IX_LibraryUsers_UserDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "LibraryUsers",
                newName: "IX_LibraryUsers_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_EMail",
                table: "LibraryUserDetails",
                newName: "IX_LibraryUserDetails_EMail");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_CountryId",
                table: "LibraryUserDetails",
                newName: "IX_LibraryUserDetails_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_CityId",
                table: "LibraryUserDetails",
                newName: "IX_LibraryUserDetails_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "LibraryCities",
                newName: "IX_LibraryCities_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Name",
                table: "LibraryBooks",
                newName: "IX_LibraryBooks_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "LibraryBooks",
                newName: "IX_LibraryBooks_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryUsers",
                table: "LibraryUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryUserDetails",
                table: "LibraryUserDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryRoles",
                table: "LibraryRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryCountries",
                table: "LibraryCountries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryCities",
                table: "LibraryCities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryCategories",
                table: "LibraryCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBooks_LibraryCategories_CategoryId",
                table: "LibraryBooks",
                column: "CategoryId",
                principalTable: "LibraryCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryCities_LibraryCountries_CountryId",
                table: "LibraryCities",
                column: "CountryId",
                principalTable: "LibraryCountries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryUserDetails_LibraryCities_CityId",
                table: "LibraryUserDetails",
                column: "CityId",
                principalTable: "LibraryCities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryUserDetails_LibraryCountries_CountryId",
                table: "LibraryUserDetails",
                column: "CountryId",
                principalTable: "LibraryCountries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryUsers_LibraryRoles_RoleId",
                table: "LibraryUsers",
                column: "RoleId",
                principalTable: "LibraryRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryUsers_LibraryUserDetails_UserDetailId",
                table: "LibraryUsers",
                column: "UserDetailId",
                principalTable: "LibraryUserDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBooks_LibraryCategories_CategoryId",
                table: "LibraryBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryCities_LibraryCountries_CountryId",
                table: "LibraryCities");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryUserDetails_LibraryCities_CityId",
                table: "LibraryUserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryUserDetails_LibraryCountries_CountryId",
                table: "LibraryUserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryUsers_LibraryRoles_RoleId",
                table: "LibraryUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryUsers_LibraryUserDetails_UserDetailId",
                table: "LibraryUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryUsers",
                table: "LibraryUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryUserDetails",
                table: "LibraryUserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryRoles",
                table: "LibraryRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryCountries",
                table: "LibraryCountries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryCities",
                table: "LibraryCities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryCategories",
                table: "LibraryCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks");

            migrationBuilder.RenameTable(
                name: "LibraryUsers",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "LibraryUserDetails",
                newName: "UserDetails");

            migrationBuilder.RenameTable(
                name: "LibraryRoles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "LibraryCountries",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "LibraryCities",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "LibraryCategories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "LibraryBooks",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryUsers_UserDetailId",
                table: "Users",
                newName: "IX_Users_UserDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryUsers_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryUserDetails_EMail",
                table: "UserDetails",
                newName: "IX_UserDetails_EMail");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryUserDetails_CountryId",
                table: "UserDetails",
                newName: "IX_UserDetails_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryUserDetails_CityId",
                table: "UserDetails",
                newName: "IX_UserDetails_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryCities_CountryId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryBooks_Name",
                table: "Books",
                newName: "IX_Books_Name");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryBooks_CategoryId",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Cities_CityId",
                table: "UserDetails",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Countries_CountryId",
                table: "UserDetails",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDetails_UserDetailId",
                table: "Users",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id");
        }
    }
}
