using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeadManagementSystem.UserManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analysis",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DimensionPropertiesString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PivotGridSettingsContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ChartSettingsContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AuditEFCoreWeakReference",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DefaultString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEFCoreWeakReference", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DashboardData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SynchronizeTitle = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardData", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllDay = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RecurrenceInfoXml = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RecurrencePatternID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReminderInfoXml = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RemindInSeconds = table.Column<int>(type: "int", nullable: false),
                    AlarmTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPostponed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Event_Event_RecurrencePatternID",
                        column: x => x.RecurrencePatternID,
                        principalTable: "Event",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FileData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KpiDefinition",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    TargetObjectTypeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GreenZone = table.Column<float>(type: "real", nullable: false),
                    RedZone = table.Column<float>(type: "real", nullable: false),
                    Compare = table.Column<bool>(type: "bit", nullable: false),
                    RangeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RangeToCompareName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementFrequency = table.Column<int>(type: "int", nullable: false),
                    MeasurementMode = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false),
                    ChangedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuppressedSeries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnableCustomizeRepresentation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpiDefinition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KpiScorecard",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpiScorecard", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModelDifferences",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContextId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyRoleBase",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdministrative = table.Column<bool>(type: "bit", nullable: false),
                    CanEditModel = table.Column<bool>(type: "bit", nullable: false),
                    PermissionPolicy = table.Column<int>(type: "int", nullable: false),
                    IsAllowPermissionPriority = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyRoleBase", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyUser",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ChangePasswordOnFirstLogon = table.Column<bool>(type: "bit", nullable: false),
                    StoredPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: true),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReportDataV2",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInplaceReport = table.Column<bool>(type: "bit", nullable: false),
                    PredefinedReportTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParametersObjectTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDataV2", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color_Int = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AuditData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditedObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OldObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NewObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_AuditedObjectID",
                        column: x => x.AuditedObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_NewObjectID",
                        column: x => x.NewObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_OldObjectID",
                        column: x => x.OldObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AuditData_AuditEFCoreWeakReference_UserObjectID",
                        column: x => x.UserObjectID,
                        principalTable: "AuditEFCoreWeakReference",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "KpiInstance",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KpiDefinitionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForceMeasurementDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Settings = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpiInstance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KpiInstance_KpiDefinition_KpiDefinitionID",
                        column: x => x.KpiDefinitionID,
                        principalTable: "KpiDefinition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelDifferenceAspects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferenceAspects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModelDifferenceAspects_ModelDifferences_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "ModelDifferences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyActionPermissionObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActionId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyActionPermissionObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyActionPermissionObject_PermissionPolicyRoleBase_RoleID",
                        column: x => x.RoleID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyNavigationPermissionObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetTypeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyNavigationPermissionObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyNavigationPermissionObject_PermissionPolicyRoleBase_RoleID",
                        column: x => x.RoleID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyTypePermissionObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetTypeFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    CreateState = table.Column<int>(type: "int", nullable: true),
                    DeleteState = table.Column<int>(type: "int", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyTypePermissionObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyTypePermissionObject_PermissionPolicyRoleBase_RoleID",
                        column: x => x.RoleID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyRolePermissionPolicyUser",
                columns: table => new
                {
                    RolesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyRolePermissionPolicyUser", x => new { x.RolesID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_PermissionPolicyRolePermissionPolicyUser_PermissionPolicyRoleBase_RolesID",
                        column: x => x.RolesID,
                        principalTable: "PermissionPolicyRoleBase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyRolePermissionPolicyUser_PermissionPolicyUser_UsersID",
                        column: x => x.UsersID,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyUserLoginInfo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProviderName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderUserKey = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserForeignKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyUserLoginInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyUserLoginInfo_PermissionPolicyUser_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventResource",
                columns: table => new
                {
                    EventsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourcesKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventResource", x => new { x.EventsID, x.ResourcesKey });
                    table.ForeignKey(
                        name: "FK_EventResource_Event_EventsID",
                        column: x => x.EventsID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventResource_Resource_ResourcesKey",
                        column: x => x.ResourcesKey,
                        principalTable: "Resource",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KpiHistoryItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KpiInstanceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RangeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RangeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpiHistoryItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KpiHistoryItem_KpiInstance_KpiInstanceID",
                        column: x => x.KpiInstanceID,
                        principalTable: "KpiInstance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KpiInstanceKpiScorecard",
                columns: table => new
                {
                    IndicatorsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScorecardsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpiInstanceKpiScorecard", x => new { x.IndicatorsID, x.ScorecardsID });
                    table.ForeignKey(
                        name: "FK_KpiInstanceKpiScorecard_KpiInstance_IndicatorsID",
                        column: x => x.IndicatorsID,
                        principalTable: "KpiInstance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KpiInstanceKpiScorecard_KpiScorecard_ScorecardsID",
                        column: x => x.ScorecardsID,
                        principalTable: "KpiScorecard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyMemberPermissionsObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Members = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    TypePermissionObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyMemberPermissionsObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyMemberPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                        column: x => x.TypePermissionObjectID,
                        principalTable: "PermissionPolicyTypePermissionObject",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyObjectPermissionsObject",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    DeleteState = table.Column<int>(type: "int", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true),
                    TypePermissionObjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyObjectPermissionsObject", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyObjectPermissionsObject_PermissionPolicyTypePermissionObject_TypePermissionObjectID",
                        column: x => x.TypePermissionObjectID,
                        principalTable: "PermissionPolicyTypePermissionObject",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StateMachineAppearances",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetItems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppearanceItemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    FontStyle = table.Column<int>(type: "int", nullable: true),
                    FontColorInt = table.Column<int>(type: "int", nullable: false),
                    BackColorInt = table.Column<int>(type: "int", nullable: false),
                    Visibility = table.Column<int>(type: "int", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMachineAppearances", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateMachines",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    TargetObjectTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatePropertyNameBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartStateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExpandActionsInDetailView = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMachines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateMachineStates",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateMachineID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkerValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetObjectCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMachineStates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StateMachineStates_StateMachines_StateMachineID",
                        column: x => x.StateMachineID,
                        principalTable: "StateMachines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateMachineTransitions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceStateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TargetStateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    SaveAndCloseView = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMachineTransitions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StateMachineTransitions_StateMachineStates_SourceStateID",
                        column: x => x.SourceStateID,
                        principalTable: "StateMachineStates",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_StateMachineTransitions_StateMachineStates_TargetStateID",
                        column: x => x.TargetStateID,
                        principalTable: "StateMachineStates",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_AuditedObjectID",
                table: "AuditData",
                column: "AuditedObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_NewObjectID",
                table: "AuditData",
                column: "NewObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_OldObjectID",
                table: "AuditData",
                column: "OldObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditData_UserObjectID",
                table: "AuditData",
                column: "UserObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditEFCoreWeakReference_Key_TypeName",
                table: "AuditEFCoreWeakReference",
                columns: new[] { "Key", "TypeName" });

            migrationBuilder.CreateIndex(
                name: "IX_Event_RecurrencePatternID",
                table: "Event",
                column: "RecurrencePatternID");

            migrationBuilder.CreateIndex(
                name: "IX_EventResource_ResourcesKey",
                table: "EventResource",
                column: "ResourcesKey");

            migrationBuilder.CreateIndex(
                name: "IX_KpiHistoryItem_KpiInstanceID",
                table: "KpiHistoryItem",
                column: "KpiInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_KpiInstance_KpiDefinitionID",
                table: "KpiInstance",
                column: "KpiDefinitionID");

            migrationBuilder.CreateIndex(
                name: "IX_KpiInstanceKpiScorecard_ScorecardsID",
                table: "KpiInstanceKpiScorecard",
                column: "ScorecardsID");

            migrationBuilder.CreateIndex(
                name: "IX_ModelDifferenceAspects_OwnerID",
                table: "ModelDifferenceAspects",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyActionPermissionObject_RoleID",
                table: "PermissionPolicyActionPermissionObject",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyMemberPermissionsObject_TypePermissionObjectID",
                table: "PermissionPolicyMemberPermissionsObject",
                column: "TypePermissionObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyNavigationPermissionObject_RoleID",
                table: "PermissionPolicyNavigationPermissionObject",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyObjectPermissionsObject_TypePermissionObjectID",
                table: "PermissionPolicyObjectPermissionsObject",
                column: "TypePermissionObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyRolePermissionPolicyUser_UsersID",
                table: "PermissionPolicyRolePermissionPolicyUser",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyTypePermissionObject_RoleID",
                table: "PermissionPolicyTypePermissionObject",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyUserLoginInfo_LoginProviderName_ProviderUserKey",
                table: "PermissionPolicyUserLoginInfo",
                columns: new[] { "LoginProviderName", "ProviderUserKey" },
                unique: true,
                filter: "[LoginProviderName] IS NOT NULL AND [ProviderUserKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionPolicyUserLoginInfo_UserForeignKey",
                table: "PermissionPolicyUserLoginInfo",
                column: "UserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachineAppearances_StateID",
                table: "StateMachineAppearances",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachines_StartStateID",
                table: "StateMachines",
                column: "StartStateID");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachineStates_StateMachineID",
                table: "StateMachineStates",
                column: "StateMachineID");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachineTransitions_SourceStateID",
                table: "StateMachineTransitions",
                column: "SourceStateID");

            migrationBuilder.CreateIndex(
                name: "IX_StateMachineTransitions_TargetStateID",
                table: "StateMachineTransitions",
                column: "TargetStateID");

            migrationBuilder.AddForeignKey(
                name: "FK_StateMachineAppearances_StateMachineStates_StateID",
                table: "StateMachineAppearances",
                column: "StateID",
                principalTable: "StateMachineStates",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StateMachines_StateMachineStates_StartStateID",
                table: "StateMachines",
                column: "StartStateID",
                principalTable: "StateMachineStates",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateMachines_StateMachineStates_StartStateID",
                table: "StateMachines");

            migrationBuilder.DropTable(
                name: "Analysis");

            migrationBuilder.DropTable(
                name: "AuditData");

            migrationBuilder.DropTable(
                name: "DashboardData");

            migrationBuilder.DropTable(
                name: "EventResource");

            migrationBuilder.DropTable(
                name: "FileData");

            migrationBuilder.DropTable(
                name: "KpiHistoryItem");

            migrationBuilder.DropTable(
                name: "KpiInstanceKpiScorecard");

            migrationBuilder.DropTable(
                name: "ModelDifferenceAspects");

            migrationBuilder.DropTable(
                name: "PermissionPolicyActionPermissionObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyMemberPermissionsObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyNavigationPermissionObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyObjectPermissionsObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyRolePermissionPolicyUser");

            migrationBuilder.DropTable(
                name: "PermissionPolicyUserLoginInfo");

            migrationBuilder.DropTable(
                name: "ReportDataV2");

            migrationBuilder.DropTable(
                name: "StateMachineAppearances");

            migrationBuilder.DropTable(
                name: "StateMachineTransitions");

            migrationBuilder.DropTable(
                name: "AuditEFCoreWeakReference");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "KpiInstance");

            migrationBuilder.DropTable(
                name: "KpiScorecard");

            migrationBuilder.DropTable(
                name: "ModelDifferences");

            migrationBuilder.DropTable(
                name: "PermissionPolicyTypePermissionObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyUser");

            migrationBuilder.DropTable(
                name: "KpiDefinition");

            migrationBuilder.DropTable(
                name: "PermissionPolicyRoleBase");

            migrationBuilder.DropTable(
                name: "StateMachineStates");

            migrationBuilder.DropTable(
                name: "StateMachines");
        }
    }
}
