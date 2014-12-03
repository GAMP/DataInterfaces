using System;

namespace IntegrationLib
{
    public interface IAuthResult
    {
        global::System.Collections.Generic.Dictionary<string, object> Custom { get; }
        global::IntegrationLib.IUserIdentity Identity { get; set; }
        global::SharedLib.UserInfoTypes RequiredInfo { get; set; }
        global::IntegrationLib.LoginResult Result { get; set; }
    }
}
