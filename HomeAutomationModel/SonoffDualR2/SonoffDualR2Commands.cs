using HomeAutomationModel.Enum;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutomationModel.SonoffDualR2
{
    public class SonoffDualR2Commands
    {
        private SonoffDualR2Commands(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        #region Commands

        //https://github.com/arendst/Sonoff-Tasmota/wiki/Commands

        /*
         (SetOption14 1) SetOption14%201 = if you set it up this cmd when you turn on one of the channels the another channel is switched off automatically
        */

        //cm?cmnd=Power1Power2 USE THIS COMMAND TO GET INFORMATION OF POWER 
        //cm?cmnd=SwitchMode2%203 USE THIS COMMAND TO CHANGE BEAVIOR GPIO FOR BUTTON MODE (SwitchModeX 3) -> x is the number of channel of Sonoff
        //cm?cmnd=SwitchMode2%200 USE THIS COMMAND TO CHANGE BEAVIOR GPIO FOR TOGGLE MODE (SwitchModeX 0) -> x is the number of channel of Sonoff
        //cm?cmnd=Power2%20TOGGLE USE THIS COMMAND TO TOGGLE THE CHANNEL (EX.: PowerX%20TOGGLE) -> x is the number of channel of Sonoff

        private const string CmdPrefix = "cm?cmnd=";

        private const string CmdPowerPrefix = "Power";

        private const string CmdPowerOffPrefix = CmdPowerPrefix;
        private const string CmdPowerOffSufix = "%20Off"; //"cm?cmnd=Power1%20Off"

        private const string CmdPowerOnPrefix = CmdPowerPrefix;
        private const string CmdPowerOnSufix = "%20On";  //cm?cmnd=Power1%20On

        private const string CmdCurrentState = CmdPowerPrefix; //cm?cmnd=Power2

        private const string CmdFriendlyName = "FriendlyName";

        private const string CmdSwitchModeExternalButtonPrefix = "SwitchMode";

        /// <summary>
        /// It's describe how is the behavior of the external button
        /// </summary>
        private const string CmdSwitchModeExternalButtonToButtonModeSufix = "%203"; //cm?cmnd=SwitchModeX%203 (X => Channel Id)

        /// <summary>
        /// It's describe how is the behavior of the external button
        /// </summary>
        private const string CmdSwitchModeExternalButtonToToggleModeSufix = "%200"; //cm?cmnd=SwitchModeX%200 (X => Channel Id)

        private const string CmdTogglePrefix = CmdPowerPrefix;

        /// <summary>
        /// Alternate the current state relay
        /// </summary>
        private const string CmdToggleSufix = "%20TOGGLE"; //cm?cmnd=PowerX%20TOGGLE (X => Channel Id)

        #endregion Commands

        public static string PowerOff(int SonoffChannel)
        {
            return (new StringBuilder().Append(CmdPrefix).Append(CmdPowerOffPrefix).Append(SonoffChannel).Append(CmdPowerOffSufix)).ToString();
        }

        public static string PowerOn(int SonoffChannel)
        {
            return (new StringBuilder().Append(CmdPrefix).Append(CmdPowerOnPrefix).Append(SonoffChannel).Append(CmdPowerOnSufix)).ToString();
        }

        public static string Toggle(int SonoffChannel)
        {
            return (new StringBuilder().Append(CmdPrefix).Append(CmdTogglePrefix).Append(SonoffChannel).Append(CmdToggleSufix)).ToString();
        }

        public static string CurrentState(int SonoffChannel)
        {
            return (new StringBuilder().Append(CmdPrefix).Append(CmdCurrentState).Append(SonoffChannel)).ToString();
        }

        public static string FriendlyName(int SonoffChannel)
        {
            return (new StringBuilder().Append(CmdPrefix).Append(CmdFriendlyName).Append(SonoffChannel)).ToString();
        }

        public static string SwitchModeExternalButton_ToButtonMode(int SonoffChannel)
        {
            return ((new StringBuilder().Append(CmdPrefix).Append(CmdSwitchModeExternalButtonPrefix).Append(SonoffChannel).Append(CmdSwitchModeExternalButtonToButtonModeSufix)).ToString()).ToString();
        }

        public static string SwitchModeExternalButton_ToToggleMode(int SonoffChannel)
        {
            return ((new StringBuilder().Append(CmdPrefix).Append(CmdSwitchModeExternalButtonPrefix).Append(SonoffChannel).Append(CmdSwitchModeExternalButtonToToggleModeSufix)).ToString()).ToString();
        }

        public static string GetCommandSonoffDualR2(SonoffDualR2 sonoffRequest)
        {
            switch (sonoffRequest.SonoffRequestCommandEnum)
            {
                case SonoffRequestCommandEnum.SonoffDualR2_PowerOff:
                    return PowerOff(sonoffRequest.SonoffChannel);

                case SonoffRequestCommandEnum.SonoffDualR2_PowerOn:
                    return PowerOn(sonoffRequest.SonoffChannel);

                case SonoffRequestCommandEnum.SonoffDualR2_Toggle:
                    return Toggle(sonoffRequest.SonoffChannel);

                case SonoffRequestCommandEnum.SonoffDualR2_CurrentState:
                    return CurrentState(sonoffRequest.SonoffChannel);

                case SonoffRequestCommandEnum.SonoffDualR2_FriendlyName:
                    return FriendlyName(sonoffRequest.SonoffChannel);

                case SonoffRequestCommandEnum.SonoffDualR2_SwitchModeExternalButton_ToButtonMode:
                    return SwitchModeExternalButton_ToButtonMode(sonoffRequest.SonoffChannel);

                case SonoffRequestCommandEnum.SonoffDualR2_SwitchModeExternalButton_ToToggleMode:
                    return SwitchModeExternalButton_ToToggleMode(sonoffRequest.SonoffChannel);

                default:
                    return "";
            }
        }
    }
}



#region Public Methods Sonoff Channel One

//public static SonoffDualR2 PowerOff_ChannelOne
//{
//    get
//    {
//        return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdPowerOffPrefix).Append("1").Append(CmdPowerOffSufix)).ToString());
//    }
//}

//public static SonoffDualR2 PowerOn_ChannelOne
//{
//    get
//    {
//        return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdPowerOnPrefix).Append("1").Append(CmdPowerOnSufix)).ToString());
//    }
//}

//public static SonoffDualR2 Toggle_ChannelOne
//{
//    get
//    {
//        return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdTogglePrefix).Append("1").Append(CmdToggleSufix)).ToString());
//    }
//}

//public static SonoffDualR2 CurrentState_ChannelOne
//{
//    get
//    {
//        return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdCurrentState).Append("1")).ToString());
//    }
//}

//public static SonoffDualR2 FriendlyName_ChannelOne
//{
//    get
//    {
//        return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdFriendlyName).Append("1")).ToString());
//    }
//}

//public static SonoffDualR2 SwitchModeExternalButton_ChannelOne_ToButtonMode
//{
//    get
//    {
//        return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdSwitchModeExternalButtonPrefix).Append("1").Append(CmdSwitchModeExternalButtonToButtonModeSufix)).ToString());
//    }
//}

//public static SonoffDualR2 SwitchModeExternalButton_ChannelOne_ToToggleMode
//{
//    get
//    {
//        return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdSwitchModeExternalButtonPrefix).Append("1").Append(CmdSwitchModeExternalButtonToToggleModeSufix)).ToString());
//    }
//}

#endregion Public Methods Sonoff Channel One

#region Public Methods Sonoff Channel Two

//    public static SonoffDualR2 PowerOff_ChannelTwo
//    {
//        get
//        {
//            return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdPowerOffPrefix).Append("2").Append(CmdPowerOffSufix)).ToString());
//        }
//    }

//    public static SonoffDualR2 PowerOn_ChannelTwo
//    {
//        get
//        {
//            return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdPowerOnPrefix).Append("2").Append(CmdPowerOnSufix)).ToString());
//        }
//    }

//    public static SonoffDualR2 Toggle_ChannelTwo
//    {
//        get
//        {
//            return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdTogglePrefix).Append("2").Append(CmdToggleSufix)).ToString());
//        }
//    }

//    public static SonoffDualR2 CurrentState_ChannelTwo
//    {
//        get
//        {
//            return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdCurrentState).Append("2")).ToString());
//        }
//    }

//    public static SonoffDualR2 FriendlyName_ChannelTwo
//{
//    get
//    {
//        return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdFriendlyName).Append("2")).ToString());
//    }
//}

//    public static SonoffDualR2 SwitchModeExternalButton_ChannelTwo_ToButtonMode
//    {
//        get
//        {
//            return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdSwitchModeExternalButtonPrefix).Append("2").Append(CmdSwitchModeExternalButtonToButtonModeSufix)).ToString());
//        }
//    }

//    public static SonoffDualR2 SwitchModeExternalButton_ChannelTwo_ToToggleMode
//    {
//        get
//        {
//            return new SonoffDualR2((new StringBuilder().Append(CmdPrefix).Append(CmdSwitchModeExternalButtonPrefix).Append("2").Append(CmdSwitchModeExternalButtonToToggleModeSufix)).ToString());
//        }
//    }

#endregion Public Methods Sonoff Channel Two
