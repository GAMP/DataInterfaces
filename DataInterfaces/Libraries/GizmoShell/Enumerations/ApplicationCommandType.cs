namespace GizmoShell
{
    /// <summary>
    /// Windows application command types.
    /// </summary>
    /// <remarks>
    /// For more info on commands see <see href="https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-appcommand"/>.
    /// </remarks>
    public enum ApplicationCommandType
    {
        /// <summary>
        /// Browser backward.
        /// </summary>
        BrowserBackward = 1,

        /// <summary>
        /// Browser forward.
        /// </summary>
        BrowserForward = 2,

        /// <summary>
        /// Browser refresh.
        /// </summary>
        BrowserRefresh = 3,

        /// <summary>
        /// Browser stop.
        /// </summary>
        BrowserStop = 4,

        /// <summary>
        /// Browser search.
        /// </summary>
        BrowserSearch = 5,

        /// <summary>
        /// Browser favorites.
        /// </summary>
        BrowserFavorites = 6,

        /// <summary>
        /// Browser home.
        /// </summary>
        BrowserHome = 7,

        /// <summary>
        /// Volume mute.
        /// </summary>
        VolumeMute = 8,

        /// <summary>
        /// Volume down.
        /// </summary>
        VolumeDown = 9,

        /// <summary>
        /// Volume up.
        /// </summary>
        VolumeUp = 10,

        /// <summary>
        /// Media next track.
        /// </summary>
        MediaNextTrack = 11,

        /// <summary>
        /// Media previous track.
        /// </summary>
        MediaPreviousTrack = 12,

        /// <summary>
        /// Media stop.
        /// </summary>
        MediaStop = 13,

        /// <summary>
        /// Media play pause.
        /// </summary>
        MediaPlayPause = 14,

        /// <summary>
        /// Launch mail.
        /// </summary>
        LaunchMail = 15,

        /// <summary>
        /// Launch media select.
        /// </summary>
        LaunchMediaSelect = 16,

        /// <summary>
        /// Launch first app.
        /// </summary>
        LaunchApp1 = 17,

        /// <summary>
        /// Launch second app.
        /// </summary>
        LaunchApp2 = 18,

        /// <summary>
        /// Bass down.
        /// </summary>
        BassDown = 19,

        /// <summary>
        /// Bass boost.
        /// </summary>
        BassBoost = 20,

        /// <summary>
        /// Bass up.
        /// </summary>
        BassUp = 21,

        /// <summary>
        /// Treble down.
        /// </summary>
        TrebleDown = 22,

        /// <summary>
        /// Treble up.
        /// </summary>
        TrebleUp = 23,

        /// <summary>
        /// Microphone mute.
        /// </summary>
        MicrophoneVolumeMute = 24,

        /// <summary>
        /// Microphone volume down.
        /// </summary>
        MicrophoneVolumeDown = 25,

        /// <summary>
        /// Microphone volume up.
        /// </summary>
        MicrophoneVolumeUp = 26,

        /// <summary>
        /// Help.
        /// </summary>
        Help = 27,

        /// <summary>
        /// Find.
        /// </summary>
        Find = 28,

        /// <summary>
        /// New.
        /// </summary>
        New = 29,

        /// <summary>
        /// Open.
        /// </summary>
        Open = 30,

        /// <summary>
        /// Close.
        /// </summary>
        Close = 31,

        /// <summary>
        /// Save.
        /// </summary>
        Save = 32,

        /// <summary>
        /// Print.
        /// </summary>
        Print = 33,

        /// <summary>
        /// Undo.
        /// </summary>
        Undo = 34,

        /// <summary>
        /// Redo.
        /// </summary>
        Redo = 35,

        /// <summary>
        /// Copy.
        /// </summary>
        Copy = 36,

        /// <summary>
        /// Cut.
        /// </summary>
        Cut = 37,

        /// <summary>
        /// Paste.
        /// </summary>
        Paste = 38,

        /// <summary>
        /// Reply to mail.
        /// </summary>
        ReplyToMail = 39,

        /// <summary>
        /// Forward mail.
        /// </summary>
        ForwardMail = 40,

        /// <summary>
        /// Send mail.
        /// </summary>
        SendMail = 41,

        /// <summary>
        /// Spell check.
        /// </summary>
        SpellCheck = 42,

        /// <summary>
        /// Dictate or command control toggle.
        /// </summary>
        DictateOrCommandControlToggle = 43,

        /// <summary>
        /// Mic on-off toggle.
        /// </summary>
        MicOnOffToggle = 44,

        /// <summary>
        /// Correction list.
        /// </summary>
        CorrectionList = 45,

        /// <summary>
        /// Media play.
        /// </summary>
        MediaPlay = 46,

        /// <summary>
        /// Media pause.
        /// </summary>
        MediaPause = 47,

        /// <summary>
        /// Media record.
        /// </summary>
        MediaRecord = 48,

        /// <summary>
        /// Media fast forward.
        /// </summary>
        MediaFastForward = 49,

        /// <summary>
        /// Media rewind.
        /// </summary>
        MediaRewind = 50,

        /// <summary>
        /// Media channel up.
        /// </summary>
        MediaChannelUp = 51,

        /// <summary>
        /// Media channel down.
        /// </summary>
        MediaChannelDown = 52,

        /// <summary>
        /// Delete.
        /// </summary>
        Delete = 53,

        /// <summary>
        /// DWM Flip 3d.
        /// </summary>
        DWMFlip3D = 54
    } 
}
