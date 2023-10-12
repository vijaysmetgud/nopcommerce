using Nop.Core.Domain.Security;
using Nop.Services.Security;
using NUnit.Framework;

namespace Nop.Tests.Nop.Services.Tests.Security
{
    [TestFixture]
    public class PermissionServiceTests : ServiceTest
    {
        private IPermissionService _permissionService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _permissionService = GetService<IPermissionService>();
        }

        [Test]
        public async Task TestCrud()
        {
            var insertItem = new PermissionRecord
            {
                Name = "Test name",
                SystemName = "Test system name",
                CategoryType = PermissionCategoryType.Unknown
            };

            var updateItem = new PermissionRecord
            {
                Name = "Test name 1",
                SystemName = "Test system name",
                CategoryType = PermissionCategoryType.Unknown
            };

            await TestCrud(insertItem, _permissionService.InsertPermissionRecordAsync, updateItem, _permissionService.UpdatePermissionRecordAsync, _permissionService.GetPermissionRecordByIdAsync, (item, other) => item.Name.Equals(other.Name), _permissionService.DeletePermissionRecordAsync);
        }
    }
}
