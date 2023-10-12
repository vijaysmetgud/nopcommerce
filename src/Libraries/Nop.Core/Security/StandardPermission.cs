﻿using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;

namespace Nop.Core.Security
{
    /// <summary>
    /// Standard permission provider
    /// </summary>
    public static partial class StandardPermission
    {
        #region Standard

        public static readonly PermissionRecord AccessAdminPanel = new() { Name = "Access admin area", SystemName = "AccessAdminPanel", CategoryType = PermissionCategoryType.Standard };

        #endregion

        #region Customers

        public static readonly PermissionRecord AllowCustomerImpersonation = new() { Name = "Admin area. Allow Customer Impersonation", SystemName = "AllowCustomerImpersonation", CategoryType = PermissionCategoryType.Customers };
        public static readonly PermissionRecord ManageCustomers = new() { Name = "Admin area. Manage Customers", SystemName = "ManageCustomers", CategoryType = PermissionCategoryType.Customers };
        public static readonly PermissionRecord ManageVendors = new() { Name = "Admin area. Manage Vendors", SystemName = "ManageVendors", CategoryType = PermissionCategoryType.Customers };
        public static readonly PermissionRecord ManageActivityLog = new() { Name = "Admin area. Manage Activity Log", SystemName = "ManageActivityLog", CategoryType = PermissionCategoryType.Customers };

        #endregion

        #region Catalog

        public static readonly PermissionRecord ManageProducts = new() { Name = "Admin area. Manage Products", SystemName = "ManageProducts", CategoryType = PermissionCategoryType.Catalog };
        public static readonly PermissionRecord ManageCategories = new() { Name = "Admin area. Manage Categories", SystemName = "ManageCategories", CategoryType = PermissionCategoryType.Catalog };
        public static readonly PermissionRecord ManageManufacturers = new() { Name = "Admin area. Manage Manufacturers", SystemName = "ManageManufacturers", CategoryType = PermissionCategoryType.Catalog };
        public static readonly PermissionRecord ManageProductReviews = new() { Name = "Admin area. Manage Product Reviews", SystemName = "ManageProductReviews", CategoryType = PermissionCategoryType.Catalog };
        public static readonly PermissionRecord ManageProductTags = new() { Name = "Admin area. Manage Product Tags", SystemName = "ManageProductTags", CategoryType = PermissionCategoryType.Catalog };
        public static readonly PermissionRecord ManageAttributes = new() { Name = "Admin area. Manage Attributes", SystemName = "ManageAttributes", CategoryType = PermissionCategoryType.Catalog };

        #endregion

        #region Orders

        public static readonly PermissionRecord ManageCurrentCarts = new() { Name = "Admin area. Manage Current Carts", SystemName = "ManageCurrentCarts", CategoryType = PermissionCategoryType.Orders };
        public static readonly PermissionRecord ManageOrders = new() { Name = "Admin area. Manage Orders", SystemName = "ManageOrders", CategoryType = PermissionCategoryType.Orders };
        public static readonly PermissionRecord ManageRecurringPayments = new() { Name = "Admin area. Manage Recurring Payments", SystemName = "ManageRecurringPayments", CategoryType = PermissionCategoryType.Orders };
        public static readonly PermissionRecord ManageGiftCards = new() { Name = "Admin area. Manage Gift Cards", SystemName = "ManageGiftCards", CategoryType = PermissionCategoryType.Orders };
        public static readonly PermissionRecord ManageReturnRequests = new() { Name = "Admin area. Manage Return Requests", SystemName = "ManageReturnRequests", CategoryType = PermissionCategoryType.Orders };

        #endregion

        #region Promotions

        public static readonly PermissionRecord ManageAffiliates = new() { Name = "Admin area. Manage Affiliates", SystemName = "ManageAffiliates", CategoryType = PermissionCategoryType.Promotions };
        public static readonly PermissionRecord ManageCampaigns = new() { Name = "Admin area. Manage Campaigns", SystemName = "ManageCampaigns", CategoryType = PermissionCategoryType.Promotions };
        public static readonly PermissionRecord ManageDiscounts = new() { Name = "Admin area. Manage Discounts", SystemName = "ManageDiscounts", CategoryType = PermissionCategoryType.Promotions };
        public static readonly PermissionRecord ManageNewsletterSubscribers = new() { Name = "Admin area. Manage Newsletter Subscribers", SystemName = "ManageNewsletterSubscribers", CategoryType = PermissionCategoryType.Promotions };

        #endregion

        #region ContentManagement

