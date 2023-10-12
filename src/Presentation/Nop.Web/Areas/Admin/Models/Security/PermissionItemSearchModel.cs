using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Security
{
    /// <summary>
    /// Represents a permission category item search model
    /// </summary>
    public partial record PermissionItemSearchModel : BaseSearchModel
    {
        #region Properties

        public int PermissionCategoryTypeId { get; set; }

        #endregion
    }
}