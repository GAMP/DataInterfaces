namespace CoreLib
{
    public enum PowerStates : byte
    {
        None = 0,
        Reboot = 1,
        Shutdown = 2,
        Suspend = 4,
        Hibernate = 8,
        Logoff = 16,
    }
}
