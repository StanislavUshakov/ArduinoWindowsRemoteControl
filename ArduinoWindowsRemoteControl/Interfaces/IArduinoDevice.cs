using ArduinoWindowsRemoteControl.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Interfaces
{
    #region RemoteCommand Enum

    /// <summary>
    /// Represents received remote command
    /// </summary>
    public enum RemoteCommand
    {
        [Description("Turn On/Off")]
        TurnOnOff,

        [Description("Mode")]
        Mode,

        [Description("Mute")]
        Mute,

        [Description("Play/Pause")]
        PlayPause,

        [Description("Previous")]
        Previous,

        [Description("Next")]
        Next,

        [Description("EQ")]
        EQ,

        [Description("Minus")]
        Minus,

        [Description("Plus")]
        Plus,

        [Description("Random")]
        Random,

        [Description("U/SD")]
        USD,

        [Description("0")]
        Dig0,

        [Description("1")]
        Dig1,

        [Description("2")]
        Dig2,

        [Description("3")]
        Dig3,

        [Description("4")]
        Dig4,

        [Description("5")]
        Dig5,

        [Description("6")]
        Dig6,

        [Description("7")]
        Dig7,

        [Description("8")]
        Dig8,

        [Description("9")]
        Dig9
    }

    #endregion

    /// <summary>
    /// Represents device that is connected with the remote control
    /// </summary>
    public interface IRemoteInputDevice
    {
        /// <summary>
        /// This event is fired when remote command is received
        /// </summary>
        event Action<RemoteCommand> OnCommandReceived;
    }
}
