using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenWater2.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "T_ATTAINS_REF_WATER_TYPE",
                columns: table => new
                {
                    WATER_TYPE_CODE = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTAINS_REF_WATER_TYPE", x => x.WATER_TYPE_CODE);
                });

            migrationBuilder.CreateTable(
                name: "T_EPA_ORGS",
                columns: table => new
                {
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    ORG_FORMAL_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPA_ORGANIZATION", x => x.ORG_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_OE_APP_SETTINGS",
                columns: table => new
                {
                    SETTING_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SETTING_NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    SETTING_DESC = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    SETTING_VALUE = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    ENCRYPT_IND = table.Column<bool>(nullable: true),
                    SETTING_VALUE_SALT = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OE_APP_SETTINGS", x => x.SETTING_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_OE_APP_TASKS",
                columns: table => new
                {
                    TASK_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TASK_NAME = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    TASK_DESC = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    TASK_STATUS = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TASK_FREQ_MS = table.Column<int>(nullable: false),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OE_APP_TASKS", x => x.TASK_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_OE_ROLES",
                columns: table => new
                {
                    ROLE_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROLE_NAME = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    ROLE_DESC = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OE_ROLES", x => x.ROLE_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_OE_SYS_LOG",
                columns: table => new
                {
                    SYS_LOG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOG_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    LOG_USERIDX = table.Column<int>(nullable: true),
                    LOG_TYPE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    LOG_MSG = table.Column<string>(unicode: false, maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_REF_SYS_LOG", x => x.SYS_LOG_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_OE_USERS",
                columns: table => new
                {
                    USER_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    PWD_HASH = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PWD_SALT = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    FNAME = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
                    LNAME = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    INITAL_PWD_FLAG = table.Column<bool>(nullable: false),
                    EFFECTIVE_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    LASTLOGIN_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    PHONE = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    PHONE_EXT = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    DEFAULT_ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ACT_IND = table.Column<bool>(nullable: false),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OE_USERS", x => x.USER_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_TEMP_ACTIVITY_METRIC",
                columns: table => new
                {
                    TEMP_ACTIVITY_METRIC_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    ACTIVITY_IDX = table.Column<int>(nullable: true),
                    ACTIVITY_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    METRIC_TYPE_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    METRIC_TYPE_ID_CONTEXT = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    METRIC_TYPE_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    METRIC_SCALE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    METRIC_FORMULA_DESC = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    METRIC_VALUE_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    METRIC_VALUE_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    METRIC_SCORE = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    METRIC_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    TEMP_BIO_HABITAT_INDEX_IDX = table.Column<int>(nullable: true),
                    IMPORT_STATUS_CD = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    IMPORT_STATUS_DESC = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_IMPORT_TEMP_ACTIVITY_METRIC", x => x.TEMP_ACTIVITY_METRIC_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_TEMP_BIO_INDEX",
                columns: table => new
                {
                    TEMP_BIO_HABITAT_INDEX_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    MONLOC_IDX = table.Column<int>(nullable: true),
                    INDEX_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    INDEX_TYPE_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    INDEX_TYPE_ID_CONTEXT = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    INDEX_TYPE_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    INDEX_TYPE_SCALE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    INDEX_SCORE = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    INDEX_QUAL_CD = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    INDEX_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    INDEX_CALC_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    IMPORT_STATUS_CD = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    IMPORT_STATUS_DESC = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_IMPORT_TEMP_BIO_INDEX", x => x.TEMP_BIO_HABITAT_INDEX_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_TEMP_MONLOC",
                columns: table => new
                {
                    TEMP_MONLOC_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    MONLOC_IDX = table.Column<int>(nullable: true),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    MONLOC_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    MONLOC_NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    MONLOC_TYPE = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    MONLOC_DESC = table.Column<string>(unicode: false, maxLength: 1999, nullable: true),
                    HUC_EIGHT = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    HUC_TWELVE = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TRIBAL_LAND_IND = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    TRIBAL_LAND_NAME = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    LATITUDE_MSR = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    LONGITUDE_MSR = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    SOURCE_MAP_SCALE = table.Column<int>(nullable: true),
                    HORIZ_ACCURACY = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    HORIZ_ACCURACY_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    HORIZ_COLL_METHOD = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    HORIZ_REF_DATUM = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    VERT_MEASURE = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    VERT_MEASURE_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    VERT_COLL_METHOD = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    VERT_REF_DATUM = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    COUNTRY_CODE = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    STATE_CODE = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    COUNTY_CODE = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    WELL_TYPE = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    AQUIFER_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    FORMATION_TYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    WELLHOLE_DEPTH_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    WELLHOLE_DEPTH_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    IMPORT_STATUS_CD = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    IMPORT_STATUS_DESC = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_IMPORT_TEMP_MONLOC", x => x.TEMP_MONLOC_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_TEMP_PROJECT",
                columns: table => new
                {
                    TEMP_PROJECT_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    PROJECT_IDX = table.Column<int>(nullable: true),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    PROJECT_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    PROJECT_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    PROJECT_DESC = table.Column<string>(unicode: false, maxLength: 1999, nullable: true),
                    SAMP_DESIGN_TYPE_CD = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    QAPP_APPROVAL_IND = table.Column<bool>(nullable: true),
                    QAPP_APPROVAL_AGENCY = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IMPORT_STATUS_CD = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    IMPORT_STATUS_DESC = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_IMPORT_TEMP_PROJECT", x => x.TEMP_PROJECT_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_TEMP_SAMPLE",
                columns: table => new
                {
                    TEMP_SAMPLE_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    PROJECT_IDX = table.Column<int>(nullable: true),
                    PROJECT_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    MONLOC_IDX = table.Column<int>(nullable: true),
                    MONLOC_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    ACTIVITY_IDX = table.Column<int>(nullable: true),
                    ACTIVITY_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    ACT_TYPE = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    ACT_MEDIA = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ACT_SUBMEDIA = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    ACT_START_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ACT_END_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ACT_TIME_ZONE = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    RELATIVE_DEPTH_NAME = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    ACT_DEPTHHEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    ACT_DEPTHHEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TOP_DEPTHHEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TOP_DEPTHHEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BOT_DEPTHHEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BOT_DEPTHHEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEPTH_REF_POINT = table.Column<string>(unicode: false, maxLength: 125, nullable: true),
                    ACT_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    BIO_ASSEMBLAGE_SAMPLED = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    BIO_DURATION_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_DURATION_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_SAMP_COMPONENT = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    BIO_SAMP_COMPONENT_SEQ = table.Column<int>(nullable: true),
                    BIO_REACH_LEN_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_REACH_LEN_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_REACH_WID_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_REACH_WID_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_PASS_COUNT = table.Column<int>(nullable: true),
                    BIO_NET_TYPE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    BIO_NET_AREA_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_NET_AREA_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_NET_MESHSIZE_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_MESHSIZE_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_BOAT_SPEED_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_BOAT_SPEED_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_CURR_SPEED_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_CURR_SPEED_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_TOXICITY_TEST_TYPE = table.Column<string>(unicode: false, maxLength: 7, nullable: true),
                    SAMP_COLL_METHOD_IDX = table.Column<int>(nullable: true),
                    SAMP_COLL_METHOD_ID = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SAMP_COLL_METHOD_CTX = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    SAMP_COLL_METHOD_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    SAMP_COLL_EQUIP = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    SAMP_COLL_EQUIP_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    SAMP_PREP_IDX = table.Column<int>(nullable: true),
                    SAMP_PREP_ID = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SAMP_PREP_CTX = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    SAMP_PREP_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    SAMP_PREP_CONT_TYPE = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    SAMP_PREP_CONT_COLOR = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    SAMP_PREP_CHEM_PRESERV = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    SAMP_PREP_THERM_PRESERV = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    SAMP_PREP_STORAGE_DESC = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    IMPORT_STATUS_CD = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    IMPORT_STATUS_DESC = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_IMPORT_TEMP_SAMPLE", x => x.TEMP_SAMPLE_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_ORGANIZATION",
                columns: table => new
                {
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    ORG_FORMAL_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    ORG_DESC = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    TRIBAL_CODE = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    ELECTRONICADDRESS = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    ELECTRONICADDRESSTYPE = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    TELEPHONE_NUM = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    TELEPHONE_NUM_TYPE = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    TELEPHONE_EXT = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    CDX_SUBMITTER_ID = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CDX_SUBMITTER_PWD_HASH = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CDX_SUBMITTER_PWD_SALT = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CDX_SUBMIT_IND = table.Column<bool>(nullable: true, defaultValueSql: "((1))"),
                    DEFAULT_TIMEZONE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    MAILING_ADDRESS = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    MAILING_ADDRESS2 = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    MAILING_ADD_CITY = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MAILING_ADD_STATE = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    MAILING_ADD_ZIP = table.Column<string>(unicode: false, maxLength: 14, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_ORGANIZATION", x => x.ORG_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_ANAL_METHOD",
                columns: table => new
                {
                    ANALYTIC_METHOD_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ANALYTIC_METHOD_ID = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ANALYTIC_METHOD_CTX = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    ANALYTIC_METHOD_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    ANALYTIC_METHOD_DESC = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_REF_ANAL_METHOD", x => x.ANALYTIC_METHOD_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_CHARACTERISTIC",
                columns: table => new
                {
                    CHAR_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    DEFAULT_DETECT_LIMIT = table.Column<decimal>(type: "decimal(12, 5)", nullable: true),
                    DEFAULT_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    USED_IND = table.Column<bool>(nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    SAMP_FRAC_REQ = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    PICK_LIST = table.Column<string>(unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WQX_REF_CHARACTERISTIC", x => x.CHAR_NAME);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_COUNTY",
                columns: table => new
                {
                    STATE_CODE = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    COUNTY_CODE = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    COUNTY_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ACT_IND = table.Column<bool>(nullable: true),
                    USED_IND = table.Column<bool>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_REF_COUNTY", x => new { x.STATE_CODE, x.COUNTY_CODE });
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_DATA",
                columns: table => new
                {
                    REF_DATA_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TABLE = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    VALUE = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    TEXT = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ACT_IND = table.Column<bool>(nullable: true),
                    USED_IND = table.Column<bool>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_REF_DATA", x => x.REF_DATA_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_DEFAULT_TIME_ZONE",
                columns: table => new
                {
                    TIME_ZONE_NAME = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    OFFICIAL_TIME_ZONE_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    WQX_CODE_STANDARD = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    WQX_CODE_DAYLIGHT = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_REF_DEFAULT_TIME_ZONE", x => x.TIME_ZONE_NAME);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_LAB",
                columns: table => new
                {
                    LAB_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    LAB_NAME = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    LAB_ACCRED_IND = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    LAB_ACCRED_AUTHORITY = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_REF_LAB", x => x.LAB_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_SAMP_COL_METHOD",
                columns: table => new
                {
                    SAMP_COLL_METHOD_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAMP_COLL_METHOD_ID = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    SAMP_COLL_METHOD_CTX = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    SAMP_COLL_METHOD_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    SAMP_COLL_METHOD_DESC = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_REF_SAMP_COL_METHOD", x => x.SAMP_COLL_METHOD_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_SAMP_PREP",
                columns: table => new
                {
                    SAMP_PREP_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAMP_PREP_METHOD_ID = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    SAMP_PREP_METHOD_CTX = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    SAMP_PREP_METHOD_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    SAMP_PREP_METHOD_DESC = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_REF_SAMP_PREP", x => x.SAMP_PREP_IDX);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_TRANSACTION_LOG",
                columns: table => new
                {
                    LOG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TABLE_CD = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    TABLE_IDX = table.Column<int>(nullable: false),
                    SUBMIT_DT = table.Column<DateTime>(type: "datetime", nullable: false),
                    SUBMIT_TYPE = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    RESPONSE_FILE = table.Column<byte[]>(nullable: true),
                    RESPONSE_TXT = table.Column<string>(unicode: false, nullable: true),
                    CDX_SUBMIT_TRANSID = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CDX_SUBMIT_STATUS = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_TRANSACTION_LOG", x => x.LOG_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_OE_USER_ROLES",
                columns: table => new
                {
                    USER_ROLE_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_IDX = table.Column<int>(nullable: false),
                    ROLE_IDX = table.Column<int>(nullable: false),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OE_USER_ROLES", x => x.USER_ROLE_IDX);
                    table.ForeignKey(
                        name: "FK__T_OE_USER__ROLE___1B0907CE",
                        column: x => x.ROLE_IDX,
                        principalTable: "T_OE_ROLES",
                        principalColumn: "ROLE_IDX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__T_OE_USER__USER___1BFD2C07",
                        column: x => x.USER_IDX,
                        principalTable: "T_OE_USERS",
                        principalColumn: "USER_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_TEMP_RESULT",
                columns: table => new
                {
                    TEMP_RESULT_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMP_SAMPLE_IDX = table.Column<int>(nullable: false),
                    RESULT_IDX = table.Column<int>(nullable: true),
                    DATA_LOGGER_LINE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    RESULT_DETECT_CONDITION = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    CHAR_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    METHOD_SPECIATION_NAME = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    RESULT_SAMP_FRACTION = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    RESULT_MSR = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    RESULT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    RESULT_MSR_QUAL = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    RESULT_STATUS = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    STATISTIC_BASE_CODE = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    RESULT_VALUE_TYPE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    WEIGHT_BASIS = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    TIME_BASIS = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TEMP_BASIS = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    PARTICLESIZE_BASIS = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    PRECISION_VALUE = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    BIAS_VALUE = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    CONFIDENCE_INTERVAL_VALUE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    UPPER_CONFIDENCE_LIMIT = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    LOWER_CONFIDENCE_LIMIT = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    RESULT_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    DEPTH_HEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEPTH_HEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEPTHALTITUDEREFPOINT = table.Column<string>(unicode: false, maxLength: 125, nullable: true),
                    BIO_INTENT_NAME = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    BIO_INDIVIDUAL_ID = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    BIO_SUBJECT_TAXONOMY = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    BIO_UNIDENTIFIED_SPECIES_ID = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    BIO_SAMPLE_TISSUE_ANATOMY = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    GRP_SUMM_COUNT_WEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    GRP_SUMM_COUNT_WEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TAX_DTL_CELL_FORM = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    TAX_DTL_CELL_SHAPE = table.Column<string>(unicode: false, maxLength: 18, nullable: true),
                    TAX_DTL_HABIT = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    TAX_DTL_VOLTINISM = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    TAX_DTL_POLL_TOLERANCE = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    TAX_DTL_POLL_TOLERANCE_SCALE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TAX_DTL_TROPHIC_LEVEL = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    TAX_DTL_FUNC_FEEDING_GROUP1 = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    TAX_DTL_FUNC_FEEDING_GROUP2 = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    TAX_DTL_FUNC_FEEDING_GROUP3 = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    FREQ_CLASS_CODE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FREQ_CLASS_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    FREQ_CLASS_UPPER = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    FREQ_CLASS_LOWER = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    ANALYTIC_METHOD_IDX = table.Column<int>(nullable: true),
                    ANALYTIC_METHOD_ID = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ANALYTIC_METHOD_CTX = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    ANALYTIC_METHOD_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    LAB_IDX = table.Column<int>(nullable: true),
                    LAB_NAME = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    LAB_ANALYSIS_START_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAB_ANALYSIS_END_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAB_ANALYSIS_TIMEZONE = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    RESULT_LAB_COMMENT_CODE = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    METHOD_DETECTION_LEVEL = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    LAB_REPORTING_LEVEL = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    PQL = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    LOWER_QUANT_LIMIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    UPPER_QUANT_LIMIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DETECTION_LIMIT_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    LAB_SAMP_PREP_IDX = table.Column<int>(nullable: true),
                    LAB_SAMP_PREP_ID = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    LAB_SAMP_PREP_CTX = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    LAB_SAMP_PREP_START_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAB_SAMP_PREP_END_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DILUTION_FACTOR = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    IMPORT_STATUS_CD = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    IMPORT_STATUS_DESC = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_IMPORT_TEMP_RESULT", x => x.TEMP_RESULT_IDX);
                    table.ForeignKey(
                        name: "FK__T_WQX_IMP__TEMP___6754599E",
                        column: x => x.TEMP_SAMPLE_IDX,
                        principalTable: "T_WQX_IMPORT_TEMP_SAMPLE",
                        principalColumn: "TEMP_SAMPLE_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ATTAINS_REPORT",
                columns: table => new
                {
                    ATTAINS_REPORT_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    REPORT_NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    DATA_FROM = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATA_TO = table.Column<DateTime>(type: "datetime", nullable: true),
                    ATTAINS_IND = table.Column<bool>(nullable: true),
                    ATTAINS_SUBMIT_STATUS = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    ATTAINS_UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTAINS_REPORT", x => x.ATTAINS_REPORT_IDX);
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__ORG_I__7D439ABD",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_LOG",
                columns: table => new
                {
                    IMPORT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    TYPE_CD = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    FILE_NAME = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    FILE_SIZE = table.Column<int>(nullable: false),
                    IMPORT_STATUS = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    IMPORT_PROGRESS = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    IMPORT_PROGRESS_MSG = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    IMPORT_FILE = table.Column<byte[]>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_IMPORT_LOG", x => x.IMPORT_ID);
                    table.ForeignKey(
                        name: "FK__T_WQX_IMP__ORG_I__5CD6CB2B",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_TEMPLATE",
                columns: table => new
                {
                    TEMPLATE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    TYPE_CD = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    TEMPLATE_NAME = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_IMPORT_TEMPLATE", x => x.TEMPLATE_ID);
                    table.ForeignKey(
                        name: "FK__T_WQX_IMP__ORG_I__5FB337D6",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_TRANSLATE",
                columns: table => new
                {
                    TRANSLATE_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    COL_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DATA_FROM = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    DATA_TO = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_IMPORT_TRANSLATE", x => x.TRANSLATE_IDX);
                    table.ForeignKey(
                        name: "FK__T_WQX_IMP__ORG_I__71D1E811",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_MONLOC",
                columns: table => new
                {
                    MONLOC_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    MONLOC_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    MONLOC_NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    MONLOC_TYPE = table.Column<string>(unicode: false, maxLength: 45, nullable: false),
                    MONLOC_DESC = table.Column<string>(unicode: false, maxLength: 1999, nullable: true),
                    HUC_EIGHT = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    HUC_TWELVE = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TRIBAL_LAND_IND = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    TRIBAL_LAND_NAME = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    LATITUDE_MSR = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    LONGITUDE_MSR = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    SOURCE_MAP_SCALE = table.Column<int>(nullable: true),
                    HORIZ_ACCURACY = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    HORIZ_ACCURACY_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    HORIZ_COLL_METHOD = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    HORIZ_REF_DATUM = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    VERT_MEASURE = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    VERT_MEASURE_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    VERT_COLL_METHOD = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    VERT_REF_DATUM = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    COUNTRY_CODE = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    STATE_CODE = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    COUNTY_CODE = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    WELL_TYPE = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    AQUIFER_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    FORMATION_TYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    WELLHOLE_DEPTH_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    WELLHOLE_DEPTH_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    WQX_IND = table.Column<bool>(nullable: true),
                    WQX_SUBMIT_STATUS = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    WQX_UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    IMPORT_MONLOC_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_MONLOC", x => x.MONLOC_IDX);
                    table.ForeignKey(
                        name: "FK__T_WQX_MON__ORG_I__3F466844",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_ORG_ADDRESS",
                columns: table => new
                {
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    ADDRESS_TYPE = table.Column<string>(unicode: false, maxLength: 8, nullable: false),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    SUPP_ADDRESS = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    LOCALITY = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    STATE_CD = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    POSTAL_CD = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    COUNTRY_CD = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    COUNTY_CD = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_ORG_ADDRESS", x => new { x.ORG_ID, x.ADDRESS_TYPE });
                    table.ForeignKey(
                        name: "FK__T_WQX_ORG__ORG_I__35BCFE0A",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_PROJECT",
                columns: table => new
                {
                    PROJECT_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    PROJECT_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    PROJECT_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    PROJECT_DESC = table.Column<string>(unicode: false, maxLength: 1999, nullable: true),
                    SAMP_DESIGN_TYPE_CD = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    QAPP_APPROVAL_IND = table.Column<bool>(nullable: true),
                    QAPP_APPROVAL_AGENCY = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    WQX_IND = table.Column<bool>(nullable: true),
                    WQX_SUBMIT_STATUS = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    WQX_UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_PROJECT", x => x.PROJECT_IDX);
                    table.ForeignKey(
                        name: "FK__T_WQX_PRO__ORG_I__3C69FB99",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_TAXA_ORG",
                columns: table => new
                {
                    BIO_SUBJECT_TAXONOMY = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WQX_REF_TAXA_ORG", x => new { x.ORG_ID, x.BIO_SUBJECT_TAXONOMY });
                    table.ForeignKey(
                        name: "FK__T_WQX_REF__ORG_I__5812160E",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_USER_ORGS",
                columns: table => new
                {
                    USER_IDX = table.Column<int>(nullable: false),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    ROLE_CD = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OE_USER_ORGS", x => new { x.USER_IDX, x.ORG_ID });
                    table.ForeignKey(
                        name: "FK__T_WQX_USE__ORG_I__38996AB5",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__T_WQX_USE__USER___398D8EEE",
                        column: x => x.USER_IDX,
                        principalTable: "T_OE_USERS",
                        principalColumn: "USER_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_CHAR_LIMITS",
                columns: table => new
                {
                    CHAR_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    UNIT_NAME = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
                    LOWER_BOUND = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    UPPER_BOUND = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WQX_REF_CHAR_LIMITS", x => new { x.CHAR_NAME, x.UNIT_NAME });
                    table.ForeignKey(
                        name: "FK__T_WQX_REF__CHAR___2E1BDC42",
                        column: x => x.CHAR_NAME,
                        principalTable: "T_WQX_REF_CHARACTERISTIC",
                        principalColumn: "CHAR_NAME",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_REF_CHAR_ORG",
                columns: table => new
                {
                    CHAR_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: false),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DEFAULT_DETECT_LIMIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEFAULT_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEFAULT_ANAL_METHOD_IDX = table.Column<int>(nullable: true),
                    DEFAULT_SAMP_FRACTION = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    DEFAULT_RESULT_STATUS = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEFAULT_RESULT_VALUE_TYPE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    DEFAULT_LOWER_QUANT_LIMIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEFAULT_UPPER_QUANT_LIMIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WQX_REF_CHAR_ORG", x => new { x.ORG_ID, x.CHAR_NAME });
                    table.ForeignKey(
                        name: "FK__T_WQX_REF__CHAR___5441852A",
                        column: x => x.CHAR_NAME,
                        principalTable: "T_WQX_REF_CHARACTERISTIC",
                        principalColumn: "CHAR_NAME",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_WQX_REF_CHAR_ORG",
                        column: x => x.DEFAULT_ANAL_METHOD_IDX,
                        principalTable: "T_WQX_REF_ANAL_METHOD",
                        principalColumn: "ANALYTIC_METHOD_IDX",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__T_WQX_REF__ORG_I__534D60F1",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ATTAINS_ASSESS_UNITS",
                columns: table => new
                {
                    ATTAINS_ASSESS_UNIT_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTAINS_REPORT_IDX = table.Column<int>(nullable: false),
                    ASSESS_UNIT_ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ASSESS_UNIT_NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    LOCATION_DESC = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    AGENCY_CODE = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    STATE_CODE = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    ACT_IND = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    WATER_TYPE_CODE = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    WATER_SIZE = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    WATER_UNIT_CODE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    USE_CLASS_CODE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    USE_CLASS_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTAINS_ASSESS_UNIT", x => x.ATTAINS_ASSESS_UNIT_IDX);
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__ATTAI__02084FDA",
                        column: x => x.ATTAINS_REPORT_IDX,
                        principalTable: "T_ATTAINS_REPORT",
                        principalColumn: "ATTAINS_REPORT_IDX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__WATER__02FC7413",
                        column: x => x.WATER_TYPE_CODE,
                        principalTable: "T_ATTAINS_REF_WATER_TYPE",
                        principalColumn: "WATER_TYPE_CODE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ATTAINS_REPORT_LOG",
                columns: table => new
                {
                    ATTAINS_LOG_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTAINS_REPORT_IDX = table.Column<int>(nullable: false),
                    SUBMIT_DT = table.Column<DateTime>(type: "datetime", nullable: false),
                    SUBMIT_FILE = table.Column<string>(unicode: false, nullable: true),
                    RESPONSE_FILE = table.Column<byte[]>(nullable: true),
                    RESPONSE_TXT = table.Column<string>(unicode: false, nullable: true),
                    CDX_SUBMIT_TRANSID = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CDX_SUBMIT_STATUS = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTAINS_REPORT_LOG", x => x.ATTAINS_LOG_IDX);
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__ATTAI__151B244E",
                        column: x => x.ATTAINS_REPORT_IDX,
                        principalTable: "T_ATTAINS_REPORT",
                        principalColumn: "ATTAINS_REPORT_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_IMPORT_TEMPLATE_DTL",
                columns: table => new
                {
                    TEMPLATE_DTL_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEMPLATE_ID = table.Column<int>(nullable: false),
                    COL_NUM = table.Column<int>(nullable: false),
                    FIELD_MAP = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CHAR_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    CHAR_DEFAULT_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CHAR_DEFAULT_SAMP_FRACTION = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_IMPORT_TEMPLATE_DTL", x => x.TEMPLATE_DTL_ID);
                    table.ForeignKey(
                        name: "FK__T_WQX_IMP__TEMPL__628FA481",
                        column: x => x.TEMPLATE_ID,
                        principalTable: "T_WQX_IMPORT_TEMPLATE",
                        principalColumn: "TEMPLATE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_BIO_HABITAT_INDEX",
                columns: table => new
                {
                    BIO_HABITAT_INDEX_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    MONLOC_IDX = table.Column<int>(nullable: true),
                    INDEX_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    INDEX_TYPE_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    INDEX_TYPE_ID_CONTEXT = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    INDEX_TYPE_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    RESOURCE_TITLE = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    RESOURCE_CREATOR = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    RESOURCE_SUBJECT = table.Column<string>(unicode: false, maxLength: 400, nullable: true),
                    RESOURCE_PUBLISHER = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    RESOURCE_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    RESOURCE_ID = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    INDEX_TYPE_SCALE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    INDEX_SCORE = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    INDEX_QUAL_CD = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    INDEX_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    INDEX_CALC_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    WQX_IND = table.Column<bool>(nullable: true),
                    WQX_SUBMIT_STATUS = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    WQX_UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WQX_BIO_HABITAT_INDEX", x => x.BIO_HABITAT_INDEX_IDX);
                    table.ForeignKey(
                        name: "FK__T_WQX_BIO__MONLO__46E78A0C",
                        column: x => x.MONLOC_IDX,
                        principalTable: "T_WQX_MONLOC",
                        principalColumn: "MONLOC_IDX",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__T_WQX_BIO__ORG_I__47DBAE45",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_ACTIVITY",
                columns: table => new
                {
                    ACTIVITY_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORG_ID = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    PROJECT_IDX = table.Column<int>(nullable: false),
                    MONLOC_IDX = table.Column<int>(nullable: true),
                    ACTIVITY_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    ACT_TYPE = table.Column<string>(unicode: false, maxLength: 70, nullable: false),
                    ACT_MEDIA = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    ACT_SUBMEDIA = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    ACT_START_DT = table.Column<DateTime>(type: "datetime", nullable: false),
                    ACT_END_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ACT_TIME_ZONE = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    RELATIVE_DEPTH_NAME = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    ACT_DEPTHHEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    ACT_DEPTHHEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TOP_DEPTHHEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TOP_DEPTHHEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BOT_DEPTHHEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BOT_DEPTHHEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEPTH_REF_POINT = table.Column<string>(unicode: false, maxLength: 125, nullable: true),
                    ACT_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    BIO_ASSEMBLAGE_SAMPLED = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    BIO_DURATION_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_DURATION_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_SAMP_COMPONENT = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    BIO_SAMP_COMPONENT_SEQ = table.Column<int>(nullable: true),
                    BIO_REACH_LEN_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_REACH_LEN_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_REACH_WID_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_REACH_WID_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_PASS_COUNT = table.Column<int>(nullable: true),
                    BIO_NET_TYPE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    BIO_NET_AREA_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_NET_AREA_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_NET_MESHSIZE_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_MESHSIZE_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_BOAT_SPEED_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_BOAT_SPEED_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_CURR_SPEED_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_CURR_SPEED_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_TOXICITY_TEST_TYPE = table.Column<string>(unicode: false, maxLength: 7, nullable: true),
                    SAMP_COLL_METHOD_IDX = table.Column<int>(nullable: true),
                    SAMP_COLL_EQUIP = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    SAMP_COLL_EQUIP_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    SAMP_PREP_IDX = table.Column<int>(nullable: true),
                    SAMP_PREP_CONT_TYPE = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    SAMP_PREP_CONT_COLOR = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    SAMP_PREP_CHEM_PRESERV = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    SAMP_PREP_THERM_PRESERV = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    SAMP_PREP_STORAGE_DESC = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    WQX_IND = table.Column<bool>(nullable: true),
                    WQX_SUBMIT_STATUS = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    WQX_UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    TEMP_SAMPLE_IDX = table.Column<int>(nullable: true),
                    ENTRY_TYPE = table.Column<string>(unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_ACTIVITY", x => x.ACTIVITY_IDX);
                    table.ForeignKey(
                        name: "FK__T_WQX_ACT__MONLO__4316F928",
                        column: x => x.MONLOC_IDX,
                        principalTable: "T_WQX_MONLOC",
                        principalColumn: "MONLOC_IDX",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__T_WQX_ACT__ORG_I__440B1D61",
                        column: x => x.ORG_ID,
                        principalTable: "T_WQX_ORGANIZATION",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__T_WQX_ACT__PROJE__4222D4EF",
                        column: x => x.PROJECT_IDX,
                        principalTable: "T_WQX_PROJECT",
                        principalColumn: "PROJECT_IDX",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_ATTAINS_ASSESS",
                columns: table => new
                {
                    ATTAINS_ASSESS_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REPORTING_CYCLE = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    REPORT_STATUS = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    ATTAINS_ASSESS_UNIT_IDX = table.Column<int>(nullable: false),
                    AGENCY_CODE = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    CYCLE_LAST_ASSESSED = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    CYCLE_LAST_MONITORED = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    TROPHIC_STATUS_CODE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTAINS_ASSESS", x => x.ATTAINS_ASSESS_IDX);
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__ATTAI__09A971A2",
                        column: x => x.ATTAINS_ASSESS_UNIT_IDX,
                        principalTable: "T_ATTAINS_ASSESS_UNITS",
                        principalColumn: "ATTAINS_ASSESS_UNIT_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ATTAINS_ASSESS_UNITS_MLOC",
                columns: table => new
                {
                    ATTAINS_ASSESS_UNIT_IDX = table.Column<int>(nullable: false),
                    MONLOC_IDX = table.Column<int>(nullable: false),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTAINS_ASSESS_UNIT_MLOC", x => new { x.ATTAINS_ASSESS_UNIT_IDX, x.MONLOC_IDX });
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__ATTAI__05D8E0BE",
                        column: x => x.ATTAINS_ASSESS_UNIT_IDX,
                        principalTable: "T_ATTAINS_ASSESS_UNITS",
                        principalColumn: "ATTAINS_ASSESS_UNIT_IDX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__MONLO__06CD04F7",
                        column: x => x.MONLOC_IDX,
                        principalTable: "T_WQX_MONLOC",
                        principalColumn: "MONLOC_IDX",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_ACTIVITY_METRIC",
                columns: table => new
                {
                    ACTIVITY_METRIC_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACTIVITY_IDX = table.Column<int>(nullable: false),
                    METRIC_TYPE_ID = table.Column<string>(unicode: false, maxLength: 35, nullable: false),
                    METRIC_TYPE_ID_CONTEXT = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    METRIC_TYPE_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CITATION_TITLE = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    CITATION_CREATOR = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    CITATION_SUBJECT = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CITATION_PUBLISHER = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    CITATION_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    CITATION_ID = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    METRIC_SCALE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    METRIC_FORMULA_DESC = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    METRIC_VALUE_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    METRIC_VALUE_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    METRIC_SCORE = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    METRIC_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    BIO_HABITAT_INDEX_IDX = table.Column<int>(nullable: true),
                    WQX_IND = table.Column<bool>(nullable: true),
                    WQX_SUBMIT_STATUS = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    WQX_UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    ACT_IND = table.Column<bool>(nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    UPDATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    UPDATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_ACTIVITYMETRIC", x => x.ACTIVITY_METRIC_IDX);
                    table.ForeignKey(
                        name: "FK__T_WQX_ACT__ACTIV__4AB81AF0",
                        column: x => x.ACTIVITY_IDX,
                        principalTable: "T_WQX_ACTIVITY",
                        principalColumn: "ACTIVITY_IDX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__T_WQX_ACT__BIO_H__4BAC3F29",
                        column: x => x.BIO_HABITAT_INDEX_IDX,
                        principalTable: "T_WQX_BIO_HABITAT_INDEX",
                        principalColumn: "BIO_HABITAT_INDEX_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WQX_RESULT",
                columns: table => new
                {
                    RESULT_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACTIVITY_IDX = table.Column<int>(nullable: false),
                    DATA_LOGGER_LINE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    RESULT_DETECT_CONDITION = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    CHAR_NAME = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    METHOD_SPECIATION_NAME = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    RESULT_SAMP_FRACTION = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    RESULT_MSR = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    RESULT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    RESULT_MSR_QUAL = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    RESULT_STATUS = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    STATISTIC_BASE_CODE = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    RESULT_VALUE_TYPE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    WEIGHT_BASIS = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    TIME_BASIS = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TEMP_BASIS = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    PARTICLESIZE_BASIS = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    PRECISION_VALUE = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    BIAS_VALUE = table.Column<string>(unicode: false, maxLength: 60, nullable: true),
                    CONFIDENCE_INTERVAL_VALUE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    UPPER_CONFIDENCE_LIMIT = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    LOWER_CONFIDENCE_LIMIT = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    RESULT_COMMENT = table.Column<string>(unicode: false, maxLength: 4000, nullable: true),
                    DEPTH_HEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEPTH_HEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DEPTHALTITUDEREFPOINT = table.Column<string>(unicode: false, maxLength: 125, nullable: true),
                    RESULT_SAMP_POINT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    BIO_INTENT_NAME = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    BIO_INDIVIDUAL_ID = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    BIO_SUBJECT_TAXONOMY = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    BIO_UNIDENTIFIED_SPECIES_ID = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    BIO_SAMPLE_TISSUE_ANATOMY = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    GRP_SUMM_COUNT_WEIGHT_MSR = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    GRP_SUMM_COUNT_WEIGHT_MSR_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    TAX_DTL_CELL_FORM = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    TAX_DTL_CELL_SHAPE = table.Column<string>(unicode: false, maxLength: 18, nullable: true),
                    TAX_DTL_HABIT = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    TAX_DTL_VOLTINISM = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    TAX_DTL_POLL_TOLERANCE = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    TAX_DTL_POLL_TOLERANCE_SCALE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TAX_DTL_TROPHIC_LEVEL = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    TAX_DTL_FUNC_FEEDING_GROUP1 = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    TAX_DTL_FUNC_FEEDING_GROUP2 = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    TAX_DTL_FUNC_FEEDING_GROUP3 = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    FREQ_CLASS_CODE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    FREQ_CLASS_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    FREQ_CLASS_UPPER = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    FREQ_CLASS_LOWER = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    ANALYTIC_METHOD_IDX = table.Column<int>(nullable: true),
                    LAB_IDX = table.Column<int>(nullable: true),
                    LAB_ANALYSIS_START_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAB_ANALYSIS_END_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAB_ANALYSIS_TIMEZONE = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    RESULT_LAB_COMMENT_CODE = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    DETECTION_LIMIT_TYPE = table.Column<string>(unicode: false, maxLength: 35, nullable: true),
                    DETECTION_LIMIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    LAB_TAXON_ACCRED_IND = table.Column<string>(unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    LAB_TAXON_ACCRED_AUTHORITY = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    LAB_REPORTING_LEVEL = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    PQL = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    LOWER_QUANT_LIMIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    UPPER_QUANT_LIMIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    DETECTION_LIMIT_UNIT = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    LAB_SAMP_PREP_IDX = table.Column<int>(nullable: true),
                    LAB_SAMP_PREP_START_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    LAB_SAMP_PREP_END_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DILUTION_FACTOR = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WQX_RESULT", x => x.RESULT_IDX);
                    table.ForeignKey(
                        name: "FK__T_WQX_RES__ACTIV__4E88ABD4",
                        column: x => x.ACTIVITY_IDX,
                        principalTable: "T_WQX_ACTIVITY",
                        principalColumn: "ACTIVITY_IDX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__T_WQX_RES__ANALY__5070F446",
                        column: x => x.ANALYTIC_METHOD_IDX,
                        principalTable: "T_WQX_REF_ANAL_METHOD",
                        principalColumn: "ANALYTIC_METHOD_IDX",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__T_WQX_RES__LAB_I__4F7CD00D",
                        column: x => x.LAB_IDX,
                        principalTable: "T_WQX_REF_LAB",
                        principalColumn: "LAB_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ATTAINS_ASSESS_CAUSE",
                columns: table => new
                {
                    ATTAINS_ASSESS_CAUSE_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTAINS_ASSESS_IDX = table.Column<int>(nullable: false),
                    CAUSE_NAME = table.Column<string>(unicode: false, maxLength: 240, nullable: true),
                    POLLUTANT_IND = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    AGENCY_CODE = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    CYCLE_FIRST_LISTED = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    CYCLE_SCHED_TMDL = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    TMDL_PRIORITY_NAME = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CONSENT_DECREE_CYCLE = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    TMDL_CAUSE_REPORT_ID = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    CYCLE_EXPECTED_ATTAIN = table.Column<string>(unicode: false, maxLength: 4, nullable: true),
                    CAUSE_COMMENT = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTAINS_ASSESS_CAUSE", x => x.ATTAINS_ASSESS_CAUSE_IDX);
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__ATTAI__123EB7A3",
                        column: x => x.ATTAINS_ASSESS_IDX,
                        principalTable: "T_ATTAINS_ASSESS",
                        principalColumn: "ATTAINS_ASSESS_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ATTAINS_ASSESS_USE",
                columns: table => new
                {
                    ATTAINS_ASSESS_USE_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTAINS_ASSESS_IDX = table.Column<int>(nullable: false),
                    USE_NAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    USE_ATTAINMENT_CODE = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    THREATENED_IND = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    TREND_CODE = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    IR_CAT_CODE = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    IR_CAT_DESC = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ASSESS_BASIS = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ASSESS_TYPE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ASSESS_CONFIDENCE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    MON_DATE_START = table.Column<DateTime>(type: "datetime", nullable: true),
                    MON_DATE_END = table.Column<DateTime>(type: "datetime", nullable: true),
                    ASSESS_DATE = table.Column<DateTime>(type: "datetime", nullable: true),
                    ASSESSOR_NAME = table.Column<string>(unicode: false, maxLength: 80, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTAINS_ASSESS_USE", x => x.ATTAINS_ASSESS_USE_IDX);
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__ATTAI__0C85DE4D",
                        column: x => x.ATTAINS_ASSESS_IDX,
                        principalTable: "T_ATTAINS_ASSESS",
                        principalColumn: "ATTAINS_ASSESS_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ATTAINS_ASSESS_USE_PAR",
                columns: table => new
                {
                    ATTAINS_ASSESS_USE_PAR_IDX = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTAINS_ASSESS_USE_IDX = table.Column<int>(nullable: false),
                    PARAM_NAME = table.Column<string>(unicode: false, maxLength: 240, nullable: true),
                    PARAM_ATTAINMENT_CODE = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    TREND_CODE = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    PARAM_COMMENT = table.Column<string>(unicode: false, maxLength: 1000, nullable: true),
                    CREATE_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATE_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MODIFY_DT = table.Column<DateTime>(type: "datetime", nullable: true),
                    MODIFY_USERID = table.Column<string>(unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTAINS_ASSESS_USE_PAR", x => x.ATTAINS_ASSESS_USE_PAR_IDX);
                    table.ForeignKey(
                        name: "FK__T_ATTAINS__ATTAI__0F624AF8",
                        column: x => x.ATTAINS_ASSESS_USE_IDX,
                        principalTable: "T_ATTAINS_ASSESS_USE",
                        principalColumn: "ATTAINS_ASSESS_USE_IDX",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_T_ATTAINS_ASSESS_ATTAINS_ASSESS_UNIT_IDX",
                table: "T_ATTAINS_ASSESS",
                column: "ATTAINS_ASSESS_UNIT_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_ATTAINS_ASSESS_CAUSE_ATTAINS_ASSESS_IDX",
                table: "T_ATTAINS_ASSESS_CAUSE",
                column: "ATTAINS_ASSESS_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_ATTAINS_ASSESS_UNITS_ATTAINS_REPORT_IDX",
                table: "T_ATTAINS_ASSESS_UNITS",
                column: "ATTAINS_REPORT_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_ATTAINS_ASSESS_UNITS_WATER_TYPE_CODE",
                table: "T_ATTAINS_ASSESS_UNITS",
                column: "WATER_TYPE_CODE");

            migrationBuilder.CreateIndex(
                name: "IX_T_ATTAINS_ASSESS_UNITS_MLOC_MONLOC_IDX",
                table: "T_ATTAINS_ASSESS_UNITS_MLOC",
                column: "MONLOC_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_ATTAINS_ASSESS_USE_ATTAINS_ASSESS_IDX",
                table: "T_ATTAINS_ASSESS_USE",
                column: "ATTAINS_ASSESS_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_ATTAINS_ASSESS_USE_PAR_ATTAINS_ASSESS_USE_IDX",
                table: "T_ATTAINS_ASSESS_USE_PAR",
                column: "ATTAINS_ASSESS_USE_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_ATTAINS_REPORT_ORG_ID",
                table: "T_ATTAINS_REPORT",
                column: "ORG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_ATTAINS_REPORT_LOG_ATTAINS_REPORT_IDX",
                table: "T_ATTAINS_REPORT_LOG",
                column: "ATTAINS_REPORT_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_OE_USER_ROLES_ROLE_IDX",
                table: "T_OE_USER_ROLES",
                column: "ROLE_IDX");

            migrationBuilder.CreateIndex(
                name: "UK_T_OE_USER_ROLES",
                table: "T_OE_USER_ROLES",
                columns: new[] { "USER_IDX", "ROLE_IDX" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_ACTIVITY_MONLOC_IDX",
                table: "T_WQX_ACTIVITY",
                column: "MONLOC_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_ACTIVITY_ORG_ID",
                table: "T_WQX_ACTIVITY",
                column: "ORG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_ACTIVITY_PROJECT_IDX",
                table: "T_WQX_ACTIVITY",
                column: "PROJECT_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_ACTIVITY_METRIC_ACTIVITY_IDX",
                table: "T_WQX_ACTIVITY_METRIC",
                column: "ACTIVITY_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_ACTIVITY_METRIC_BIO_HABITAT_INDEX_IDX",
                table: "T_WQX_ACTIVITY_METRIC",
                column: "BIO_HABITAT_INDEX_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_BIO_HABITAT_INDEX_MONLOC_IDX",
                table: "T_WQX_BIO_HABITAT_INDEX",
                column: "MONLOC_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_BIO_HABITAT_INDEX_ORG_ID",
                table: "T_WQX_BIO_HABITAT_INDEX",
                column: "ORG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_IMPORT_LOG_ORG_ID",
                table: "T_WQX_IMPORT_LOG",
                column: "ORG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_IMPORT_TEMP_RESULT_TEMP_SAMPLE_IDX",
                table: "T_WQX_IMPORT_TEMP_RESULT",
                column: "TEMP_SAMPLE_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_IMPORT_TEMPLATE_ORG_ID",
                table: "T_WQX_IMPORT_TEMPLATE",
                column: "ORG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_IMPORT_TEMPLATE_DTL_TEMPLATE_ID",
                table: "T_WQX_IMPORT_TEMPLATE_DTL",
                column: "TEMPLATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_IMPORT_TRANSLATE_ORG_ID",
                table: "T_WQX_IMPORT_TRANSLATE",
                column: "ORG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_MONLOC_ORG_ID",
                table: "T_WQX_MONLOC",
                column: "ORG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_PROJECT_ORG_ID",
                table: "T_WQX_PROJECT",
                column: "ORG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_REF_CHAR_ORG_CHAR_NAME",
                table: "T_WQX_REF_CHAR_ORG",
                column: "CHAR_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_REF_CHAR_ORG_DEFAULT_ANAL_METHOD_IDX",
                table: "T_WQX_REF_CHAR_ORG",
                column: "DEFAULT_ANAL_METHOD_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_RESULT_ACTIVITY_IDX",
                table: "T_WQX_RESULT",
                column: "ACTIVITY_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_RESULT_ANALYTIC_METHOD_IDX",
                table: "T_WQX_RESULT",
                column: "ANALYTIC_METHOD_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_RESULT_LAB_IDX",
                table: "T_WQX_RESULT",
                column: "LAB_IDX");

            migrationBuilder.CreateIndex(
                name: "IX_T_WQX_USER_ORGS_ORG_ID",
                table: "T_WQX_USER_ORGS",
                column: "ORG_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "T_ATTAINS_ASSESS_CAUSE");

            migrationBuilder.DropTable(
                name: "T_ATTAINS_ASSESS_UNITS_MLOC");

            migrationBuilder.DropTable(
                name: "T_ATTAINS_ASSESS_USE_PAR");

            migrationBuilder.DropTable(
                name: "T_ATTAINS_REPORT_LOG");

            migrationBuilder.DropTable(
                name: "T_EPA_ORGS");

            migrationBuilder.DropTable(
                name: "T_OE_APP_SETTINGS");

            migrationBuilder.DropTable(
                name: "T_OE_APP_TASKS");

            migrationBuilder.DropTable(
                name: "T_OE_SYS_LOG");

            migrationBuilder.DropTable(
                name: "T_OE_USER_ROLES");

            migrationBuilder.DropTable(
                name: "T_WQX_ACTIVITY_METRIC");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_LOG");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_TEMP_ACTIVITY_METRIC");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_TEMP_BIO_INDEX");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_TEMP_MONLOC");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_TEMP_PROJECT");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_TEMP_RESULT");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_TEMPLATE_DTL");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_TRANSLATE");

            migrationBuilder.DropTable(
                name: "T_WQX_ORG_ADDRESS");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_CHAR_LIMITS");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_CHAR_ORG");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_COUNTY");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_DATA");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_DEFAULT_TIME_ZONE");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_SAMP_COL_METHOD");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_SAMP_PREP");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_TAXA_ORG");

            migrationBuilder.DropTable(
                name: "T_WQX_RESULT");

            migrationBuilder.DropTable(
                name: "T_WQX_TRANSACTION_LOG");

            migrationBuilder.DropTable(
                name: "T_WQX_USER_ORGS");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "T_ATTAINS_ASSESS_USE");

            migrationBuilder.DropTable(
                name: "T_OE_ROLES");

            migrationBuilder.DropTable(
                name: "T_WQX_BIO_HABITAT_INDEX");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_TEMP_SAMPLE");

            migrationBuilder.DropTable(
                name: "T_WQX_IMPORT_TEMPLATE");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_CHARACTERISTIC");

            migrationBuilder.DropTable(
                name: "T_WQX_ACTIVITY");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_ANAL_METHOD");

            migrationBuilder.DropTable(
                name: "T_WQX_REF_LAB");

            migrationBuilder.DropTable(
                name: "T_OE_USERS");

            migrationBuilder.DropTable(
                name: "T_ATTAINS_ASSESS");

            migrationBuilder.DropTable(
                name: "T_WQX_MONLOC");

            migrationBuilder.DropTable(
                name: "T_WQX_PROJECT");

            migrationBuilder.DropTable(
                name: "T_ATTAINS_ASSESS_UNITS");

            migrationBuilder.DropTable(
                name: "T_ATTAINS_REPORT");

            migrationBuilder.DropTable(
                name: "T_ATTAINS_REF_WATER_TYPE");

            migrationBuilder.DropTable(
                name: "T_WQX_ORGANIZATION");
        }
    }
}
