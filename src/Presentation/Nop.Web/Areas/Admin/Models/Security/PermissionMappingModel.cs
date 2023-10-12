using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Security
{
    /// <summary>
    /// Represents a permission mapping model
    /// </summary>
    public partial record PermissionMappingModel : BaseNopModel
    {
        #region Ctor

        public PermissionMappingModel()
        {
            PermissionCategorySearchModel = new PermissionCategorySearchModel
            {
                Length = int.MaxValue
            };
        }

        #endregion

        #region Properties

        public bool IsPermissionsAvailable { get; set; }

        public bool AreCustomerRolesAvailable { get; set; }
        
        public PermissionCategorySearchModel PermissionCategorySearchModel { get; set; }

        #endregion
    }
}