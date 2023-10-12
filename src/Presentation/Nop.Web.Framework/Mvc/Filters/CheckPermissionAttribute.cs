using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nop.Core;
using Nop.Data;
using Nop.Services.Localization;
using Nop.Services.Security;

namespace Nop.Web.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents a filter attribute that confirms access to functional
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class CheckPermissionAttribute : TypeFilterAttribute
    {
        #region Ctor

        /// <summary>
        /// Create instance of the filter attribute
        /// </summary>
        /// <param name="permissionSystemName">Permission to check</param>
        /// <param name="resultType">The result type for not confirmed access situation</param>
        public CheckPermissionAttribute(string permissionSystemName, CheckPermissionResultType resultType = CheckPermissionResultType.Default) : base(typeof(CheckPermissionFilter))
        {
            Arguments = new object[] { resultType, permissionSystemName };
            PermissionSystemName = permissionSystemName;
            ResultType = resultType;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a permission system name to check
        /// </summary>
        public string PermissionSystemName { get; }

        /// <summary>
        /// Gets a check permission result type
        /// </summary>
        public CheckPermissionResultType ResultType { get; }

        #endregion

        #region Nested filter

        /// <summary>
        /// Represents a filter that confirms access
        /// </summary>
        private class CheckPermissionFilter : IAsyncAuthorizationFilter
        {
            #region Fields
            
            protected readonly IHttpContextAccessor _httpContextAccessor;
            protected readonly ILocalizationService _localizationService;
            protected readonly IPermissionService _permissionService;
            protected readonly IWebHelper _webHelper;

            protected readonly CheckPermissionResultType _resultType;
            protected readonly string _permissionSystemName;

            #endregion

            #region Ctor

            public CheckPermissionFilter(CheckPermissionResultType resultType, 
                string permissionSystemName,
                IHttpContextAccessor httpContextAccessor,
                ILocalizationService localizationService,
                IPermissionService permissionService,
                IWebHelper webHelper)
            {
                _resultType = resultType;
                _permissionSystemName = permissionSystemName;

                _httpContextAccessor = httpContextAccessor;
                _localizationService = localizationService;
                _permissionService = permissionService;
                _webHelper = webHelper;
            }

            #endregion

            #region Utilities

            /// <summary>
            /// Called early in the filter pipeline to confirm request is authorized
            /// </summary>
            /// <param name="context">Authorization filter context</param>
            /// <returns>A task that represents the asynchronous operation</returns>
            private async Task AuthorizeAsync(AuthorizationFilterContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                if (!DataSettingsManager.IsDatabaseInstalled())
                    return;
                
                //there is AdminAuthorizeFilter, so check access
                if (context.Filters.Any(filter => filter is CheckPermissionFilter))
                {
                    var permission = await _permissionService.GetPermissionRecordBySystemNameAsync(_permissionSystemName);
                    
                    if (permission == null)
                        return;

                    //authorize permission of access to the admin area
                    if (await _permissionService.AuthorizeAsync(permission))
                        return;

                    var resultType = _resultType;

                    var request = _httpContextAccessor.HttpContext?.Request;

                    if (request == null)
                        return;

                    if (resultType == CheckPermissionResultType.Default)
                        switch (request.Method)
                        {
                            case WebRequestMethods.Http.Post:
                                resultType = _webHelper.IsAjaxRequest(request) ? CheckPermissionResultType.Json : CheckPermissionResultType.Html;
                                break;
                            case WebRequestMethods.Http.Get:
                                resultType = CheckPermissionResultType.Html;
                                break;
                            default:
                                resultType = CheckPermissionResultType.Text;
                                break;
                        }

                    switch (resultType)
                    {
                        case CheckPermissionResultType.Json:
                            context.Result = new JsonResult(new
                            {
                                error = await _localizationService.GetResourceAsync("Admin.AccessDenied.Description")
                            });
                            break;
                        case CheckPermissionResultType.Html:
                            context.Result = new RedirectToActionResult("AccessDenied", "Security", context.RouteData.Values);
                            break;
                        case CheckPermissionResultType.Text:
                            context.Result = new ContentResult
                            {
                                Content = await _localizationService.GetResourceAsync("Admin.AccessDenied.Description"),
                                ContentType = "text/plain",
                            };
                            break;
                    }
                }
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called early in the filter pipeline to confirm request is authorized
            /// </summary>
            /// <param name="context">Authorization filter context</param>
            /// <returns>A task that represents the asynchronous operation</returns>
            public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
            {
                await AuthorizeAsync(context);
            }

            #endregion
        }

        #endregion

        #region Nested class

        public enum CheckPermissionResultType
        {
            /// <summary>
            /// For Get requests it will be <see cref="Html"/>. For POST request it will be <see cref="Json"/> if request is Ajax, <see cref="Html"/> in other case. For other one it will by <see cref="Text"/>
            /// </summary>
            Default = 0,
            /// <summary>
            /// Redirect to Access Denied page
            /// </summary>
            Html = 1,
            /// <summary>
            /// Return the plain text content
            /// </summary>
            Text = 2,
            /// <summary>
            /// Return the JSON content
            /// </summary>
            Json = 3
        }

        #endregion
    }
}