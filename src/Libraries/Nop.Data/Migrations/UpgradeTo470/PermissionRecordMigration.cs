using FluentMigrator;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Security;

namespace Nop.Data.Migrations.UpgradeTo470
{
    [NopMigration("2023-10-01 12:00:00", "Set standard permission category type", MigrationProcessType.Update)]
    public class PermissionRecordMigration : MigrationBase
    {
        #region Fields

        protected readonly IRepository<Language> _languageRepository;
        protected readonly IRepository<LocaleStringResource> _localeStringRepository;
        protected readonly IRepository<PermissionRecord> _permissionRepository;
        protected readonly IRepository<PermissionRecordCustomerRoleMapping> _permissionRecordCustomerRoleMappingRepository;

        #endregion

        #region Ctor

        public PermissionRecordMigration(IRepository<Language> languageRepository,
            IRepository<LocaleStringResource> localeStringRepository,
            IRepository<PermissionRecord> permissionRepository,
            IRepository<PermissionRecordCustomerRoleMapping> permissionRecordCustomerRoleMappingRepository)
        {
            _languageRepository = languageRepository;
            _localeStringRepository = localeStringRepository;
            _permissionRepository = permissionRepository;
            _permissionRecordCustomerRoleMappingRepository = permissionRecordCustomerRoleMappingRepository;
        }

        #endregion

        #region Utilities
        
        /// <summary>
        /// Gets a permission record-customer role mapping
        /// </summary>
        /// <param name="permissionId">Permission identifier</param>
        /// <returns>Permission record-customer role mapping</returns>
        protected virtual IList<PermissionRecordCustomerRoleMapping> GetMappingByPermissionRecordId(int permissionId)
        {
            var records = _permissionRecordCustomerRoleMappingRepository.Table
                .Where(x => x.PermissionRecordId == permissionId);

            return records.ToList();
        }

        #endregion

        #region Methods

        public override void Up()
        {
            var permissions = StandardPermission.GetPermissions();

            var dbPermissions = _permissionRepository.Table
                .OrderBy(pr => pr.Id);

            PermissionRecord getPermissionRecord(string systemName)
            {
                if (string.IsNullOrWhiteSpace(systemName))
                    return null;

                var permissionRecord = dbPermissions
                    .FirstOrDefault(pr => pr.SystemName == systemName);

                return permissionRecord;
            }

            foreach (var permissionRecord in permissions)
            {
                var pr = getPermissionRecord(permissionRecord.SystemName);

                if (pr != null) 
                    permissionRecord.Id = pr.Id;
            }

            _permissionRepository.Update(permissions.Where(p=> p.Id != 0).ToList());
            var newPermissions = permissions.Where(p => p.Id == 0).ToList();
            _permissionRepository.Insert(newPermissions);

            var langs = _languageRepository.Table.ToList();

            _localeStringRepository.Insert(newPermissions.SelectMany(permissionRecord =>
            {
                var resourceName = $"Permission.{permissionRecord.SystemName}";
                var resourceValue = permissionRecord.Name;

                return langs.Select(lang => new LocaleStringResource
                {
                    LanguageId = lang.Id,
                    ResourceName = resourceName,
                    ResourceValue = resourceValue
                });
            }).ToList());

            void insert(IEnumerable<int> roles, PermissionRecord permission)
            {
                foreach (var role in roles)
                    try
                    {
                        _permissionRecordCustomerRoleMappingRepository.Insert(
                            new PermissionRecordCustomerRoleMapping
                            {
                                CustomerRoleId = role,
                                PermissionRecordId = permission.Id
                            });
                    }
                    catch
                    {
                        //ignore
                    }
            }

            var record = getPermissionRecord("ManageProducts");
            
            if (record != null)
            {
                var roles = GetMappingByPermissionRecordId(record.Id)
                    .Select(p => p.CustomerRoleId).ToList();

                var newPermissionRecord = getPermissionRecord(StandardPermission.Reports.LOW_STOCK_REPORT_SYSTEM_NAME);
                if (newPermissionRecord != null)
                    insert(roles, newPermissionRecord);
            }

            record = getPermissionRecord("ManageOrders");

            if (record != null)
            {
                var roles = GetMappingByPermissionRecordId(record.Id)
                    .Select(p => p.CustomerRoleId).ToList();

                var newPermissionRecord = getPermissionRecord(StandardPermission.Reports.BESTSELLERS_REPORT_SYSTEM_NAME);
                if (newPermissionRecord != null)
                    insert(roles, newPermissionRecord);

                newPermissionRecord = getPermissionRecord(StandardPermission.Reports.PRODUCTS_NEVER_PURCHASED_REPORT_SYSTEM_NAME);
                if (newPermissionRecord != null)
                    insert(roles, newPermissionRecord);
            }

            record = getPermissionRecord("ManageCustomers");

            if (record != null)
            {
                var roles = GetMappingByPermissionRecordId(record.Id)
                    .Select(p => p.CustomerRoleId).ToList();

                var newPermissionRecord = getPermissionRecord(StandardPermission.Reports.REGISTERED_CUSTOMERS_REPORT_SYSTEM_NAME);
                if (newPermissionRecord != null)
                    insert(roles, newPermissionRecord);

                newPermissionRecord = getPermissionRecord(StandardPermission.Reports.CUSTOMERS_BY_ORDER_TOTAL_REPORT_SYSTEM_NAME);
                if (newPermissionRecord != null)
                    insert(roles, newPermissionRecord);

                newPermissionRecord = getPermissionRecord(StandardPermission.Reports.CUSTOMERS_BY_NUMBER_OF_ORDERS_REPORT_SYSTEM_NAME);
                if (newPermissionRecord != null)
                    insert(roles, newPermissionRecord);
            }
        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }

        #endregion
    }
}
