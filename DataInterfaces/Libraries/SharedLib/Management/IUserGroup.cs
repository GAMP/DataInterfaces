using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Management
{
    #region IUserGroup
    public interface IUserGroup
    {
        int Id { get; set; }
        int ApplicationProfileId { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        UserInfoTypes RequiredUserInfo { get; set; }
        int SecurityProfileId { get; set; }
        bool DisablePersonalStorage { get; set; }
        GroupOverrides Overrides { get; set; }
    }
    #endregion
}
