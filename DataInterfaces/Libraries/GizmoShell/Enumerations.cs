﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GizmoShell
{
    public enum ApplicationCommandType : int
    {
        //Windows 2000
        BrowserBackward = 1,
        BrowserForward = 2,
        BrowserRefresh = 3,
        BrowserStop = 4,
        BrowserSearch = 5,
        BrowserFavorites = 6,
        BrowserHome = 7,
        VolumeMute = 8,
        VolumeDown = 9,
        VolumeUp = 10,
        MediaNextTrack = 11,
        MediaPreviousTrack = 12,
        MediaStop = 13,
        MediaPlayPause = 14,
        LaunchMail = 15,
        LaunchMediaSelect = 16,
        LaunchApp1 = 17,
        LaunchApp2 = 18,
        BassDown = 19,
        BassBoost = 20,
        BassUp = 21,
        TrebleDown = 22,
        TrebleUp = 23,
        //Windows XP
        MicrophoneVolumeMute = 24,
        MicrophoneVolumeDown = 25,
        MicrophoneVolumeUp = 26,
        Help = 27,
        Find = 28,
        New = 29,
        Open = 30,
        Close = 31,
        Save = 32,
        Print = 33,
        Undo = 34,
        Redo = 35,
        Copy = 36,
        Cut = 37,
        Paste = 38,
        ReplyToMail = 39,
        ForwardMail = 40,
        SendMail = 41,
        SpellCheck = 42,
        DictateOrCommandControlToggle = 43,
        MicOnOffToggle = 44,
        CorrectionList = 45,
        MediaPlay = 46,
        MediaPause = 47,
        MediaRecord = 48,
        MediaFastForward = 49,
        MediaRewind = 50,
        MediaChannelUp = 51,
        MediaChannelDown = 52,

        //Windows Vista
        Delete = 53,
        DWMFlip3D = 54
    }

}
