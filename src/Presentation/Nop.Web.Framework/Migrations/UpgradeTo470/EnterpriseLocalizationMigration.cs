using FluentMigrator;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Services.Localization;
using Nop.Web.Framework.Extensions;

namespace Nop.Web.Framework.Migrations.UpgradeTo470
{
    [NopUpdateMigration("2023-10-01 00:00:00", "4.70", UpdateMigrationType.Localization)]
    public class EnterpriseLocalizationMigration : MigrationBase
    {
        /// <summary>Collect the UP migration expressions</summary>
        public override void Up()
        {
            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            //do not use DI, because it produces exception on the installation process
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();

            var (languageId, languages) = this.GetLanguageData();

            #region Delete locales
            
            #endregion

            #region Rename locales

            #endregion

            #region Add or update locales

            localizationService.AddOrUpdateLocaleResource(new Dictionary<string, string>
            {
                //#10  
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.Catalog"] = "Catalog",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.Configuration"] = "Configuration",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.ContentManagement"] = "Content management",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.Customers"] = "Customers",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.Orders"] = "Orders",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.Promotions"] = "Promotions",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.PublicStore"] = "Public store",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.Reports"] = "Reports",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.Security"] = "Security",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.Standard"] = "Standard",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.System"] = "System",
                ["Enums.Nop.Core.Domain.Security.PermissionCategoryType.Unknown"] = "Unknown",
                ["Admin.Configuration.ACL.NoCustomerRolesAvailable"] = "No customer roles available",
                ["Admin.Configuration.ACL.NoPermissions"] = "No permissions defined",
                ["Admin.Configuration.ACL.Permission.Edit"] = "Edit permission rules",
                ["Admin.Configuration.ACL.PermissionCategoryName"] = "Category of permissions",
            }, languageId);

            #endregion
        }

        /// <summary>Collects the DOWN migration expressions</summary>
        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
