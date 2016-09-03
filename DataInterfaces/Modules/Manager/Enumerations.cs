using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager
{
    /// <summary>
    /// Definitions of known menu areas.
    /// </summary>
    public static class KnownMenuArea
    {
        public static readonly string MainModule = "6bb0c179-5773-47bb-82d1-cb934b9792f7";
        public static readonly string HostsModule = "a6177552-c05a-4d45-87a2-c128f6be6ca6";
        public static readonly string SystemLogModule = "e6a30318-843a-43fc-982c-9df445bc0fce";
        public static readonly string ManagerLogModule = "2fa7b7ac-2958-495b-bb83-e85bcab5f26d";
        public static readonly string UsersModule = "98bc7f41-c7f8-4388-a39e-9c15d1af49a5";
        public static readonly string HostManagementModule = "ae67aa8d-60d9-46e0-8a35-ffc1979a5113";
        public static readonly string UserDetail = "5b9ecf8d-771a-4619-83f7-ddddf7ed96db";
    }

    /// <summary>
    /// Defenitions of known menu items.
    /// </summary>
    public static class KnownMenuItem
    {
        public static readonly string Main_Manager = "4875ba1a-f856-47d5-9433-aa31a094c53d";
        public static readonly string Main_Manager_Disconnect = "59ac74cb-8fc5-466d-a0ff-2d70d8e96304";
        public static readonly string Main_Manager_Exit = "a4107613-7cca-452c-ba3f-f4fd31b74bc7";
        public static readonly string Main_Manager_Change_Password = "5da2a6ca-20ae-4c3d-83e5-e30cd97758cc";

        public static readonly string Main_Tools = "ff93e179-1dc8-423f-8c98-02e102af8a20";
        public static readonly string Main_Help = "6a55ebfa-74a7-4d4c-8d71-8ca05265f2e5";

        public static readonly string UserDetail_Account_Enable = "ff93e179-1dc8-423f-8c98-02e102af8a20";
        public static readonly string UserDetail_Reset_Password = "6a55ebfa-74a7-4d4c-8d71-8ca05265f2e5";
        public static readonly string UserDetail_Reset_Info = "6a55ebfa-74a7-4d4c-8d71-8ca05265f2e5";
        public static readonly string UserDetail_Rfid_Assign = "6a55ebfa-74a7-4d4c-8d71-8ca05265f2e5";
    }

    public enum ManagerMessageDialogResult
    {
        Negative = 0,
        Affirmative = 1,
        FirstAuxiliary,
        SecondAuxiliary,
    }

    public enum ManagerMessageDialogStyle
    {
        Affirmative = 0,
        AffirmativeAndNegative = 1,
        AffirmativeAndNegativeAndSingleAuxiliary = 2,
        AffirmativeAndNegativeAndDoubleAuxiliary = 3
    }
}
