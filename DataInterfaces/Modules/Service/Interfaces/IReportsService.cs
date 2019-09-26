using ServerService.Reporting;
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

namespace ServerService
{
    public interface IReportsService
    {
        FinancialReportDTO GetFinancialReport(FinancialReportFilterDTO Filters);

        List<ListItemDTO> GetHostGroups();

        HostUsageReportDTO GetHostUsageReport(HostUsageReportFilterDTO Filters);

        OverviewReportDTO GetOverviewReport(OverviewReportFilterDTO Filters);

        TopUsersReportDTO GetUsersReport(TopUsersReportFilterDTO Filters);

        List<SoldProductDTO> GetProducts();

        List<ListItemDTO> GetOperators();

        StockReportDTO GetStockReport(StockReportFilterDTO Filters);

        ProductReportDTO GetProductReport(ProductReportFilterDTO Filters);

        TransactionsLogReportDTO GetTransactionsLogReport(TransactionsLogReportFilterDTO Filters);

        DayOfWeek GetBusinessStartWeekDay();

        string GetBusinessDayStart();

        DateTime GetFirstBusinessDayOfWeek(DateTime Date, DayOfWeek StartDay);

        List<ListItemDTO> GetRegisters();

        ShiftsLogReportDTO GetShiftsLogReport(ShiftsLogReportFilterDTO Filters);

        List<ListItemDTO> GetAssetTypes();

        List<ListItemDTO> GetAssets();

        AssetsLogReportDTO GetAssetsLogReport(AssetsLogReportFilterDTO Filters);

        InvoicesLogReportDTO GetInvoicesLogReport(InvoicesLogReportFilterDTO Filters);

        InvoiceReportDTO GetInvoiceReport(InvoiceReportFilterDTO Filters);

        ZLogReportDTO GetZLogReport(ZLogReportFilterDTO Filters);
    }
}