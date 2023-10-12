using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Security
{
    public partial record PermissionCategoryModel : BaseNopModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}