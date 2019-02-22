using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutomationModel.Enum
{
    public enum SonoffRequestCommandEnum
    {
        #region Sonoff Dual R2

            Indefined = 0,
            SonoffDualR2_PowerOff = 1,
            SonoffDualR2_PowerOn,
            SonoffDualR2_Toggle,
            SonoffDualR2_CurrentState,
            SonoffDualR2_FriendlyName,
            SonoffDualR2_SwitchModeExternalButton_ToButtonMode,
            SonoffDualR2_SwitchModeExternalButton_ToToggleMode

        #endregion Sonoff Dual R2
    }
}
