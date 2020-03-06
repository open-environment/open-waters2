using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OpenWater2.Models;
using OpenWater2.Models.Model;

namespace OpenWater2.DataAccess.Data
{
    public partial class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<TAttainsAssess> TAttainsAssess { get; set; }
        public virtual DbSet<TAttainsAssessCause> TAttainsAssessCause { get; set; }
        public virtual DbSet<TAttainsAssessUnits> TAttainsAssessUnits { get; set; }
        public virtual DbSet<TAttainsAssessUnitsMloc> TAttainsAssessUnitsMloc { get; set; }
        public virtual DbSet<TAttainsAssessUse> TAttainsAssessUse { get; set; }
        public virtual DbSet<TAttainsAssessUsePar> TAttainsAssessUsePar { get; set; }
        public virtual DbSet<TAttainsRefWaterType> TAttainsRefWaterType { get; set; }
        public virtual DbSet<TAttainsReport> TAttainsReport { get; set; }
        public virtual DbSet<TAttainsReportLog> TAttainsReportLog { get; set; }
        public virtual DbSet<TEpaOrgs> TEpaOrgs { get; set; }
        public virtual DbSet<TOeAppSettings> TOeAppSettings { get; set; }
        public virtual DbSet<TOeAppTasks> TOeAppTasks { get; set; }
        public virtual DbSet<TOeRoles> TOeRoles { get; set; }
        public virtual DbSet<TOeSysLog> TOeSysLog { get; set; }
        public virtual DbSet<TOeUserRoles> TOeUserRoles { get; set; }
        public virtual DbSet<TOeUsers> TOeUsers { get; set; }
        public virtual DbSet<TWqxActivity> TWqxActivity { get; set; }
        public virtual DbSet<TWqxActivityMetric> TWqxActivityMetric { get; set; }
        public virtual DbSet<TWqxBioHabitatIndex> TWqxBioHabitatIndex { get; set; }
        public virtual DbSet<TWqxImportLog> TWqxImportLog { get; set; }
        public virtual DbSet<TWqxImportTempActivityMetric> TWqxImportTempActivityMetric { get; set; }
        public virtual DbSet<TWqxImportTempBioIndex> TWqxImportTempBioIndex { get; set; }
        public virtual DbSet<TWqxImportTempMonloc> TWqxImportTempMonloc { get; set; }
        public virtual DbSet<TWqxImportTempProject> TWqxImportTempProject { get; set; }
        public virtual DbSet<TWqxImportTempResult> TWqxImportTempResult { get; set; }
        public virtual DbSet<TWqxImportTempSample> TWqxImportTempSample { get; set; }
        public virtual DbSet<TWqxImportTemplate> TWqxImportTemplate { get; set; }
        public virtual DbSet<TWqxImportTemplateDtl> TWqxImportTemplateDtl { get; set; }
        public virtual DbSet<TWqxImportTranslate> TWqxImportTranslate { get; set; }
        public virtual DbSet<TWqxMonloc> TWqxMonloc { get; set; }
        public virtual DbSet<TWqxOrgAddress> TWqxOrgAddress { get; set; }
        public virtual DbSet<TWqxOrganization> TWqxOrganization { get; set; }
        public virtual DbSet<TWqxProject> TWqxProject { get; set; }
        public virtual DbSet<TWqxRefAnalMethod> TWqxRefAnalMethod { get; set; }
        public virtual DbSet<TWqxRefCharLimits> TWqxRefCharLimits { get; set; }
        public virtual DbSet<TWqxRefCharOrg> TWqxRefCharOrg { get; set; }
        public virtual DbSet<TWqxRefCharacteristic> TWqxRefCharacteristic { get; set; }
        public virtual DbSet<TWqxRefCounty> TWqxRefCounty { get; set; }
        public virtual DbSet<TWqxRefData> TWqxRefData { get; set; }
        public virtual DbSet<TWqxRefDefaultTimeZone> TWqxRefDefaultTimeZone { get; set; }
        public virtual DbSet<TWqxRefLab> TWqxRefLab { get; set; }
        public virtual DbSet<TWqxRefSampColMethod> TWqxRefSampColMethod { get; set; }
        public virtual DbSet<TWqxRefSampPrep> TWqxRefSampPrep { get; set; }
        public virtual DbSet<TWqxRefTaxaOrg> TWqxRefTaxaOrg { get; set; }
        public virtual DbSet<TWqxResult> TWqxResult { get; set; }
        public virtual DbSet<TWqxTransactionLog> TWqxTransactionLog { get; set; }
        public virtual DbSet<TWqxUserOrgs> TWqxUserOrgs { get; set; }
        public virtual DbSet<VWqxActivityLatest> VWqxActivityLatest { get; set; }
        public virtual DbSet<VWqxAllOrgs> VWqxAllOrgs { get; set; }
        public virtual DbSet<VWqxPendingRecords> VWqxPendingRecords { get; set; }
        public virtual DbSet<VWqxTransactionLog> VWqxTransactionLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-5ANGL4D;Database=OpenEnvironment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TAttainsAssess>(entity =>
            {
                entity.HasKey(e => e.AttainsAssessIdx)
                    .HasName("PK_ATTAINS_ASSESS");

                entity.ToTable("T_ATTAINS_ASSESS");

                entity.Property(e => e.AttainsAssessIdx).HasColumnName("ATTAINS_ASSESS_IDX");

                entity.Property(e => e.AgencyCode)
                    .HasColumnName("AGENCY_CODE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AttainsAssessUnitIdx).HasColumnName("ATTAINS_ASSESS_UNIT_IDX");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CycleLastAssessed)
                    .HasColumnName("CYCLE_LAST_ASSESSED")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CycleLastMonitored)
                    .HasColumnName("CYCLE_LAST_MONITORED")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ReportStatus)
                    .IsRequired()
                    .HasColumnName("REPORT_STATUS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReportingCycle)
                    .IsRequired()
                    .HasColumnName("REPORTING_CYCLE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TrophicStatusCode)
                    .HasColumnName("TROPHIC_STATUS_CODE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.AttainsAssessUnitIdxNavigation)
                    .WithMany(p => p.TAttainsAssess)
                    .HasForeignKey(d => d.AttainsAssessUnitIdx)
                    .HasConstraintName("FK__T_ATTAINS__ATTAI__09A971A2");
            });

            modelBuilder.Entity<TAttainsAssessCause>(entity =>
            {
                entity.HasKey(e => e.AttainsAssessCauseIdx)
                    .HasName("PK_ATTAINS_ASSESS_CAUSE");

                entity.ToTable("T_ATTAINS_ASSESS_CAUSE");

                entity.Property(e => e.AttainsAssessCauseIdx).HasColumnName("ATTAINS_ASSESS_CAUSE_IDX");

                entity.Property(e => e.AgencyCode)
                    .HasColumnName("AGENCY_CODE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AttainsAssessIdx).HasColumnName("ATTAINS_ASSESS_IDX");

                entity.Property(e => e.CauseComment)
                    .HasColumnName("CAUSE_COMMENT")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CauseName)
                    .HasColumnName("CAUSE_NAME")
                    .HasMaxLength(240)
                    .IsUnicode(false);

                entity.Property(e => e.ConsentDecreeCycle)
                    .HasColumnName("CONSENT_DECREE_CYCLE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CycleExpectedAttain)
                    .HasColumnName("CYCLE_EXPECTED_ATTAIN")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CycleFirstListed)
                    .HasColumnName("CYCLE_FIRST_LISTED")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CycleSchedTmdl)
                    .HasColumnName("CYCLE_SCHED_TMDL")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PollutantInd)
                    .HasColumnName("POLLUTANT_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TmdlCauseReportId)
                    .HasColumnName("TMDL_CAUSE_REPORT_ID")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TmdlPriorityName)
                    .HasColumnName("TMDL_PRIORITY_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.AttainsAssessIdxNavigation)
                    .WithMany(p => p.TAttainsAssessCause)
                    .HasForeignKey(d => d.AttainsAssessIdx)
                    .HasConstraintName("FK__T_ATTAINS__ATTAI__123EB7A3");
            });

            modelBuilder.Entity<TAttainsAssessUnits>(entity =>
            {
                entity.HasKey(e => e.AttainsAssessUnitIdx)
                    .HasName("PK_ATTAINS_ASSESS_UNIT");

                entity.ToTable("T_ATTAINS_ASSESS_UNITS");

                entity.Property(e => e.AttainsAssessUnitIdx).HasColumnName("ATTAINS_ASSESS_UNIT_IDX");

                entity.Property(e => e.ActInd)
                    .HasColumnName("ACT_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AgencyCode)
                    .HasColumnName("AGENCY_CODE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AssessUnitId)
                    .IsRequired()
                    .HasColumnName("ASSESS_UNIT_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssessUnitName)
                    .HasColumnName("ASSESS_UNIT_NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AttainsReportIdx).HasColumnName("ATTAINS_REPORT_IDX");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LocationDesc)
                    .HasColumnName("LOCATION_DESC")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .HasColumnName("STATE_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UseClassCode)
                    .HasColumnName("USE_CLASS_CODE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UseClassName)
                    .HasColumnName("USE_CLASS_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WaterSize)
                    .HasColumnName("WATER_SIZE")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.WaterTypeCode)
                    .HasColumnName("WATER_TYPE_CODE")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.WaterUnitCode)
                    .HasColumnName("WATER_UNIT_CODE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.AttainsReportIdxNavigation)
                    .WithMany(p => p.TAttainsAssessUnits)
                    .HasForeignKey(d => d.AttainsReportIdx)
                    .HasConstraintName("FK__T_ATTAINS__ATTAI__02084FDA");

                entity.HasOne(d => d.WaterTypeCodeNavigation)
                    .WithMany(p => p.TAttainsAssessUnits)
                    .HasForeignKey(d => d.WaterTypeCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__T_ATTAINS__WATER__02FC7413");
            });

            modelBuilder.Entity<TAttainsAssessUnitsMloc>(entity =>
            {
                entity.HasKey(e => new { e.AttainsAssessUnitIdx, e.MonlocIdx })
                    .HasName("PK_ATTAINS_ASSESS_UNIT_MLOC");

                entity.ToTable("T_ATTAINS_ASSESS_UNITS_MLOC");

                entity.Property(e => e.AttainsAssessUnitIdx).HasColumnName("ATTAINS_ASSESS_UNIT_IDX");

                entity.Property(e => e.MonlocIdx).HasColumnName("MONLOC_IDX");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.AttainsAssessUnitIdxNavigation)
                    .WithMany(p => p.TAttainsAssessUnitsMloc)
                    .HasForeignKey(d => d.AttainsAssessUnitIdx)
                    .HasConstraintName("FK__T_ATTAINS__ATTAI__05D8E0BE");

                entity.HasOne(d => d.MonlocIdxNavigation)
                    .WithMany(p => p.TAttainsAssessUnitsMloc)
                    .HasForeignKey(d => d.MonlocIdx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__T_ATTAINS__MONLO__06CD04F7");
            });

            modelBuilder.Entity<TAttainsAssessUse>(entity =>
            {
                entity.HasKey(e => e.AttainsAssessUseIdx)
                    .HasName("PK_ATTAINS_ASSESS_USE");

                entity.ToTable("T_ATTAINS_ASSESS_USE");

                entity.Property(e => e.AttainsAssessUseIdx).HasColumnName("ATTAINS_ASSESS_USE_IDX");

                entity.Property(e => e.AssessBasis)
                    .HasColumnName("ASSESS_BASIS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AssessConfidence)
                    .HasColumnName("ASSESS_CONFIDENCE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AssessDate)
                    .HasColumnName("ASSESS_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.AssessType)
                    .HasColumnName("ASSESS_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AssessorName)
                    .HasColumnName("ASSESSOR_NAME")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.AttainsAssessIdx).HasColumnName("ATTAINS_ASSESS_IDX");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IrCatCode)
                    .HasColumnName("IR_CAT_CODE")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IrCatDesc)
                    .HasColumnName("IR_CAT_DESC")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MonDateEnd)
                    .HasColumnName("MON_DATE_END")
                    .HasColumnType("datetime");

                entity.Property(e => e.MonDateStart)
                    .HasColumnName("MON_DATE_START")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThreatenedInd)
                    .HasColumnName("THREATENED_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TrendCode)
                    .HasColumnName("TREND_CODE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UseAttainmentCode)
                    .HasColumnName("USE_ATTAINMENT_CODE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UseName)
                    .HasColumnName("USE_NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.AttainsAssessIdxNavigation)
                    .WithMany(p => p.TAttainsAssessUse)
                    .HasForeignKey(d => d.AttainsAssessIdx)
                    .HasConstraintName("FK__T_ATTAINS__ATTAI__0C85DE4D");
            });

            modelBuilder.Entity<TAttainsAssessUsePar>(entity =>
            {
                entity.HasKey(e => e.AttainsAssessUseParIdx)
                    .HasName("PK_ATTAINS_ASSESS_USE_PAR");

                entity.ToTable("T_ATTAINS_ASSESS_USE_PAR");

                entity.Property(e => e.AttainsAssessUseParIdx).HasColumnName("ATTAINS_ASSESS_USE_PAR_IDX");

                entity.Property(e => e.AttainsAssessUseIdx).HasColumnName("ATTAINS_ASSESS_USE_IDX");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ParamAttainmentCode)
                    .HasColumnName("PARAM_ATTAINMENT_CODE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ParamComment)
                    .HasColumnName("PARAM_COMMENT")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ParamName)
                    .HasColumnName("PARAM_NAME")
                    .HasMaxLength(240)
                    .IsUnicode(false);

                entity.Property(e => e.TrendCode)
                    .HasColumnName("TREND_CODE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.AttainsAssessUseIdxNavigation)
                    .WithMany(p => p.TAttainsAssessUsePar)
                    .HasForeignKey(d => d.AttainsAssessUseIdx)
                    .HasConstraintName("FK__T_ATTAINS__ATTAI__0F624AF8");
            });

            modelBuilder.Entity<TAttainsRefWaterType>(entity =>
            {
                entity.HasKey(e => e.WaterTypeCode)
                    .HasName("PK_ATTAINS_REF_WATER_TYPE");

                entity.ToTable("T_ATTAINS_REF_WATER_TYPE");

                entity.Property(e => e.WaterTypeCode)
                    .HasColumnName("WATER_TYPE_CODE")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TAttainsReport>(entity =>
            {
                entity.HasKey(e => e.AttainsReportIdx)
                    .HasName("PK_ATTAINS_REPORT");

                entity.ToTable("T_ATTAINS_REPORT");

                entity.Property(e => e.AttainsReportIdx).HasColumnName("ATTAINS_REPORT_IDX");

                entity.Property(e => e.AttainsInd).HasColumnName("ATTAINS_IND");

                entity.Property(e => e.AttainsSubmitStatus)
                    .HasColumnName("ATTAINS_SUBMIT_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AttainsUpdateDt)
                    .HasColumnName("ATTAINS_UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DataFrom)
                    .HasColumnName("DATA_FROM")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataTo)
                    .HasColumnName("DATA_TO")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReportName)
                    .IsRequired()
                    .HasColumnName("REPORT_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TAttainsReport)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_ATTAINS__ORG_I__7D439ABD");
            });

            modelBuilder.Entity<TAttainsReportLog>(entity =>
            {
                entity.HasKey(e => e.AttainsLogIdx)
                    .HasName("PK_ATTAINS_REPORT_LOG");

                entity.ToTable("T_ATTAINS_REPORT_LOG");

                entity.Property(e => e.AttainsLogIdx).HasColumnName("ATTAINS_LOG_IDX");

                entity.Property(e => e.AttainsReportIdx).HasColumnName("ATTAINS_REPORT_IDX");

                entity.Property(e => e.CdxSubmitStatus)
                    .HasColumnName("CDX_SUBMIT_STATUS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CdxSubmitTransid)
                    .HasColumnName("CDX_SUBMIT_TRANSID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseFile).HasColumnName("RESPONSE_FILE");

                entity.Property(e => e.ResponseTxt)
                    .HasColumnName("RESPONSE_TXT")
                    .IsUnicode(false);

                entity.Property(e => e.SubmitDt)
                    .HasColumnName("SUBMIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubmitFile)
                    .HasColumnName("SUBMIT_FILE")
                    .IsUnicode(false);

                entity.HasOne(d => d.AttainsReportIdxNavigation)
                    .WithMany(p => p.TAttainsReportLog)
                    .HasForeignKey(d => d.AttainsReportIdx)
                    .HasConstraintName("FK__T_ATTAINS__ATTAI__151B244E");
            });

            modelBuilder.Entity<TEpaOrgs>(entity =>
            {
                entity.HasKey(e => e.OrgId)
                    .HasName("PK_EPA_ORGANIZATION");

                entity.ToTable("T_EPA_ORGS");

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrgFormalName)
                    .IsRequired()
                    .HasColumnName("ORG_FORMAL_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TOeAppSettings>(entity =>
            {
                entity.HasKey(e => e.SettingIdx);

                entity.ToTable("T_OE_APP_SETTINGS");

                entity.Property(e => e.SettingIdx).HasColumnName("SETTING_IDX");

                entity.Property(e => e.EncryptInd).HasColumnName("ENCRYPT_IND");

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SettingDesc)
                    .HasColumnName("SETTING_DESC")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SettingName)
                    .IsRequired()
                    .HasColumnName("SETTING_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SettingValue)
                    .HasColumnName("SETTING_VALUE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SettingValueSalt)
                    .HasColumnName("SETTING_VALUE_SALT")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TOeAppTasks>(entity =>
            {
                entity.HasKey(e => e.TaskIdx);

                entity.ToTable("T_OE_APP_TASKS");

                entity.Property(e => e.TaskIdx).HasColumnName("TASK_IDX");

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDesc)
                    .IsRequired()
                    .HasColumnName("TASK_DESC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TaskFreqMs).HasColumnName("TASK_FREQ_MS");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasColumnName("TASK_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TaskStatus)
                    .IsRequired()
                    .HasColumnName("TASK_STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TOeRoles>(entity =>
            {
                entity.HasKey(e => e.RoleIdx);

                entity.ToTable("T_OE_ROLES");

                entity.Property(e => e.RoleIdx).HasColumnName("ROLE_IDX");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RoleDesc)
                    .IsRequired()
                    .HasColumnName("ROLE_DESC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("ROLE_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TOeSysLog>(entity =>
            {
                entity.HasKey(e => e.SysLogId)
                    .HasName("PK_T_REF_SYS_LOG");

                entity.ToTable("T_OE_SYS_LOG");

                entity.Property(e => e.SysLogId).HasColumnName("SYS_LOG_ID");

                entity.Property(e => e.LogDt)
                    .HasColumnName("LOG_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.LogMsg)
                    .HasColumnName("LOG_MSG")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.LogType)
                    .HasColumnName("LOG_TYPE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LogUseridx).HasColumnName("LOG_USERIDX");
            });

            modelBuilder.Entity<TOeUserRoles>(entity =>
            {
                entity.HasKey(e => e.UserRoleIdx);

                entity.ToTable("T_OE_USER_ROLES");

                entity.HasIndex(e => new { e.UserIdx, e.RoleIdx })
                    .HasName("UK_T_OE_USER_ROLES")
                    .IsUnique();

                entity.Property(e => e.UserRoleIdx).HasColumnName("USER_ROLE_IDX");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RoleIdx).HasColumnName("ROLE_IDX");

                entity.Property(e => e.UserIdx).HasColumnName("USER_IDX");

                entity.HasOne(d => d.RoleIdxNavigation)
                    .WithMany(p => p.TOeUserRoles)
                    .HasForeignKey(d => d.RoleIdx)
                    .HasConstraintName("FK__T_OE_USER__ROLE___1B0907CE");

                entity.HasOne(d => d.UserIdxNavigation)
                    .WithMany(p => p.TOeUserRoles)
                    .HasForeignKey(d => d.UserIdx)
                    .HasConstraintName("FK__T_OE_USER__USER___1BFD2C07");
            });

            modelBuilder.Entity<TOeUsers>(entity =>
            {
                entity.HasKey(e => e.UserIdx);

                entity.ToTable("T_OE_USERS");

                entity.Property(e => e.UserIdx).HasColumnName("USER_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultOrgId)
                    .HasColumnName("DEFAULT_ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EffectiveDt)
                    .HasColumnName("EFFECTIVE_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FNAME")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.InitalPwdFlag).HasColumnName("INITAL_PWD_FLAG");

                entity.Property(e => e.LastloginDt)
                    .HasColumnName("LASTLOGIN_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LNAME")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDt)
                    .HasColumnName("MODIFY_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.ModifyUserid)
                    .HasColumnName("MODIFY_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneExt)
                    .HasColumnName("PHONE_EXT")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PwdHash)
                    .IsRequired()
                    .HasColumnName("PWD_HASH")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PwdSalt)
                    .IsRequired()
                    .HasColumnName("PWD_SALT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("USER_ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxActivity>(entity =>
            {
                entity.HasKey(e => e.ActivityIdx)
                    .HasName("PK_WQX_ACTIVITY");

                entity.ToTable("T_WQX_ACTIVITY");

                entity.Property(e => e.ActivityIdx).HasColumnName("ACTIVITY_IDX");

                entity.Property(e => e.ActComment)
                    .HasColumnName("ACT_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ActDepthheightMsr)
                    .HasColumnName("ACT_DEPTHHEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActDepthheightMsrUnit)
                    .HasColumnName("ACT_DEPTHHEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActEndDt)
                    .HasColumnName("ACT_END_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.ActMedia)
                    .IsRequired()
                    .HasColumnName("ACT_MEDIA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ActStartDt)
                    .HasColumnName("ACT_START_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActSubmedia)
                    .HasColumnName("ACT_SUBMEDIA")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ActTimeZone)
                    .HasColumnName("ACT_TIME_ZONE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ActType)
                    .IsRequired()
                    .HasColumnName("ACT_TYPE")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityId)
                    .IsRequired()
                    .HasColumnName("ACTIVITY_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BioAssemblageSampled)
                    .HasColumnName("BIO_ASSEMBLAGE_SAMPLED")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BioBoatSpeedMsr)
                    .HasColumnName("BIO_BOAT_SPEED_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioBoatSpeedMsrUnit)
                    .HasColumnName("BIO_BOAT_SPEED_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioCurrSpeedMsr)
                    .HasColumnName("BIO_CURR_SPEED_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioCurrSpeedMsrUnit)
                    .HasColumnName("BIO_CURR_SPEED_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioDurationMsr)
                    .HasColumnName("BIO_DURATION_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioDurationMsrUnit)
                    .HasColumnName("BIO_DURATION_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioMeshsizeMsrUnit)
                    .HasColumnName("BIO_MESHSIZE_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioNetAreaMsr)
                    .HasColumnName("BIO_NET_AREA_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioNetAreaMsrUnit)
                    .HasColumnName("BIO_NET_AREA_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioNetMeshsizeMsr)
                    .HasColumnName("BIO_NET_MESHSIZE_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioNetType)
                    .HasColumnName("BIO_NET_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BioPassCount).HasColumnName("BIO_PASS_COUNT");

                entity.Property(e => e.BioReachLenMsr)
                    .HasColumnName("BIO_REACH_LEN_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioReachLenMsrUnit)
                    .HasColumnName("BIO_REACH_LEN_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioReachWidMsr)
                    .HasColumnName("BIO_REACH_WID_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioReachWidMsrUnit)
                    .HasColumnName("BIO_REACH_WID_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioSampComponent)
                    .HasColumnName("BIO_SAMP_COMPONENT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BioSampComponentSeq).HasColumnName("BIO_SAMP_COMPONENT_SEQ");

                entity.Property(e => e.BioToxicityTestType)
                    .HasColumnName("BIO_TOXICITY_TEST_TYPE")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.BotDepthheightMsr)
                    .HasColumnName("BOT_DEPTHHEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BotDepthheightMsrUnit)
                    .HasColumnName("BOT_DEPTHHEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DepthRefPoint)
                    .HasColumnName("DEPTH_REF_POINT")
                    .HasMaxLength(125)
                    .IsUnicode(false);

                entity.Property(e => e.EntryType)
                    .HasColumnName("ENTRY_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocIdx).HasColumnName("MONLOC_IDX");

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectIdx).HasColumnName("PROJECT_IDX");

                entity.Property(e => e.RelativeDepthName)
                    .HasColumnName("RELATIVE_DEPTH_NAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollEquip)
                    .HasColumnName("SAMP_COLL_EQUIP")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollEquipComment)
                    .HasColumnName("SAMP_COLL_EQUIP_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollMethodIdx).HasColumnName("SAMP_COLL_METHOD_IDX");

                entity.Property(e => e.SampPrepChemPreserv)
                    .HasColumnName("SAMP_PREP_CHEM_PRESERV")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepContColor)
                    .HasColumnName("SAMP_PREP_CONT_COLOR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepContType)
                    .HasColumnName("SAMP_PREP_CONT_TYPE")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepIdx).HasColumnName("SAMP_PREP_IDX");

                entity.Property(e => e.SampPrepStorageDesc)
                    .HasColumnName("SAMP_PREP_STORAGE_DESC")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepThermPreserv)
                    .HasColumnName("SAMP_PREP_THERM_PRESERV")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TempSampleIdx).HasColumnName("TEMP_SAMPLE_IDX");

                entity.Property(e => e.TopDepthheightMsr)
                    .HasColumnName("TOP_DEPTHHEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.TopDepthheightMsrUnit)
                    .HasColumnName("TOP_DEPTHHEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.WqxInd).HasColumnName("WQX_IND");

                entity.Property(e => e.WqxSubmitStatus)
                    .HasColumnName("WQX_SUBMIT_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WqxUpdateDt)
                    .HasColumnName("WQX_UPDATE_DT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MonlocIdxNavigation)
                    .WithMany(p => p.TWqxActivity)
                    .HasForeignKey(d => d.MonlocIdx)
                    .HasConstraintName("FK__T_WQX_ACT__MONLO__4316F928");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxActivity)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__T_WQX_ACT__ORG_I__440B1D61");

                entity.HasOne(d => d.ProjectIdxNavigation)
                    .WithMany(p => p.TWqxActivity)
                    .HasForeignKey(d => d.ProjectIdx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__T_WQX_ACT__PROJE__4222D4EF");
            });

            modelBuilder.Entity<TWqxActivityMetric>(entity =>
            {
                entity.HasKey(e => e.ActivityMetricIdx)
                    .HasName("PK_WQX_ACTIVITYMETRIC");

                entity.ToTable("T_WQX_ACTIVITY_METRIC");

                entity.Property(e => e.ActivityMetricIdx).HasColumnName("ACTIVITY_METRIC_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.ActivityIdx).HasColumnName("ACTIVITY_IDX");

                entity.Property(e => e.BioHabitatIndexIdx).HasColumnName("BIO_HABITAT_INDEX_IDX");

                entity.Property(e => e.CitationCreator)
                    .HasColumnName("CITATION_CREATOR")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CitationDate)
                    .HasColumnName("CITATION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CitationId)
                    .HasColumnName("CITATION_ID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CitationPublisher)
                    .HasColumnName("CITATION_PUBLISHER")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CitationSubject)
                    .HasColumnName("CITATION_SUBJECT")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CitationTitle)
                    .HasColumnName("CITATION_TITLE")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MetricComment)
                    .HasColumnName("METRIC_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.MetricFormulaDesc)
                    .HasColumnName("METRIC_FORMULA_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricScale)
                    .HasColumnName("METRIC_SCALE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricScore)
                    .IsRequired()
                    .HasColumnName("METRIC_SCORE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MetricTypeId)
                    .IsRequired()
                    .HasColumnName("METRIC_TYPE_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MetricTypeIdContext)
                    .IsRequired()
                    .HasColumnName("METRIC_TYPE_ID_CONTEXT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricTypeName)
                    .HasColumnName("METRIC_TYPE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricValueMsr)
                    .HasColumnName("METRIC_VALUE_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MetricValueMsrUnit)
                    .HasColumnName("METRIC_VALUE_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.WqxInd).HasColumnName("WQX_IND");

                entity.Property(e => e.WqxSubmitStatus)
                    .HasColumnName("WQX_SUBMIT_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WqxUpdateDt)
                    .HasColumnName("WQX_UPDATE_DT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ActivityIdxNavigation)
                    .WithMany(p => p.TWqxActivityMetric)
                    .HasForeignKey(d => d.ActivityIdx)
                    .HasConstraintName("FK__T_WQX_ACT__ACTIV__4AB81AF0");

                entity.HasOne(d => d.BioHabitatIndexIdxNavigation)
                    .WithMany(p => p.TWqxActivityMetric)
                    .HasForeignKey(d => d.BioHabitatIndexIdx)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__T_WQX_ACT__BIO_H__4BAC3F29");
            });

            modelBuilder.Entity<TWqxBioHabitatIndex>(entity =>
            {
                entity.HasKey(e => e.BioHabitatIndexIdx);

                entity.ToTable("T_WQX_BIO_HABITAT_INDEX");

                entity.Property(e => e.BioHabitatIndexIdx).HasColumnName("BIO_HABITAT_INDEX_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IndexCalcDate)
                    .HasColumnName("INDEX_CALC_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IndexComment)
                    .HasColumnName("INDEX_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.IndexId)
                    .IsRequired()
                    .HasColumnName("INDEX_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.IndexQualCd)
                    .HasColumnName("INDEX_QUAL_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IndexScore)
                    .IsRequired()
                    .HasColumnName("INDEX_SCORE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IndexTypeId)
                    .IsRequired()
                    .HasColumnName("INDEX_TYPE_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.IndexTypeIdContext)
                    .IsRequired()
                    .HasColumnName("INDEX_TYPE_ID_CONTEXT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IndexTypeName)
                    .IsRequired()
                    .HasColumnName("INDEX_TYPE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IndexTypeScale)
                    .HasColumnName("INDEX_TYPE_SCALE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocIdx).HasColumnName("MONLOC_IDX");

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceCreator)
                    .HasColumnName("RESOURCE_CREATOR")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceDate)
                    .HasColumnName("RESOURCE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResourceId)
                    .HasColumnName("RESOURCE_ID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResourcePublisher)
                    .HasColumnName("RESOURCE_PUBLISHER")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceSubject)
                    .HasColumnName("RESOURCE_SUBJECT")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceTitle)
                    .HasColumnName("RESOURCE_TITLE")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.WqxInd).HasColumnName("WQX_IND");

                entity.Property(e => e.WqxSubmitStatus)
                    .HasColumnName("WQX_SUBMIT_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WqxUpdateDt)
                    .HasColumnName("WQX_UPDATE_DT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MonlocIdxNavigation)
                    .WithMany(p => p.TWqxBioHabitatIndex)
                    .HasForeignKey(d => d.MonlocIdx)
                    .HasConstraintName("FK__T_WQX_BIO__MONLO__46E78A0C");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxBioHabitatIndex)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__T_WQX_BIO__ORG_I__47DBAE45");
            });

            modelBuilder.Entity<TWqxImportLog>(entity =>
            {
                entity.HasKey(e => e.ImportId)
                    .HasName("PK_WQX_IMPORT_LOG");

                entity.ToTable("T_WQX_IMPORT_LOG");

                entity.Property(e => e.ImportId).HasColumnName("IMPORT_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("FILE_NAME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FileSize).HasColumnName("FILE_SIZE");

                entity.Property(e => e.ImportFile).HasColumnName("IMPORT_FILE");

                entity.Property(e => e.ImportProgress)
                    .HasColumnName("IMPORT_PROGRESS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ImportProgressMsg)
                    .HasColumnName("IMPORT_PROGRESS_MSG")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatus)
                    .HasColumnName("IMPORT_STATUS")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeCd)
                    .IsRequired()
                    .HasColumnName("TYPE_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxImportLog)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_WQX_IMP__ORG_I__5CD6CB2B");
            });

            modelBuilder.Entity<TWqxImportTempActivityMetric>(entity =>
            {
                entity.HasKey(e => e.TempActivityMetricIdx)
                    .HasName("PK_T_IMPORT_TEMP_ACTIVITY_METRIC");

                entity.ToTable("T_WQX_IMPORT_TEMP_ACTIVITY_METRIC");

                entity.Property(e => e.TempActivityMetricIdx).HasColumnName("TEMP_ACTIVITY_METRIC_IDX");

                entity.Property(e => e.ActivityId)
                    .HasColumnName("ACTIVITY_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityIdx).HasColumnName("ACTIVITY_IDX");

                entity.Property(e => e.ImportStatusCd)
                    .HasColumnName("IMPORT_STATUS_CD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatusDesc)
                    .HasColumnName("IMPORT_STATUS_DESC")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MetricComment)
                    .HasColumnName("METRIC_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.MetricFormulaDesc)
                    .HasColumnName("METRIC_FORMULA_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricScale)
                    .HasColumnName("METRIC_SCALE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricScore)
                    .IsRequired()
                    .HasColumnName("METRIC_SCORE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MetricTypeId)
                    .IsRequired()
                    .HasColumnName("METRIC_TYPE_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MetricTypeIdContext)
                    .IsRequired()
                    .HasColumnName("METRIC_TYPE_ID_CONTEXT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricTypeName)
                    .HasColumnName("METRIC_TYPE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetricValueMsr)
                    .HasColumnName("METRIC_VALUE_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MetricValueMsrUnit)
                    .HasColumnName("METRIC_VALUE_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TempBioHabitatIndexIdx).HasColumnName("TEMP_BIO_HABITAT_INDEX_IDX");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("USER_ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxImportTempBioIndex>(entity =>
            {
                entity.HasKey(e => e.TempBioHabitatIndexIdx)
                    .HasName("PK_T_IMPORT_TEMP_BIO_INDEX");

                entity.ToTable("T_WQX_IMPORT_TEMP_BIO_INDEX");

                entity.Property(e => e.TempBioHabitatIndexIdx).HasColumnName("TEMP_BIO_HABITAT_INDEX_IDX");

                entity.Property(e => e.ImportStatusCd)
                    .HasColumnName("IMPORT_STATUS_CD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatusDesc)
                    .HasColumnName("IMPORT_STATUS_DESC")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IndexCalcDate)
                    .HasColumnName("INDEX_CALC_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IndexComment)
                    .HasColumnName("INDEX_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.IndexId)
                    .HasColumnName("INDEX_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.IndexQualCd)
                    .HasColumnName("INDEX_QUAL_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IndexScore)
                    .IsRequired()
                    .HasColumnName("INDEX_SCORE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IndexTypeId)
                    .HasColumnName("INDEX_TYPE_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.IndexTypeIdContext)
                    .HasColumnName("INDEX_TYPE_ID_CONTEXT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IndexTypeName)
                    .IsRequired()
                    .HasColumnName("INDEX_TYPE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IndexTypeScale)
                    .HasColumnName("INDEX_TYPE_SCALE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocIdx).HasColumnName("MONLOC_IDX");

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("USER_ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxImportTempMonloc>(entity =>
            {
                entity.HasKey(e => e.TempMonlocIdx)
                    .HasName("PK_WQX_IMPORT_TEMP_MONLOC");

                entity.ToTable("T_WQX_IMPORT_TEMP_MONLOC");

                entity.Property(e => e.TempMonlocIdx).HasColumnName("TEMP_MONLOC_IDX");

                entity.Property(e => e.AquiferName)
                    .HasColumnName("AQUIFER_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("COUNTRY_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CountyCode)
                    .HasColumnName("COUNTY_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FormationType)
                    .HasColumnName("FORMATION_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HorizAccuracy)
                    .HasColumnName("HORIZ_ACCURACY")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HorizAccuracyUnit)
                    .HasColumnName("HORIZ_ACCURACY_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HorizCollMethod)
                    .HasColumnName("HORIZ_COLL_METHOD")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.HorizRefDatum)
                    .HasColumnName("HORIZ_REF_DATUM")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.HucEight)
                    .HasColumnName("HUC_EIGHT")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.HucTwelve)
                    .HasColumnName("HUC_TWELVE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatusCd)
                    .HasColumnName("IMPORT_STATUS_CD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatusDesc)
                    .HasColumnName("IMPORT_STATUS_DESC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LatitudeMsr)
                    .IsRequired()
                    .HasColumnName("LATITUDE_MSR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LongitudeMsr)
                    .IsRequired()
                    .HasColumnName("LONGITUDE_MSR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocDesc)
                    .HasColumnName("MONLOC_DESC")
                    .HasMaxLength(1999)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocId)
                    .HasColumnName("MONLOC_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocIdx).HasColumnName("MONLOC_IDX");

                entity.Property(e => e.MonlocName)
                    .HasColumnName("MONLOC_NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocType)
                    .HasColumnName("MONLOC_TYPE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SourceMapScale).HasColumnName("SOURCE_MAP_SCALE");

                entity.Property(e => e.StateCode)
                    .HasColumnName("STATE_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TribalLandInd)
                    .HasColumnName("TRIBAL_LAND_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TribalLandName)
                    .HasColumnName("TRIBAL_LAND_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("USER_ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VertCollMethod)
                    .HasColumnName("VERT_COLL_METHOD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VertMeasure)
                    .HasColumnName("VERT_MEASURE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.VertMeasureUnit)
                    .HasColumnName("VERT_MEASURE_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.VertRefDatum)
                    .HasColumnName("VERT_REF_DATUM")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WellType)
                    .HasColumnName("WELL_TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WellholeDepthMsr)
                    .HasColumnName("WELLHOLE_DEPTH_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.WellholeDepthMsrUnit)
                    .HasColumnName("WELLHOLE_DEPTH_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxImportTempProject>(entity =>
            {
                entity.HasKey(e => e.TempProjectIdx)
                    .HasName("PK_WQX_IMPORT_TEMP_PROJECT");

                entity.ToTable("T_WQX_IMPORT_TEMP_PROJECT");

                entity.Property(e => e.TempProjectIdx).HasColumnName("TEMP_PROJECT_IDX");

                entity.Property(e => e.ImportStatusCd)
                    .HasColumnName("IMPORT_STATUS_CD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatusDesc)
                    .HasColumnName("IMPORT_STATUS_DESC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectDesc)
                    .HasColumnName("PROJECT_DESC")
                    .HasMaxLength(1999)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .IsRequired()
                    .HasColumnName("PROJECT_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectIdx).HasColumnName("PROJECT_IDX");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("PROJECT_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.QappApprovalAgency)
                    .HasColumnName("QAPP_APPROVAL_AGENCY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QappApprovalInd).HasColumnName("QAPP_APPROVAL_IND");

                entity.Property(e => e.SampDesignTypeCd)
                    .HasColumnName("SAMP_DESIGN_TYPE_CD")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("USER_ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxImportTempResult>(entity =>
            {
                entity.HasKey(e => e.TempResultIdx)
                    .HasName("PK_WQX_IMPORT_TEMP_RESULT");

                entity.ToTable("T_WQX_IMPORT_TEMP_RESULT");

                entity.Property(e => e.TempResultIdx).HasColumnName("TEMP_RESULT_IDX");

                entity.Property(e => e.AnalyticMethodCtx)
                    .HasColumnName("ANALYTIC_METHOD_CTX")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.AnalyticMethodId)
                    .HasColumnName("ANALYTIC_METHOD_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AnalyticMethodIdx).HasColumnName("ANALYTIC_METHOD_IDX");

                entity.Property(e => e.AnalyticMethodName)
                    .HasColumnName("ANALYTIC_METHOD_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.BiasValue)
                    .HasColumnName("BIAS_VALUE")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BioIndividualId)
                    .HasColumnName("BIO_INDIVIDUAL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.BioIntentName)
                    .HasColumnName("BIO_INTENT_NAME")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BioSampleTissueAnatomy)
                    .HasColumnName("BIO_SAMPLE_TISSUE_ANATOMY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BioSubjectTaxonomy)
                    .HasColumnName("BIO_SUBJECT_TAXONOMY")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.BioUnidentifiedSpeciesId)
                    .HasColumnName("BIO_UNIDENTIFIED_SPECIES_ID")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CharName)
                    .HasColumnName("CHAR_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ConfidenceIntervalValue)
                    .HasColumnName("CONFIDENCE_INTERVAL_VALUE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DataLoggerLine)
                    .HasColumnName("DATA_LOGGER_LINE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DepthHeightMsr)
                    .HasColumnName("DEPTH_HEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DepthHeightMsrUnit)
                    .HasColumnName("DEPTH_HEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Depthaltituderefpoint)
                    .HasColumnName("DEPTHALTITUDEREFPOINT")
                    .HasMaxLength(125)
                    .IsUnicode(false);

                entity.Property(e => e.DetectionLimitUnit)
                    .HasColumnName("DETECTION_LIMIT_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DilutionFactor)
                    .HasColumnName("DILUTION_FACTOR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FreqClassCode)
                    .HasColumnName("FREQ_CLASS_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FreqClassLower)
                    .HasColumnName("FREQ_CLASS_LOWER")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FreqClassUnit)
                    .HasColumnName("FREQ_CLASS_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FreqClassUpper)
                    .HasColumnName("FREQ_CLASS_UPPER")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.GrpSummCountWeightMsr)
                    .HasColumnName("GRP_SUMM_COUNT_WEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.GrpSummCountWeightMsrUnit)
                    .HasColumnName("GRP_SUMM_COUNT_WEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatusCd)
                    .HasColumnName("IMPORT_STATUS_CD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatusDesc)
                    .HasColumnName("IMPORT_STATUS_DESC")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LabAnalysisEndDt)
                    .HasColumnName("LAB_ANALYSIS_END_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabAnalysisStartDt)
                    .HasColumnName("LAB_ANALYSIS_START_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabAnalysisTimezone)
                    .HasColumnName("LAB_ANALYSIS_TIMEZONE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LabIdx).HasColumnName("LAB_IDX");

                entity.Property(e => e.LabName)
                    .HasColumnName("LAB_NAME")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.LabReportingLevel)
                    .HasColumnName("LAB_REPORTING_LEVEL")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.LabSampPrepCtx)
                    .HasColumnName("LAB_SAMP_PREP_CTX")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.LabSampPrepEndDt)
                    .HasColumnName("LAB_SAMP_PREP_END_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabSampPrepId)
                    .HasColumnName("LAB_SAMP_PREP_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LabSampPrepIdx).HasColumnName("LAB_SAMP_PREP_IDX");

                entity.Property(e => e.LabSampPrepStartDt)
                    .HasColumnName("LAB_SAMP_PREP_START_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LowerConfidenceLimit)
                    .HasColumnName("LOWER_CONFIDENCE_LIMIT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LowerQuantLimit)
                    .HasColumnName("LOWER_QUANT_LIMIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MethodDetectionLevel)
                    .HasColumnName("METHOD_DETECTION_LEVEL")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MethodSpeciationName)
                    .HasColumnName("METHOD_SPECIATION_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ParticlesizeBasis)
                    .HasColumnName("PARTICLESIZE_BASIS")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Pql)
                    .HasColumnName("PQL")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PrecisionValue)
                    .HasColumnName("PRECISION_VALUE")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ResultComment)
                    .HasColumnName("RESULT_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ResultDetectCondition)
                    .HasColumnName("RESULT_DETECT_CONDITION")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ResultIdx).HasColumnName("RESULT_IDX");

                entity.Property(e => e.ResultLabCommentCode)
                    .HasColumnName("RESULT_LAB_COMMENT_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ResultMsr)
                    .HasColumnName("RESULT_MSR")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ResultMsrQual)
                    .HasColumnName("RESULT_MSR_QUAL")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ResultMsrUnit)
                    .HasColumnName("RESULT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ResultSampFraction)
                    .HasColumnName("RESULT_SAMP_FRACTION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ResultStatus)
                    .HasColumnName("RESULT_STATUS")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ResultValueType)
                    .HasColumnName("RESULT_VALUE_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatisticBaseCode)
                    .HasColumnName("STATISTIC_BASE_CODE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlCellForm)
                    .HasColumnName("TAX_DTL_CELL_FORM")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlCellShape)
                    .HasColumnName("TAX_DTL_CELL_SHAPE")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlFuncFeedingGroup1)
                    .HasColumnName("TAX_DTL_FUNC_FEEDING_GROUP1")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlFuncFeedingGroup2)
                    .HasColumnName("TAX_DTL_FUNC_FEEDING_GROUP2")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlFuncFeedingGroup3)
                    .HasColumnName("TAX_DTL_FUNC_FEEDING_GROUP3")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlHabit)
                    .HasColumnName("TAX_DTL_HABIT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlPollTolerance)
                    .HasColumnName("TAX_DTL_POLL_TOLERANCE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlPollToleranceScale)
                    .HasColumnName("TAX_DTL_POLL_TOLERANCE_SCALE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlTrophicLevel)
                    .HasColumnName("TAX_DTL_TROPHIC_LEVEL")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlVoltinism)
                    .HasColumnName("TAX_DTL_VOLTINISM")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TempBasis)
                    .HasColumnName("TEMP_BASIS")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.TempSampleIdx).HasColumnName("TEMP_SAMPLE_IDX");

                entity.Property(e => e.TimeBasis)
                    .HasColumnName("TIME_BASIS")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UpperConfidenceLimit)
                    .HasColumnName("UPPER_CONFIDENCE_LIMIT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpperQuantLimit)
                    .HasColumnName("UPPER_QUANT_LIMIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.WeightBasis)
                    .HasColumnName("WEIGHT_BASIS")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.TempSampleIdxNavigation)
                    .WithMany(p => p.TWqxImportTempResult)
                    .HasForeignKey(d => d.TempSampleIdx)
                    .HasConstraintName("FK__T_WQX_IMP__TEMP___6754599E");
            });

            modelBuilder.Entity<TWqxImportTempSample>(entity =>
            {
                entity.HasKey(e => e.TempSampleIdx)
                    .HasName("PK_WQX_IMPORT_TEMP_SAMPLE");

                entity.ToTable("T_WQX_IMPORT_TEMP_SAMPLE");

                entity.Property(e => e.TempSampleIdx).HasColumnName("TEMP_SAMPLE_IDX");

                entity.Property(e => e.ActComment)
                    .HasColumnName("ACT_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ActDepthheightMsr)
                    .HasColumnName("ACT_DEPTHHEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActDepthheightMsrUnit)
                    .HasColumnName("ACT_DEPTHHEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActEndDt)
                    .HasColumnName("ACT_END_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActMedia)
                    .IsRequired()
                    .HasColumnName("ACT_MEDIA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ActStartDt)
                    .HasColumnName("ACT_START_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActSubmedia)
                    .HasColumnName("ACT_SUBMEDIA")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ActTimeZone)
                    .HasColumnName("ACT_TIME_ZONE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ActType)
                    .IsRequired()
                    .HasColumnName("ACT_TYPE")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityId)
                    .HasColumnName("ACTIVITY_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityIdx).HasColumnName("ACTIVITY_IDX");

                entity.Property(e => e.BioAssemblageSampled)
                    .HasColumnName("BIO_ASSEMBLAGE_SAMPLED")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BioBoatSpeedMsr)
                    .HasColumnName("BIO_BOAT_SPEED_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioBoatSpeedMsrUnit)
                    .HasColumnName("BIO_BOAT_SPEED_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioCurrSpeedMsr)
                    .HasColumnName("BIO_CURR_SPEED_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioCurrSpeedMsrUnit)
                    .HasColumnName("BIO_CURR_SPEED_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioDurationMsr)
                    .HasColumnName("BIO_DURATION_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioDurationMsrUnit)
                    .HasColumnName("BIO_DURATION_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioMeshsizeMsrUnit)
                    .HasColumnName("BIO_MESHSIZE_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioNetAreaMsr)
                    .HasColumnName("BIO_NET_AREA_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioNetAreaMsrUnit)
                    .HasColumnName("BIO_NET_AREA_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioNetMeshsizeMsr)
                    .HasColumnName("BIO_NET_MESHSIZE_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioNetType)
                    .HasColumnName("BIO_NET_TYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BioPassCount).HasColumnName("BIO_PASS_COUNT");

                entity.Property(e => e.BioReachLenMsr)
                    .HasColumnName("BIO_REACH_LEN_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioReachLenMsrUnit)
                    .HasColumnName("BIO_REACH_LEN_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioReachWidMsr)
                    .HasColumnName("BIO_REACH_WID_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioReachWidMsrUnit)
                    .HasColumnName("BIO_REACH_WID_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BioSampComponent)
                    .HasColumnName("BIO_SAMP_COMPONENT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BioSampComponentSeq).HasColumnName("BIO_SAMP_COMPONENT_SEQ");

                entity.Property(e => e.BioToxicityTestType)
                    .HasColumnName("BIO_TOXICITY_TEST_TYPE")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.BotDepthheightMsr)
                    .HasColumnName("BOT_DEPTHHEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BotDepthheightMsrUnit)
                    .HasColumnName("BOT_DEPTHHEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DepthRefPoint)
                    .HasColumnName("DEPTH_REF_POINT")
                    .HasMaxLength(125)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatusCd)
                    .HasColumnName("IMPORT_STATUS_CD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatusDesc)
                    .HasColumnName("IMPORT_STATUS_DESC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocId)
                    .HasColumnName("MONLOC_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocIdx).HasColumnName("MONLOC_IDX");

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("PROJECT_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectIdx).HasColumnName("PROJECT_IDX");

                entity.Property(e => e.RelativeDepthName)
                    .HasColumnName("RELATIVE_DEPTH_NAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollEquip)
                    .HasColumnName("SAMP_COLL_EQUIP")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollEquipComment)
                    .HasColumnName("SAMP_COLL_EQUIP_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollMethodCtx)
                    .HasColumnName("SAMP_COLL_METHOD_CTX")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollMethodId)
                    .HasColumnName("SAMP_COLL_METHOD_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollMethodIdx).HasColumnName("SAMP_COLL_METHOD_IDX");

                entity.Property(e => e.SampCollMethodName)
                    .HasColumnName("SAMP_COLL_METHOD_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepChemPreserv)
                    .HasColumnName("SAMP_PREP_CHEM_PRESERV")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepContColor)
                    .HasColumnName("SAMP_PREP_CONT_COLOR")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepContType)
                    .HasColumnName("SAMP_PREP_CONT_TYPE")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepCtx)
                    .HasColumnName("SAMP_PREP_CTX")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepId)
                    .HasColumnName("SAMP_PREP_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepIdx).HasColumnName("SAMP_PREP_IDX");

                entity.Property(e => e.SampPrepName)
                    .HasColumnName("SAMP_PREP_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepStorageDesc)
                    .HasColumnName("SAMP_PREP_STORAGE_DESC")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepThermPreserv)
                    .HasColumnName("SAMP_PREP_THERM_PRESERV")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TopDepthheightMsr)
                    .HasColumnName("TOP_DEPTHHEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.TopDepthheightMsrUnit)
                    .HasColumnName("TOP_DEPTHHEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("USER_ID")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxImportTemplate>(entity =>
            {
                entity.HasKey(e => e.TemplateId)
                    .HasName("PK_WQX_IMPORT_TEMPLATE");

                entity.ToTable("T_WQX_IMPORT_TEMPLATE");

                entity.Property(e => e.TemplateId).HasColumnName("TEMPLATE_ID");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasColumnName("TEMPLATE_NAME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TypeCd)
                    .IsRequired()
                    .HasColumnName("TYPE_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxImportTemplate)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_WQX_IMP__ORG_I__5FB337D6");
            });

            modelBuilder.Entity<TWqxImportTemplateDtl>(entity =>
            {
                entity.HasKey(e => e.TemplateDtlId)
                    .HasName("PK_WQX_IMPORT_TEMPLATE_DTL");

                entity.ToTable("T_WQX_IMPORT_TEMPLATE_DTL");

                entity.Property(e => e.TemplateDtlId).HasColumnName("TEMPLATE_DTL_ID");

                entity.Property(e => e.CharDefaultSampFraction)
                    .HasColumnName("CHAR_DEFAULT_SAMP_FRACTION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CharDefaultUnit)
                    .HasColumnName("CHAR_DEFAULT_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CharName)
                    .HasColumnName("CHAR_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ColNum).HasColumnName("COL_NUM");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FieldMap)
                    .HasColumnName("FIELD_MAP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateId).HasColumnName("TEMPLATE_ID");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TWqxImportTemplateDtl)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("FK__T_WQX_IMP__TEMPL__628FA481");
            });

            modelBuilder.Entity<TWqxImportTranslate>(entity =>
            {
                entity.HasKey(e => e.TranslateIdx)
                    .HasName("PK_WQX_IMPORT_TRANSLATE");

                entity.ToTable("T_WQX_IMPORT_TRANSLATE");

                entity.Property(e => e.TranslateIdx).HasColumnName("TRANSLATE_IDX");

                entity.Property(e => e.ColName)
                    .IsRequired()
                    .HasColumnName("COL_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DataFrom)
                    .IsRequired()
                    .HasColumnName("DATA_FROM")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DataTo)
                    .HasColumnName("DATA_TO")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxImportTranslate)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_WQX_IMP__ORG_I__71D1E811");
            });

            modelBuilder.Entity<TWqxMonloc>(entity =>
            {
                entity.HasKey(e => e.MonlocIdx)
                    .HasName("PK_WQX_MONLOC");

                entity.ToTable("T_WQX_MONLOC");

                entity.Property(e => e.MonlocIdx).HasColumnName("MONLOC_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.AquiferName)
                    .HasColumnName("AQUIFER_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("COUNTRY_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CountyCode)
                    .HasColumnName("COUNTY_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FormationType)
                    .HasColumnName("FORMATION_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HorizAccuracy)
                    .HasColumnName("HORIZ_ACCURACY")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HorizAccuracyUnit)
                    .HasColumnName("HORIZ_ACCURACY_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.HorizCollMethod)
                    .HasColumnName("HORIZ_COLL_METHOD")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.HorizRefDatum)
                    .HasColumnName("HORIZ_REF_DATUM")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.HucEight)
                    .HasColumnName("HUC_EIGHT")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.HucTwelve)
                    .HasColumnName("HUC_TWELVE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ImportMonlocId)
                    .HasColumnName("IMPORT_MONLOC_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.LatitudeMsr)
                    .IsRequired()
                    .HasColumnName("LATITUDE_MSR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LongitudeMsr)
                    .IsRequired()
                    .HasColumnName("LONGITUDE_MSR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocDesc)
                    .HasColumnName("MONLOC_DESC")
                    .HasMaxLength(1999)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocId)
                    .IsRequired()
                    .HasColumnName("MONLOC_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocName)
                    .IsRequired()
                    .HasColumnName("MONLOC_NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocType)
                    .IsRequired()
                    .HasColumnName("MONLOC_TYPE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SourceMapScale).HasColumnName("SOURCE_MAP_SCALE");

                entity.Property(e => e.StateCode)
                    .HasColumnName("STATE_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TribalLandInd)
                    .HasColumnName("TRIBAL_LAND_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TribalLandName)
                    .HasColumnName("TRIBAL_LAND_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VertCollMethod)
                    .HasColumnName("VERT_COLL_METHOD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VertMeasure)
                    .HasColumnName("VERT_MEASURE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.VertMeasureUnit)
                    .HasColumnName("VERT_MEASURE_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.VertRefDatum)
                    .HasColumnName("VERT_REF_DATUM")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WellType)
                    .HasColumnName("WELL_TYPE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WellholeDepthMsr)
                    .HasColumnName("WELLHOLE_DEPTH_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.WellholeDepthMsrUnit)
                    .HasColumnName("WELLHOLE_DEPTH_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.WqxInd).HasColumnName("WQX_IND");

                entity.Property(e => e.WqxSubmitStatus)
                    .HasColumnName("WQX_SUBMIT_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WqxUpdateDt)
                    .HasColumnName("WQX_UPDATE_DT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxMonloc)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_WQX_MON__ORG_I__3F466844");
            });

            modelBuilder.Entity<TWqxOrgAddress>(entity =>
            {
                entity.HasKey(e => new { e.OrgId, e.AddressType })
                    .HasName("PK_WQX_ORG_ADDRESS");

                entity.ToTable("T_WQX_ORG_ADDRESS");

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AddressType)
                    .HasColumnName("ADDRESS_TYPE")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCd)
                    .HasColumnName("COUNTRY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CountyCd)
                    .HasColumnName("COUNTY_CD")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Locality)
                    .HasColumnName("LOCALITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCd)
                    .HasColumnName("POSTAL_CD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StateCd)
                    .HasColumnName("STATE_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SuppAddress)
                    .HasColumnName("SUPP_ADDRESS")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxOrgAddress)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_WQX_ORG__ORG_I__35BCFE0A");
            });

            modelBuilder.Entity<TWqxOrganization>(entity =>
            {
                entity.HasKey(e => e.OrgId)
                    .HasName("PK_WQX_ORGANIZATION");

                entity.ToTable("T_WQX_ORGANIZATION");

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CdxSubmitInd)
                    .HasColumnName("CDX_SUBMIT_IND")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CdxSubmitterId)
                    .HasColumnName("CDX_SUBMITTER_ID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CdxSubmitterPwdHash)
                    .HasColumnName("CDX_SUBMITTER_PWD_HASH")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CdxSubmitterPwdSalt)
                    .HasColumnName("CDX_SUBMITTER_PWD_SALT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultTimezone)
                    .HasColumnName("DEFAULT_TIMEZONE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Electronicaddress)
                    .IsRequired()
                    .HasColumnName("ELECTRONICADDRESS")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Electronicaddresstype)
                    .HasColumnName("ELECTRONICADDRESSTYPE")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddCity)
                    .HasColumnName("MAILING_ADD_CITY")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddState)
                    .HasColumnName("MAILING_ADD_STATE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddZip)
                    .HasColumnName("MAILING_ADD_ZIP")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddress)
                    .HasColumnName("MAILING_ADDRESS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddress2)
                    .HasColumnName("MAILING_ADDRESS2")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrgDesc)
                    .HasColumnName("ORG_DESC")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OrgFormalName)
                    .IsRequired()
                    .HasColumnName("ORG_FORMAL_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneExt)
                    .HasColumnName("TELEPHONE_EXT")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNum)
                    .IsRequired()
                    .HasColumnName("TELEPHONE_NUM")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumType)
                    .HasColumnName("TELEPHONE_NUM_TYPE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TribalCode)
                    .HasColumnName("TRIBAL_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxProject>(entity =>
            {
                entity.HasKey(e => e.ProjectIdx)
                    .HasName("PK_WQX_PROJECT");

                entity.ToTable("T_WQX_PROJECT");

                entity.Property(e => e.ProjectIdx).HasColumnName("PROJECT_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectDesc)
                    .HasColumnName("PROJECT_DESC")
                    .HasMaxLength(1999)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .IsRequired()
                    .HasColumnName("PROJECT_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("PROJECT_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.QappApprovalAgency)
                    .HasColumnName("QAPP_APPROVAL_AGENCY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QappApprovalInd).HasColumnName("QAPP_APPROVAL_IND");

                entity.Property(e => e.SampDesignTypeCd)
                    .HasColumnName("SAMP_DESIGN_TYPE_CD")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.WqxInd).HasColumnName("WQX_IND");

                entity.Property(e => e.WqxSubmitStatus)
                    .HasColumnName("WQX_SUBMIT_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.WqxUpdateDt)
                    .HasColumnName("WQX_UPDATE_DT")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxProject)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_WQX_PRO__ORG_I__3C69FB99");
            });

            modelBuilder.Entity<TWqxRefAnalMethod>(entity =>
            {
                entity.HasKey(e => e.AnalyticMethodIdx)
                    .HasName("PK_WQX_REF_ANAL_METHOD");

                entity.ToTable("T_WQX_REF_ANAL_METHOD");

                entity.Property(e => e.AnalyticMethodIdx).HasColumnName("ANALYTIC_METHOD_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.AnalyticMethodCtx)
                    .IsRequired()
                    .HasColumnName("ANALYTIC_METHOD_CTX")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.AnalyticMethodDesc)
                    .HasColumnName("ANALYTIC_METHOD_DESC")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.AnalyticMethodId)
                    .IsRequired()
                    .HasColumnName("ANALYTIC_METHOD_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AnalyticMethodName)
                    .HasColumnName("ANALYTIC_METHOD_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TWqxRefCharLimits>(entity =>
            {
                entity.HasKey(e => new { e.CharName, e.UnitName });

                entity.ToTable("T_WQX_REF_CHAR_LIMITS");

                entity.Property(e => e.CharName)
                    .HasColumnName("CHAR_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.UnitName)
                    .HasColumnName("UNIT_NAME")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LowerBound)
                    .HasColumnName("LOWER_BOUND")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UpperBound)
                    .HasColumnName("UPPER_BOUND")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.CharNameNavigation)
                    .WithMany(p => p.TWqxRefCharLimits)
                    .HasForeignKey(d => d.CharName)
                    .HasConstraintName("FK__T_WQX_REF__CHAR___2E1BDC42");
            });

            modelBuilder.Entity<TWqxRefCharOrg>(entity =>
            {
                entity.HasKey(e => new { e.OrgId, e.CharName });

                entity.ToTable("T_WQX_REF_CHAR_ORG");

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CharName)
                    .HasColumnName("CHAR_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultAnalMethodIdx).HasColumnName("DEFAULT_ANAL_METHOD_IDX");

                entity.Property(e => e.DefaultDetectLimit)
                    .HasColumnName("DEFAULT_DETECT_LIMIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultLowerQuantLimit)
                    .HasColumnName("DEFAULT_LOWER_QUANT_LIMIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultResultStatus)
                    .HasColumnName("DEFAULT_RESULT_STATUS")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultResultValueType)
                    .HasColumnName("DEFAULT_RESULT_VALUE_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultSampFraction)
                    .HasColumnName("DEFAULT_SAMP_FRACTION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultUnit)
                    .HasColumnName("DEFAULT_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultUpperQuantLimit)
                    .HasColumnName("DEFAULT_UPPER_QUANT_LIMIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.CharNameNavigation)
                    .WithMany(p => p.TWqxRefCharOrg)
                    .HasForeignKey(d => d.CharName)
                    .HasConstraintName("FK__T_WQX_REF__CHAR___5441852A");

                entity.HasOne(d => d.DefaultAnalMethodIdxNavigation)
                    .WithMany(p => p.TWqxRefCharOrg)
                    .HasForeignKey(d => d.DefaultAnalMethodIdx)
                    .HasConstraintName("FK_T_WQX_REF_CHAR_ORG");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxRefCharOrg)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_WQX_REF__ORG_I__534D60F1");
            });

            modelBuilder.Entity<TWqxRefCharacteristic>(entity =>
            {
                entity.HasKey(e => e.CharName);

                entity.ToTable("T_WQX_REF_CHARACTERISTIC");

                entity.Property(e => e.CharName)
                    .HasColumnName("CHAR_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.DefaultDetectLimit)
                    .HasColumnName("DEFAULT_DETECT_LIMIT")
                    .HasColumnType("decimal(12, 5)");

                entity.Property(e => e.DefaultUnit)
                    .HasColumnName("DEFAULT_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PickList)
                    .HasColumnName("PICK_LIST")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SampFracReq)
                    .HasColumnName("SAMP_FRAC_REQ")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsedInd).HasColumnName("USED_IND");
            });

            modelBuilder.Entity<TWqxRefCounty>(entity =>
            {
                entity.HasKey(e => new { e.StateCode, e.CountyCode })
                    .HasName("PK_WQX_REF_COUNTY");

                entity.ToTable("T_WQX_REF_COUNTY");

                entity.Property(e => e.StateCode)
                    .HasColumnName("STATE_CODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CountyCode)
                    .HasColumnName("COUNTY_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.CountyName)
                    .IsRequired()
                    .HasColumnName("COUNTY_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsedInd).HasColumnName("USED_IND");
            });

            modelBuilder.Entity<TWqxRefData>(entity =>
            {
                entity.HasKey(e => e.RefDataIdx)
                    .HasName("PK_WQX_REF_DATA");

                entity.ToTable("T_WQX_REF_DATA");

                entity.Property(e => e.RefDataIdx).HasColumnName("REF_DATA_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.Table)
                    .IsRequired()
                    .HasColumnName("TABLE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("TEXT")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsedInd).HasColumnName("USED_IND");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("VALUE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxRefDefaultTimeZone>(entity =>
            {
                entity.HasKey(e => e.TimeZoneName)
                    .HasName("PK_WQX_REF_DEFAULT_TIME_ZONE");

                entity.ToTable("T_WQX_REF_DEFAULT_TIME_ZONE");

                entity.Property(e => e.TimeZoneName)
                    .HasColumnName("TIME_ZONE_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.OfficialTimeZoneName)
                    .HasColumnName("OFFICIAL_TIME_ZONE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.WqxCodeDaylight)
                    .HasColumnName("WQX_CODE_DAYLIGHT")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.WqxCodeStandard)
                    .IsRequired()
                    .HasColumnName("WQX_CODE_STANDARD")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxRefLab>(entity =>
            {
                entity.HasKey(e => e.LabIdx)
                    .HasName("PK_WQX_REF_LAB");

                entity.ToTable("T_WQX_REF_LAB");

                entity.Property(e => e.LabIdx).HasColumnName("LAB_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LabAccredAuthority)
                    .HasColumnName("LAB_ACCRED_AUTHORITY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LabAccredInd)
                    .HasColumnName("LAB_ACCRED_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LabName)
                    .IsRequired()
                    .HasColumnName("LAB_NAME")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TWqxRefSampColMethod>(entity =>
            {
                entity.HasKey(e => e.SampCollMethodIdx)
                    .HasName("PK_WQX_REF_SAMP_COL_METHOD");

                entity.ToTable("T_WQX_REF_SAMP_COL_METHOD");

                entity.Property(e => e.SampCollMethodIdx).HasColumnName("SAMP_COLL_METHOD_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.SampCollMethodCtx)
                    .IsRequired()
                    .HasColumnName("SAMP_COLL_METHOD_CTX")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollMethodDesc)
                    .HasColumnName("SAMP_COLL_METHOD_DESC")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollMethodId)
                    .IsRequired()
                    .HasColumnName("SAMP_COLL_METHOD_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SampCollMethodName)
                    .HasColumnName("SAMP_COLL_METHOD_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TWqxRefSampPrep>(entity =>
            {
                entity.HasKey(e => e.SampPrepIdx)
                    .HasName("PK_WQX_REF_SAMP_PREP");

                entity.ToTable("T_WQX_REF_SAMP_PREP");

                entity.Property(e => e.SampPrepIdx).HasColumnName("SAMP_PREP_IDX");

                entity.Property(e => e.ActInd).HasColumnName("ACT_IND");

                entity.Property(e => e.SampPrepMethodCtx)
                    .IsRequired()
                    .HasColumnName("SAMP_PREP_METHOD_CTX")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepMethodDesc)
                    .HasColumnName("SAMP_PREP_METHOD_DESC")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepMethodId)
                    .IsRequired()
                    .HasColumnName("SAMP_PREP_METHOD_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SampPrepMethodName)
                    .HasColumnName("SAMP_PREP_METHOD_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TWqxRefTaxaOrg>(entity =>
            {
                entity.HasKey(e => new { e.OrgId, e.BioSubjectTaxonomy });

                entity.ToTable("T_WQX_REF_TAXA_ORG");

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BioSubjectTaxonomy)
                    .HasColumnName("BIO_SUBJECT_TAXONOMY")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxRefTaxaOrg)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_WQX_REF__ORG_I__5812160E");
            });

            modelBuilder.Entity<TWqxResult>(entity =>
            {
                entity.HasKey(e => e.ResultIdx)
                    .HasName("PK_WQX_RESULT");

                entity.ToTable("T_WQX_RESULT");

                entity.Property(e => e.ResultIdx).HasColumnName("RESULT_IDX");

                entity.Property(e => e.ActivityIdx).HasColumnName("ACTIVITY_IDX");

                entity.Property(e => e.AnalyticMethodIdx).HasColumnName("ANALYTIC_METHOD_IDX");

                entity.Property(e => e.BiasValue)
                    .HasColumnName("BIAS_VALUE")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BioIndividualId)
                    .HasColumnName("BIO_INDIVIDUAL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.BioIntentName)
                    .HasColumnName("BIO_INTENT_NAME")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BioSampleTissueAnatomy)
                    .HasColumnName("BIO_SAMPLE_TISSUE_ANATOMY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BioSubjectTaxonomy)
                    .HasColumnName("BIO_SUBJECT_TAXONOMY")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.BioUnidentifiedSpeciesId)
                    .HasColumnName("BIO_UNIDENTIFIED_SPECIES_ID")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.CharName)
                    .HasColumnName("CHAR_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ConfidenceIntervalValue)
                    .HasColumnName("CONFIDENCE_INTERVAL_VALUE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DataLoggerLine)
                    .HasColumnName("DATA_LOGGER_LINE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DepthHeightMsr)
                    .HasColumnName("DEPTH_HEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DepthHeightMsrUnit)
                    .HasColumnName("DEPTH_HEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Depthaltituderefpoint)
                    .HasColumnName("DEPTHALTITUDEREFPOINT")
                    .HasMaxLength(125)
                    .IsUnicode(false);

                entity.Property(e => e.DetectionLimit)
                    .HasColumnName("DETECTION_LIMIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DetectionLimitType)
                    .HasColumnName("DETECTION_LIMIT_TYPE")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DetectionLimitUnit)
                    .HasColumnName("DETECTION_LIMIT_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DilutionFactor)
                    .HasColumnName("DILUTION_FACTOR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FreqClassCode)
                    .HasColumnName("FREQ_CLASS_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FreqClassLower)
                    .HasColumnName("FREQ_CLASS_LOWER")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FreqClassUnit)
                    .HasColumnName("FREQ_CLASS_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FreqClassUpper)
                    .HasColumnName("FREQ_CLASS_UPPER")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.GrpSummCountWeightMsr)
                    .HasColumnName("GRP_SUMM_COUNT_WEIGHT_MSR")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.GrpSummCountWeightMsrUnit)
                    .HasColumnName("GRP_SUMM_COUNT_WEIGHT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.LabAnalysisEndDt)
                    .HasColumnName("LAB_ANALYSIS_END_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabAnalysisStartDt)
                    .HasColumnName("LAB_ANALYSIS_START_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabAnalysisTimezone)
                    .HasColumnName("LAB_ANALYSIS_TIMEZONE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LabIdx).HasColumnName("LAB_IDX");

                entity.Property(e => e.LabReportingLevel)
                    .HasColumnName("LAB_REPORTING_LEVEL")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.LabSampPrepEndDt)
                    .HasColumnName("LAB_SAMP_PREP_END_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabSampPrepIdx).HasColumnName("LAB_SAMP_PREP_IDX");

                entity.Property(e => e.LabSampPrepStartDt)
                    .HasColumnName("LAB_SAMP_PREP_START_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabTaxonAccredAuthority)
                    .HasColumnName("LAB_TAXON_ACCRED_AUTHORITY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LabTaxonAccredInd)
                    .HasColumnName("LAB_TAXON_ACCRED_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LowerConfidenceLimit)
                    .HasColumnName("LOWER_CONFIDENCE_LIMIT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LowerQuantLimit)
                    .HasColumnName("LOWER_QUANT_LIMIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.MethodSpeciationName)
                    .HasColumnName("METHOD_SPECIATION_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ParticlesizeBasis)
                    .HasColumnName("PARTICLESIZE_BASIS")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Pql)
                    .HasColumnName("PQL")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PrecisionValue)
                    .HasColumnName("PRECISION_VALUE")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ResultComment)
                    .HasColumnName("RESULT_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ResultDetectCondition)
                    .HasColumnName("RESULT_DETECT_CONDITION")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ResultLabCommentCode)
                    .HasColumnName("RESULT_LAB_COMMENT_CODE")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ResultMsr)
                    .HasColumnName("RESULT_MSR")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ResultMsrQual)
                    .HasColumnName("RESULT_MSR_QUAL")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ResultMsrUnit)
                    .HasColumnName("RESULT_MSR_UNIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ResultSampFraction)
                    .HasColumnName("RESULT_SAMP_FRACTION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ResultSampPoint)
                    .HasColumnName("RESULT_SAMP_POINT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ResultStatus)
                    .HasColumnName("RESULT_STATUS")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ResultValueType)
                    .HasColumnName("RESULT_VALUE_TYPE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatisticBaseCode)
                    .HasColumnName("STATISTIC_BASE_CODE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlCellForm)
                    .HasColumnName("TAX_DTL_CELL_FORM")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlCellShape)
                    .HasColumnName("TAX_DTL_CELL_SHAPE")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlFuncFeedingGroup1)
                    .HasColumnName("TAX_DTL_FUNC_FEEDING_GROUP1")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlFuncFeedingGroup2)
                    .HasColumnName("TAX_DTL_FUNC_FEEDING_GROUP2")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlFuncFeedingGroup3)
                    .HasColumnName("TAX_DTL_FUNC_FEEDING_GROUP3")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlHabit)
                    .HasColumnName("TAX_DTL_HABIT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlPollTolerance)
                    .HasColumnName("TAX_DTL_POLL_TOLERANCE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlPollToleranceScale)
                    .HasColumnName("TAX_DTL_POLL_TOLERANCE_SCALE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlTrophicLevel)
                    .HasColumnName("TAX_DTL_TROPHIC_LEVEL")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDtlVoltinism)
                    .HasColumnName("TAX_DTL_VOLTINISM")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TempBasis)
                    .HasColumnName("TEMP_BASIS")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.TimeBasis)
                    .HasColumnName("TIME_BASIS")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UpperConfidenceLimit)
                    .HasColumnName("UPPER_CONFIDENCE_LIMIT")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpperQuantLimit)
                    .HasColumnName("UPPER_QUANT_LIMIT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.WeightBasis)
                    .HasColumnName("WEIGHT_BASIS")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActivityIdxNavigation)
                    .WithMany(p => p.TWqxResult)
                    .HasForeignKey(d => d.ActivityIdx)
                    .HasConstraintName("FK__T_WQX_RES__ACTIV__4E88ABD4");

                entity.HasOne(d => d.AnalyticMethodIdxNavigation)
                    .WithMany(p => p.TWqxResult)
                    .HasForeignKey(d => d.AnalyticMethodIdx)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__T_WQX_RES__ANALY__5070F446");

                entity.HasOne(d => d.LabIdxNavigation)
                    .WithMany(p => p.TWqxResult)
                    .HasForeignKey(d => d.LabIdx)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__T_WQX_RES__LAB_I__4F7CD00D");
            });

            modelBuilder.Entity<TWqxTransactionLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK_WQX_TRANSACTION_LOG");

                entity.ToTable("T_WQX_TRANSACTION_LOG");

                entity.Property(e => e.LogId).HasColumnName("LOG_ID");

                entity.Property(e => e.CdxSubmitStatus)
                    .HasColumnName("CDX_SUBMIT_STATUS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CdxSubmitTransid)
                    .HasColumnName("CDX_SUBMIT_TRANSID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseFile).HasColumnName("RESPONSE_FILE");

                entity.Property(e => e.ResponseTxt)
                    .HasColumnName("RESPONSE_TXT")
                    .IsUnicode(false);

                entity.Property(e => e.SubmitDt)
                    .HasColumnName("SUBMIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubmitType)
                    .IsRequired()
                    .HasColumnName("SUBMIT_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TableCd)
                    .IsRequired()
                    .HasColumnName("TABLE_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TableIdx).HasColumnName("TABLE_IDX");
            });

            modelBuilder.Entity<TWqxUserOrgs>(entity =>
            {
                entity.HasKey(e => new { e.UserIdx, e.OrgId })
                    .HasName("PK_T_OE_USER_ORGS");

                entity.ToTable("T_WQX_USER_ORGS");

                entity.Property(e => e.UserIdx).HasColumnName("USER_IDX");

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RoleCd)
                    .HasColumnName("ROLE_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.TWqxUserOrgs)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK__T_WQX_USE__ORG_I__38996AB5");

                entity.HasOne(d => d.UserIdxNavigation)
                    .WithMany(p => p.TWqxUserOrgs)
                    .HasForeignKey(d => d.UserIdx)
                    .HasConstraintName("FK__T_WQX_USE__USER___398D8EEE");
            });

            modelBuilder.Entity<VWqxActivityLatest>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_WQX_ACTIVITY_LATEST");

                entity.Property(e => e.ActComment)
                    .HasColumnName("ACT_COMMENT")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ActStartDt)
                    .HasColumnName("ACT_START_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActType)
                    .HasColumnName("ACT_TYPE")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityId)
                    .HasColumnName("ACTIVITY_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityIdx).HasColumnName("ACTIVITY_IDX");

                entity.Property(e => e.AlkalinityTotal)
                    .HasColumnName("Alkalinity, total")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Ammonia)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDt)
                    .HasColumnName("CREATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserid)
                    .HasColumnName("CREATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DissolvedOxygenDo)
                    .HasColumnName("Dissolved oxygen (DO)")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EscherichiaColi)
                    .HasColumnName("Escherichia coli")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.MonlocIdx).HasColumnName("MONLOC_IDX");

                entity.Property(e => e.MonlocName)
                    .IsRequired()
                    .HasColumnName("MONLOC_NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nitrate)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nitrite)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PH)
                    .HasColumnName("pH")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Phosphorus)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectIdx).HasColumnName("PROJECT_IDX");

                entity.Property(e => e.Salinity)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.SpecificConductance)
                    .HasColumnName("Specific Conductance")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TemperatureAir)
                    .HasColumnName("Temperature, air")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TemperatureWater)
                    .HasColumnName("Temperature, water")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TotalDissolvedSolids)
                    .HasColumnName("Total Dissolved Solids")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Turbidity)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.WqxInd).HasColumnName("WQX_IND");
            });

            modelBuilder.Entity<VWqxAllOrgs>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_WQX_ALL_ORGS");

                entity.Property(e => e.OrgFormalName)
                    .IsRequired()
                    .HasColumnName("ORG_FORMAL_NAME")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Src)
                    .HasColumnName("SRC")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VWqxPendingRecords>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_WQX_PENDING_RECORDS");

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecId)
                    .IsRequired()
                    .HasColumnName("REC_ID")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RecIdx).HasColumnName("REC_IDX");

                entity.Property(e => e.TableCd)
                    .IsRequired()
                    .HasColumnName("TABLE_CD")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDt)
                    .HasColumnName("UPDATE_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdateUserid)
                    .HasColumnName("UPDATE_USERID")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VWqxTransactionLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_WQX_TRANSACTION_LOG");

                entity.Property(e => e.CdxSubmitStatus)
                    .HasColumnName("CDX_SUBMIT_STATUS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CdxSubmitTransid)
                    .HasColumnName("CDX_SUBMIT_TRANSID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LogId)
                    .HasColumnName("LOG_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OrgId)
                    .HasColumnName("ORG_ID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Record)
                    .HasColumnName("RECORD")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseFile).HasColumnName("RESPONSE_FILE");

                entity.Property(e => e.ResponseTxt)
                    .HasColumnName("RESPONSE_TXT")
                    .IsUnicode(false);

                entity.Property(e => e.SubmitDt)
                    .HasColumnName("SUBMIT_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubmitType)
                    .IsRequired()
                    .HasColumnName("SUBMIT_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TableCd)
                    .IsRequired()
                    .HasColumnName("TABLE_CD")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TableIdx).HasColumnName("TABLE_IDX");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
