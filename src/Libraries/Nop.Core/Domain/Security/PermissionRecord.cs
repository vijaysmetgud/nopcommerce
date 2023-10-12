namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// Represents a permission record
    /// </summary>
    public partial class PermissionRecord : BaseEntity
    {
        public PermissionRecord() { }

        public PermissionRecord(PermissionCategoryType permissionCategory)
        {
            CategoryType = permissionCategory;
        }

        /// <summary>
        /// Gets or sets the permission name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the permission system name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the permission category type
        /// </summary>
        public PermissionCategoryType CategoryType
        {
            get => (PermissionCategoryType)CategoryTypeId;
            set => CategoryTypeId = (int)value;
        }

        /// <summary>
        /// Gets or sets the permission category type identifier
        /// </summary>
        public int CategoryTypeId { get; set; }
    }
}