using FluentMigrator;
using Nop.Core.Domain.Security;

namespace Nop.Data.Migrations.UpgradeTo470
{
    [NopSchemaMigration("2023-10-01 00:00:00", "SchemaMigration for 4.70.0")]
    public class EnterpriseSchemaMigration : ForwardOnlyMigration
    {
        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            //#10
            var permissionRecordTableName = nameof(PermissionRecord);
            var permissionRecordTable = Schema.Table(permissionRecordTableName);
            var categoryTypeColumnName = nameof(PermissionRecord.CategoryTypeId);
            var categoryColumnName = "Category";

            if (!permissionRecordTable.Column(categoryTypeColumnName).Exists())
                Alter.Table(permissionRecordTableName)
                    .AddColumn(categoryTypeColumnName).AsInt32().NotNullable().SetExistingRowsTo((int)PermissionCategoryType.Standard);

            if (permissionRecordTable.Column(categoryColumnName).Exists()) 
                Delete.Column(categoryColumnName).FromTable(permissionRecordTableName);
        }
    }
}
