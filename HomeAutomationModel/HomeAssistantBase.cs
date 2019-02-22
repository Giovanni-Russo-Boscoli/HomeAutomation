using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutomationModel
{
    public class HomeAssistantBase
    {
        private static readonly string _prefix_IdDevice = "HomeAssistantData";

        public static string Prefix_IdDevice {
            get {
                return _prefix_IdDevice;
            } 
        }        
    }
}