        public static readonly PermissionRecord ManagePolls = new() { Name = "Admin area. Manage Polls", SystemName = "ManagePolls", CategoryType = PermissionCategoryType.ContentManagement };
        public static readonly PermissionRecord ManageNews = new() { Name = "Admin area. Manage News", SystemName = "ManageNews", CategoryType = PermissionCategoryType.ContentManagement };
        public static readonly PermissionRecord ManageBlog = new() { Name = "Admin area. Manage Blog", SystemName = "ManageBlog", CategoryType = PermissionCategoryType.ContentManagement };
        public static readonly PermissionRecord ManageWidgets = new() { Name = "Admin area. Manage Widgets", SystemName = "ManageWidgets", CategoryType = PermissionCategoryType.ContentManagement };
        public static readonly PermissionRecord ManageTopics = new() { Name = "Admin area. Manage Topics", SystemName = "ManageTopics", CategoryType = PermissionCategoryType.ContentManagement };
        public static readonly PermissionRecord ManageForums = new() { Name = "Admin area. Manage Forums", SystemName = "ManageForums", CategoryType = PermissionCategoryType.ContentManagement };
        public static readonly PermissionRecord ManageMessageTemplates = new() { Name = "Admin area. Manage Message Templates", SystemName = "ManageMessageTemplates", CategoryType = PermissionCategoryType.ContentManagement };

        #endregion

        #region Configuration

