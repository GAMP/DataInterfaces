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
    /// Represents a type used to fetch gizmo settings.
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Gets a settings value.
        /// </summary>
        /// <typeparam name="T">Value type.</typeparam>
        /// <param name="key">Settings key.</param>
        /// <returns>Settings value.</returns>
        T SettingGet<T>(string key);
    }
}