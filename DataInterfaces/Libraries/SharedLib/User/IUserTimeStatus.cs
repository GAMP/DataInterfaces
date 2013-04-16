using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.User
{
    public interface IUserTimeStatus
    {
        double Credit { get; }
        int TotalMinutes { get; }
    }
}