        public static readonly PermissionRecord ManageCountries = new() { Name = "Admin area. Manage Countries", SystemName = "ManageCountries", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageLanguages = new() { Name = "Admin area. Manage Languages", SystemName = "ManageLanguages", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageSettings = new() { Name = "Admin area. Manage Settings", SystemName = "ManageSettings", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManagePaymentMethods = new() { Name = "Admin area. Manage Payment Methods", SystemName = "ManagePaymentMethods", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageExternalAuthenticationMethods = new() { Name = "Admin area. Manage External Authentication Methods", SystemName = "ManageExternalAuthenticationMethods", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageMultifactorAuthenticationMethods = new() { Name = "Admin area. Manage Multi-factor Authentication Methods", SystemName = "ManageMultifactorAuthenticationMethods", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageTaxSettings = new() { Name = "Admin area. Manage Tax Settings", SystemName = "ManageTaxSettings", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageShippingSettings = new() { Name = "Admin area. Manage Shipping Settings", SystemName = "ManageShippingSettings", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageCurrencies = new() { Name = "Admin area. Manage Currencies", SystemName = "ManageCurrencies", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageAcl = new() { Name = "Admin area. Manage ACL", SystemName = "ManageACL", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageEmailAccounts = new() { Name = "Admin area. Manage Email Accounts", SystemName = "ManageEmailAccounts", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageStores = new() { Name = "Admin area. Manage Stores", SystemName = "ManageStores", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManagePlugins = new() { Name = "Admin area. Manage Plugins", SystemName = "ManagePlugins", CategoryType = PermissionCategoryType.Configuration };
        public static readonly PermissionRecord ManageAppSettings = new() { Name = "Admin area. Manage App Settings", SystemName = "ManageAppSettings", CategoryType = PermissionCategoryType.Configuration };

        #endregion

        #region PublicStore

        public static readonly PermissionRecord DisplayPrices = new() { Name = "Public store. Display Prices", SystemName = "DisplayPrices", CategoryType = PermissionCategoryType.PublicStore };
        public static readonly PermissionRecord EnableShoppingCart = new() { Name = "Public store. Enable shopping cart", SystemName = "EnableShoppingCart", CategoryType = PermissionCategoryType.PublicStore };
        public static readonly PermissionRecord EnableWishlist = new() { Name = "Public store. Enable wishlist", SystemName = "EnableWishlist", CategoryType = PermissionCategoryType.PublicStore };
        public static readonly PermissionRecord PublicStoreAllowNavigation = new() { Name = "Public store. Allow navigation", SystemName = "PublicStoreAllowNavigation", CategoryType = PermissionCategoryType.PublicStore };
        public static readonly PermissionRecord AccessClosedStore = new() { Name = "Public store. Access a closed store", SystemName = "AccessClosedStore", CategoryType = PermissionCategoryType.PublicStore };
        public static readonly PermissionRecord AccessProfiling = new() { Name = "Public store. Access MiniProfiler results", SystemName = "AccessProfiling", CategoryType = PermissionCategoryType.PublicStore };

        #endregion

        #region Security

        public static readonly PermissionRecord EnableMultiFactorAuthentication = new() { Name = "Security. Enable Multi-factor authentication", SystemName = "EnableMultiFactorAuthentication", CategoryType = PermissionCategoryType.Security };

        #endregion

        #region System

        public static readonly PermissionRecord ManageSystemLog = new() { Name = "Admin area. Manage System Log", SystemName = "ManageSystemLog", CategoryType = PermissionCategoryType.System };
        public static readonly PermissionRecord ManageMessageQueue = new() { Name = "Admin area. Manage Message Queue", SystemName = "ManageMessageQueue", CategoryType = PermissionCategoryType.System };
        public static readonly PermissionRecord ManageMaintenance = new() { Name = "Admin area. Manage Maintenance", SystemName = "ManageMaintenance", CategoryType = PermissionCategoryType.System };
        public static readonly PermissionRecord HtmlEditorManagePictures = new() { Name = "Admin area. HTML Editor. Manage pictures", SystemName = "HtmlEditor.ManagePictures", CategoryType = PermissionCategoryType.System };
        public static readonly PermissionRecord ManageScheduleTasks = new() { Name = "Admin area. Manage Schedule Tasks", SystemName = "ManageScheduleTasks", CategoryType = PermissionCategoryType.System };
        
        #endregion

        #region Reports
        

        public static class Reports
        {
            public const PermissionCategoryType PERMISSION_CATEGORY = PermissionCategoryType.Reports;

            public const string SALES_SUMMARY_REPORT_SYSTEM_NAME = "SalesSummaryReport";
            public const string ORDER_COUNTRY_REPORT_SYSTEM_NAME = "OrderCountryReport";
            public const string LOW_STOCK_REPORT_SYSTEM_NAME = "LowStockReport";
            public const string BESTSELLERS_REPORT_SYSTEM_NAME = "BestsellersReport";
            public const string PRODUCTS_NEVER_PURCHASED_REPORT_SYSTEM_NAME = "ProductsNeverPurchasedReport";
            public const string REGISTERED_CUSTOMERS_REPORT_SYSTEM_NAME = "RegisteredCustomersReport";
            public const string CUSTOMERS_BY_ORDER_TOTAL_REPORT_SYSTEM_NAME = "CustomersByOrderTotalReport";
            public const string CUSTOMERS_BY_NUMBER_OF_ORDERS_REPORT_SYSTEM_NAME = "CustomersByNumberOfOrdersReport";

            public static readonly PermissionRecord SalesSummaryReport = new(PERMISSION_CATEGORY) { Name = "Admin area.Reports.Sales summary", SystemName = SALES_SUMMARY_REPORT_SYSTEM_NAME};
            public static readonly PermissionRecord OrderCountryReport = new(PERMISSION_CATEGORY) { Name = "Admin area.Reports.Country sales", SystemName = ORDER_COUNTRY_REPORT_SYSTEM_NAME};
            public static readonly PermissionRecord LowStockReport = new (PERMISSION_CATEGORY) { Name = "Admin area. Reports.Low stock", SystemName = LOW_STOCK_REPORT_SYSTEM_NAME};
            public static readonly PermissionRecord BestsellersReport = new (PERMISSION_CATEGORY) { Name = "Admin area. Reports.Bestsellers", SystemName = BESTSELLERS_REPORT_SYSTEM_NAME};
            public static readonly PermissionRecord ProductsNeverPurchasedReport = new(PERMISSION_CATEGORY) { Name = "Admin area.Reports.Products never purchased", SystemName = PRODUCTS_NEVER_PURCHASED_REPORT_SYSTEM_NAME};
            public static readonly PermissionRecord RegisteredCustomersReport = new (PERMISSION_CATEGORY) { Name = "Admin area.Reports.Registered customers", SystemName = REGISTERED_CUSTOMERS_REPORT_SYSTEM_NAME};
            public static readonly PermissionRecord CustomersByOrderTotalReport = new (PERMISSION_CATEGORY) { Name = "Admin area. Reports.Customers by order total", SystemName = CUSTOMERS_BY_ORDER_TOTAL_REPORT_SYSTEM_NAME};
            public static readonly PermissionRecord CustomersByNumberOfOrdersReport = new(PERMISSION_CATEGORY) { Name = "Admin area. Reports.Customers by number of orders", SystemName = CUSTOMERS_BY_NUMBER_OF_ORDERS_REPORT_SYSTEM_NAME};

            public static IList<PermissionRecord> AllPermissions =>
                new[]
                {
                    SalesSummaryReport, OrderCountryReport, LowStockReport, BestsellersReport,
                    ProductsNeverPurchasedReport, RegisteredCustomersReport, CustomersByOrderTotalReport,
                    CustomersByNumberOfOrdersReport
                };
        }

        #endregion

        /// <summary>
        /// Get permissions
        /// </summary>
        /// <returns>Permissions</returns>
        public static IList<PermissionRecord> GetPermissions()
        {
            var permissions = new List<PermissionRecord>
            {
                AccessAdminPanel,
                AllowCustomerImpersonation,
                ManageProducts,
                ManageCategories,
                ManageManufacturers,
                ManageProductReviews,
                ManageProductTags,
                ManageAttributes,
                ManageCustomers,
                ManageVendors,
                ManageCurrentCarts,
                ManageOrders,
                ManageRecurringPayments,
                ManageGiftCards,
                ManageReturnRequests,
                ManageAffiliates,
                ManageCampaigns,
                ManageDiscounts,
                ManageNewsletterSubscribers,
                ManagePolls,
                ManageNews,
                ManageBlog,
                ManageWidgets,
                ManageTopics,
                ManageForums,
                ManageMessageTemplates,
                ManageCountries,
                ManageLanguages,
                ManageSettings,
                ManagePaymentMethods,
                ManageExternalAuthenticationMethods,
                ManageMultifactorAuthenticationMethods,
                ManageTaxSettings,
                ManageShippingSettings,
                ManageCurrencies,
                ManageActivityLog,
                ManageAcl,
                ManageEmailAccounts,
                ManageStores,
                ManagePlugins,
                ManageSystemLog,
                ManageMessageQueue,
                ManageMaintenance,
                HtmlEditorManagePictures,
                ManageScheduleTasks,
                ManageAppSettings,
                DisplayPrices,
                EnableShoppingCart,
                EnableWishlist,
                PublicStoreAllowNavigation,
                AccessClosedStore,
                AccessProfiling,
                EnableMultiFactorAuthentication
            };

            permissions.AddRange(Reports.AllPermissions);

            return permissions;
        }

        /// <summary>
        /// Get default permissions
        /// </summary>
        /// <returns>Permissions</returns>
        public static IList<(string systemRoleName, PermissionRecord[] permissions)> GetDefaultPermissions()
        {
            return new[]
            {
                (
                    NopCustomerDefaults.AdministratorsRoleName,
                    new[]
                    {
                        AccessAdminPanel,
                        AllowCustomerImpersonation,
                        ManageProducts,
                        ManageCategories,
                        ManageManufacturers,
                        ManageProductReviews,
                        ManageProductTags,
                        ManageAttributes,
                        ManageCustomers,
                        ManageVendors,
                        ManageCurrentCarts,
                        ManageOrders,
                        ManageRecurringPayments,
                        ManageGiftCards,
                        ManageReturnRequests,
                        Reports.BestsellersReport,
                        Reports.CustomersByNumberOfOrdersReport,
                        Reports.CustomersByOrderTotalReport,
                        Reports.LowStockReport,
                        Reports.OrderCountryReport,
                        Reports.ProductsNeverPurchasedReport,
                        Reports.RegisteredCustomersReport,
                        Reports.SalesSummaryReport,
                        ManageAffiliates,
                        ManageCampaigns,
                        ManageDiscounts,
                        ManageNewsletterSubscribers,
                        ManagePolls,
                        ManageNews,
                        ManageBlog,
                        ManageWidgets,
                        ManageTopics,
                        ManageForums,
                        ManageMessageTemplates,
                        ManageCountries,
                        ManageLanguages,
                        ManageSettings,
                        ManagePaymentMethods,
                        ManageExternalAuthenticationMethods,
                        ManageMultifactorAuthenticationMethods,
                        ManageTaxSettings,
                        ManageShippingSettings,
                        ManageCurrencies,
                        ManageActivityLog,
                        ManageAcl,
                        ManageEmailAccounts,
                        ManageStores,
                        ManagePlugins,
                        ManageSystemLog,
                        ManageMessageQueue,
                        ManageMaintenance,
                        HtmlEditorManagePictures,
                        ManageScheduleTasks,
                        ManageAppSettings,
                        DisplayPrices,
                        EnableShoppingCart,
                        EnableWishlist,
                        PublicStoreAllowNavigation,
                        AccessClosedStore,
                        AccessProfiling,
                        EnableMultiFactorAuthentication
                    }
                ),
                (
                    NopCustomerDefaults.ForumModeratorsRoleName,
                    new[]
                    {
                        DisplayPrices,
                        EnableShoppingCart,
                        EnableWishlist,
                        PublicStoreAllowNavigation
                    }
                ),
                (
                    NopCustomerDefaults.GuestsRoleName,
                    new[]
                    {
                        DisplayPrices,
                        EnableShoppingCart,
                        EnableWishlist,
                        PublicStoreAllowNavigation
                    }
                ),
                (
                    NopCustomerDefaults.RegisteredRoleName,
                    new[]
                    {
                        DisplayPrices,
                        EnableShoppingCart,
                        EnableWishlist,
                        PublicStoreAllowNavigation,
                        EnableMultiFactorAuthentication
                    }
                ),
                (
                    NopCustomerDefaults.VendorsRoleName,
                    new[]
                    {
                        AccessAdminPanel,
                        ManageProducts,
                        ManageProductReviews,
                        ManageOrders
                    }
                )
            };
        }
    }
}