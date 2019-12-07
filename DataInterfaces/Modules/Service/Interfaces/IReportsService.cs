using ServerService.Reporting;
using ServerService.Reporting.Reports.Applications;
using ServerService.Reporting.Reports.Assets;
using ServerService.Reporting.Reports.Financial;
using ServerService.Reporting.Reports.Hosts;
using ServerService.Reporting.Reports.Overview;
using ServerService.Reporting.Reports.Products;
using ServerService.Reporting.Reports.Shifts;
using ServerService.Reporting.Reports.Transactions;
using ServerService.Reporting.Reports.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerService
{
    /// <summary>
    /// Represents a type used to fetch report data.
    /// </summary>
    public interface IReportsService
    {
        #region COMMON

        /// <summary>
        /// Returns a string that defines the time the business day start.
        /// </summary>
        /// <returns>The string that defines the time the business day start in format: "HH:mm:ss"</returns>
        string GetBusinessDayStart();

        /// <summary>
        /// Returns the first business day.
        /// </summary>
        /// <returns></returns>
        DayOfWeek GetBusinessStartWeekDay();

        /// <summary>
        /// Returns the first week day of the specified date's week.
        /// </summary>
        /// <param name="date">The date within the week to search.</param>
        /// <param name="startDay">The week day to use as first week day.</param>
        /// <returns></returns>
        DateTime GetFirstBusinessDayOfWeek(DateTime date, DayOfWeek startDay);

        /// <summary>
        /// Returns a list of available registers.
        /// </summary>
        /// <returns></returns>
        Task<List<ListItemDTO>> GetRegistersAsync();
        
        /// <summary>
        /// Returns a list of available applications.
        /// </summary>
        /// <param name="onlyWithLicenses">true to return only applications that use licenses, false to return all applications.</param>
        /// <returns></returns>
        Task<List<ListItemDTO>> GetApplicationsAsync(bool onlyWithLicenses);

        /// <summary>
        /// Returns a list of available products.
        /// </summary>
        /// <returns></returns>
        Task<List<ListItemDTO>> GetProductsAsync();

        /// <summary>
        /// Returns a list of available operators.
        /// </summary>
        /// <returns></returns>
        Task<List<ListItemDTO>> GetOperatorsAsync();

        #endregion

        #region APPLICATIONS

        /// <summary>
        /// Returns the applications report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<ApplicationsReportDTO> GetApplicationsReportAsync(ApplicationsReportFilterDTO filters);

        /// <summary>
        /// Returns the application report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<ApplicationReportDTO> GetApplicationReportAsync(ApplicationReportFilterDTO filters);

        /// <summary>
        /// Returns a list of the available licenses.
        /// </summary>
        /// <returns></returns>
        Task<List<ListItemDTO>> GetLicensesAsync();

        /// <summary>
        /// Returns the licenses report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<LicensesReportDTO> GetLicensesReportAsync(LicensesReportFilterDTO filters);

        /// <summary>
        /// Returns the license report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<LicenseReportDTO> GetLicenseReportAsync(LicenseReportFilterDTO filters);

        #endregion

        #region FINANCIAL

        /// <summary>
        /// Returns the financial report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<FinancialReportDTO> GetFinancialReportAsync(FinancialReportFilterDTO filters);

        /// <summary>
        /// Returns the Z report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<ZReportDTO> GetZReportAsync(ZReportFilterDTO filters);

        /// <summary>
        /// Returns the invoices report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<InvoicesLogReportDTO> GetInvoicesLogReportAsync(InvoicesLogReportFilterDTO filters);

        /// <summary>
        /// Returns the invoice report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<InvoiceReportDTO> GetInvoiceReportAsync(InvoiceReportFilterDTO filters);

        /// <summary>
        /// Returns the overview report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<OverviewReportDTO> GetOverviewReportAsync(OverviewReportFilterDTO filters);

        /// <summary>
        /// Returns the shifts log report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<ShiftsLogReportDTO> GetShiftsLogReportAsync(ShiftsLogReportFilterDTO filters);

        /// <summary>
        /// Returns the transactions log report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<TransactionsLogReportDTO> GetTransactionsLogReportAsync(TransactionsLogReportFilterDTO filters);

        /// <summary>
        /// Returns the Z log report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<ZLogReportDTO> GetZLogReportAsync(ZLogReportFilterDTO filters);

        #endregion

        #region HOSTS

        /// <summary>
        /// Returns a list of the available host groups.
        /// </summary>
        /// <returns></returns>
        Task<List<ListItemDTO>> GetHostGroupsAsync();

        /// <summary>
        /// Returns a list of the available hosts.
        /// </summary>
        /// <returns></returns>
        Task<List<ListItemDTO>> GetHostsAsync();

        /// <summary>
        /// Returns the host usage report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<HostUsageReportDTO> GetHostUsageReportAsync(HostUsageReportFilterDTO filters);

        #endregion

        #region PRODUCTS

        /// <summary>
        /// Returns a list of the available asset types.
        /// </summary>
        /// <returns></returns>
        Task<List<ListItemDTO>> GetAssetTypesAsync();

        /// <summary>
        /// Returns a list of the available assets.
        /// </summary>
        /// <returns></returns>
        Task<List<AssetDTO>> GetAssetsAsync();

        /// <summary>
        /// Returns the assets report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<AssetsLogReportDTO> GetAssetsLogReportAsync(AssetsLogReportFilterDTO filters);

        /// <summary>
        /// Returns the products report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<ProductsReportDTO> GetProductsReportAsync(ProductsReportFilterDTO filters);

        /// <summary>
        /// Returns the product report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<ProductReportDTO> GetProductReportAsync(ProductReportFilterDTO filters);

        /// <summary>
        /// Returns the stock report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<StockReportDTO> GetStockReportAsync(StockReportFilterDTO filters);

        #endregion

        #region USERS

        /// <summary>
        /// Returns a list of the active members.
        /// </summary>
        /// <returns></returns>
        Task<List<ListItemDTO>> GetActiveMembersAsync();

        /// <summary>
        /// Returns the sessions log report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<SessionsLogReportDTO> GetSessionsLogReportAsync(SessionsLogReportFilterDTO filters);

        /// <summary>
        /// Returns a list of users where their username matches the specified search pattern.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<List<AutocompleteListItemDTO>> GetUsersByUsernameAsync(string username);

        /// <summary>
        /// Returns the top users report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<TopUsersReportDTO> GetTopUsersReportAsync(TopUsersReportFilterDTO filters);

        /// <summary>
        /// Returns the user report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<UserReportDTO> GetUserReportAsync(UserReportFilterDTO filters);

        /// <summary>
        /// Returns the user export that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <param name="filterValues"></param>
        /// <returns></returns>
        Task<ExportDTO> GetUserExportAsync(ExportFilterDTO filters, List<ExportFilterValueDTO> filterValues);

        /// <summary>
        /// Returns the list of the available fields for user export.
        /// </summary>
        /// <returns></returns>
        List<ExportFieldDTO> GetUserExportAvailableFields();

        /// <summary>
        /// Returns the orders log report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<OrdersLogReportDTO> GetOrdersLogReportAsync(OrdersReportFilterDTO filters);

        /// <summary>
        /// Returns the orders statistics report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<OrdersStatisticsReportDTO> GetOrdersStatisticsReportAsync(OrdersReportFilterDTO filters);

        /// <summary>
        /// Returns the products log report that match the specified filters.
        /// </summary>
        /// <param name="filters">The filters to apply when retrieving the data for this report.</param>
        /// <returns></returns>
        Task<ProductsLogReportDTO> GetProductsLogReportAsync(ProductsLogReportFilterDTO filters);

        #endregion
    }
}