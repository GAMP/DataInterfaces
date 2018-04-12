using System;

namespace Client
{
    [Flags()]
    public enum MessageDialogButtons
    {
        None = 0,
        Accept = 1,
        Cancel = 2,
        AcceptCancel = Accept | Cancel,
    }
}
