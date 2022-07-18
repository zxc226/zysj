using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ZYSJModer.Migrations
{
    public partial class ZYSJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOOKS",
                columns: table => new
                {
                    BID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BJJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIMG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKS", x => x.BID);
                });

            migrationBuilder.CreateTable(
                name: "CSXX",
                columns: table => new
                {
                    XSID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    XSXX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XSIMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XSDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    XSWJ = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSXX", x => x.XSID);
                });

            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    ZDID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZDTYPE = table.Column<int>(type: "int", nullable: true),
                    ZDNAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.ZDID);
                });

            migrationBuilder.CreateTable(
                name: "FILE",
                columns: table => new
                {
                    FID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FUSER = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FTYPE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILE", x => x.FID);
                });

            migrationBuilder.CreateTable(
                name: "HFXX",
                columns: table => new
                {
                    HFID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HFPL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DZNUM = table.Column<int>(type: "int", nullable: true),
                    HFUSER = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HFDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HFXX", x => x.HFID);
                });

            migrationBuilder.CreateTable(
                name: "JDXX",
                columns: table => new
                {
                    JDID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JDNR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JDING = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JDWJ = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CSID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JDXX", x => x.JDID);
                });

            migrationBuilder.CreateTable(
                name: "JL",
                columns: table => new
                {
                    JID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JTITLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JLXX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JLIMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JUSER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DZNUM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JL", x => x.JID);
                });

            migrationBuilder.CreateTable(
                name: "LY",
                columns: table => new
                {
                    LID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LYXX = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LYUSER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LYRQ = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LY", x => x.LID);
                });

            migrationBuilder.CreateTable(
                name: "PLXX",
                columns: table => new
                {
                    PID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PLHFID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DZNUM = table.Column<int>(type: "int", nullable: true),
                    PUSER = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLXX", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "Uselogin",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Users = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PWD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LV = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uselogin", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSF = table.Column<int>(type: "int", nullable: true),
                    QQID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UQM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UIMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATE = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WORKPLACE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRTHDAY = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NICK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZYM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SPECIAALIZED = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "VIDES",
                columns: table => new
                {
                    VID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VSC = table.Column<int>(type: "int", nullable: true),
                    VIMG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIDES", x => x.VID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOKS");

            migrationBuilder.DropTable(
                name: "CSXX");

            migrationBuilder.DropTable(
                name: "Dictionary");

            migrationBuilder.DropTable(
                name: "FILE");

            migrationBuilder.DropTable(
                name: "HFXX");

            migrationBuilder.DropTable(
                name: "JDXX");

            migrationBuilder.DropTable(
                name: "JL");

            migrationBuilder.DropTable(
                name: "LY");

            migrationBuilder.DropTable(
                name: "PLXX");

            migrationBuilder.DropTable(
                name: "Uselogin");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VIDES");
        }
    }
}
