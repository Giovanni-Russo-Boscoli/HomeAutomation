using HomeAutomationModel.Enum;

namespace HomeAutomationModel.SonoffDualR2
{
    public class SonoffDualR2
    {
        private string _idDevice;
        public string IdDevice
        {
            get
            {
                return _idDevice;
            }
            set {
                _idDevice = value;
            }
        }

        private SonoffRequestCommandEnum sonoffRequestCommandEnum;
        public SonoffRequestCommandEnum SonoffRequestCommandEnum
        {
            get{
                return sonoffRequestCommandEnum;
            }
            set {
                sonoffRequestCommandEnum = value;
            }
        }

        //private DeviceEnum _sonoffModelEnum;
        public DeviceEnum SonoffModelEnum
        {
            get
            {
                return DeviceEnum.SonoffDualR2;
            }
            //set
            //{
            //    _sonoffModelEnum = value;
            //}
        }

        private int _sonoffChannel;
        public int SonoffChannel {
            get {
                return _sonoffChannel;
            } set {
                _sonoffChannel = value;
            }
        }
    }
}