using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Security;
using Nop.Core.Security;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.Security;
using ILogger = Nop.Services.Logging.ILogger;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class SecurityController : BaseAdminController
    {
        #region Fields

        protected readonly ICustomerService _customerService;
        protected readonly ILocalizationService _localizationService;
        protected readonly ILogger _logger;
        protected readonly INotificationService _notificationService;
        protected readonly IPermissionService _permissionService;
        protected readonly ISecurityModelFactory _securityModelFactory;
        protected readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public SecurityController(ICustomerService customerService,
            ILocalizationService localizationService,
            ILogger logger,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISecurityModelFactory securityModelFactory,
            IWorkContext workContext)
        {
            _customerService = customerService;
            _localizationService = localizationService;
            _logger = logger;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _securityModelFactory = securityModelFactory;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        public virtual async Task<IActionResult> AccessDenied(string pageUrl)
        {
            var currentCustomer = await _workContext.GetCurrentCustomerAsync();
            if (currentCustomer == null || await _customerService.IsGuestAsync(currentCustomer))
            {
                await _logger.InformationAsync($"Access denied to anonymous request on {pageUrl}");
                return View();
            }

            await _logger.InformationAsync($"Access denied to user #{currentCustomer.Email} '{currentCustomer.Email}' on {pageUrl}");

            return View();
        }

        public virtual async Task<IActionResult> PermissionEditPopup(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.ManageAcl))
                return AccessDeniedView();

            var permissionRecord = await _permissionService.GetPermissionRecordByIdAsync(id);

            return View(await _securityModelFactory.PreparePermissionItemModelAsync(permissionRecord));
        }

        [HttpPost]
        public virtual async Task<IActionResult> PermissionEditPopup(PermissionItemModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.ManageAcl))
                return AccessDeniedView();
            
            if (ModelState.IsValid)
            {
                var mapping = await _permissionService.GetMappingByPermissionRecordIdAsync(model.Id);

                var rolesForDelete = mapping.Where(p => !model.SelectedCustomerRoleIds.Contains(p.CustomerRoleId))
                    .Select(p => p.CustomerRoleId);

                var rolesToAdd = model.SelectedCustomerRoleIds.Where(p => mapping.All(m => m.CustomerRoleId != p));

                foreach (var customerRoleId in rolesForDelete) 
                    await _permissionService.DeletePermissionRecordCustomerRoleMappingAsync(model.Id, customerRoleId);

                foreach (var customerRoleId in rolesToAdd)
                    await _permissionService.InsertPermissionRecordCustomerRoleMappingAsync(new PermissionRecordCustomerRoleMapping
                    {
                        PermissionRecordId = model.Id,
                        CustomerRoleId = customerRoleId
                    });
                ViewBag.RefreshPage = true;

                var permissionRecord = await _permissionService.GetPermissionRecordByIdAsync(model.Id);
                model = await _securityModelFactory.PreparePermissionItemModelAsync(permissionRecord);

                return View(model);
            }
            
            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public virtual async Task<IActionResult> Permissions()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.ManageAcl))
                return AccessDeniedView();

            //prepare model
            var model = await _securityModelFactory.PreparePermissionMappingModelAsync(new PermissionMappingModel());

            return View(model);
        }


        [HttpPost]
        public virtual async Task<IActionResult> PermissionCategories(PermissionCategorySearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.ManageAcl))
                return await AccessDeniedDataTablesJson();
            
            var model = await _securityModelFactory.PreparePermissionCategoryListModelAsync(searchModel);

            return Json(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> PermissionCategory(PermissionItemSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermission.ManageOrders))
                return await AccessDeniedDataTablesJson();
            
            var model = await _securityModelFactory.PreparePermissionItemListModelAsync(searchModel);

            return Json(model);
        }

        #endregion
    }
}