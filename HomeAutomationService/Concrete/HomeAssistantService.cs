using Google.Apis.Dialogflow.v2.Data;
using HomeAutomationModel.CustomViewModule;
using HomeAutomationModel.Dialogflow.DialogflowRequest;
using HomeAutomationModel.Enum;
using HomeAutomationModel.SonoffDualR2;
using HomeAutomationRepository.Interface;
using HomeAutomationService.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAutomationService.Concrete
{
    public class HomeAssistantService : IHomeAssistantService
    {
        private readonly IHomeAssistantRepository repository;

        public HomeAssistantService(IHomeAssistantRepository repository)
        {
            this.repository = repository;
        }

        #region DialogflowRequest

        public async Task<string> DeviceRequestCommand(DialogflowRequest dialogflowRequest)
        {
            //identify device
            object deviceRequested = ConvertDialogflowResquestToObject(dialogflowRequest);

            if (deviceRequested == null)
            {
                return FormatterSpeechResponse(dialogflowRequest, $"I'm sorry, {dialogflowRequest.QueryResult.Parameters.idDevice} was not found", false);
            }

            string jsonReturn = string.Empty;

            if (deviceRequested is SonoffDualR2)
            {
                //TODO: use pattern matching
                SonoffDualR2 sonoffRequest = ((SonoffDualR2)deviceRequested);
                if (ValidIdDeviceRequested(sonoffRequest.IdDevice))
                {
                    switch (sonoffRequest.SonoffModelEnum)
                    {
                        case DeviceEnum.SonoffDualR2:
                            jsonReturn = await SonoffDualR2ExecuteCommand(sonoffRequest);
                            return FormatterSpeechResponse(dialogflowRequest, jsonReturn, true);
                        default:
                            break;
                    }
                }
            }
            return FormatterSpeechResponse(dialogflowRequest, $"I'm sorry, {dialogflowRequest.QueryResult.Parameters.idDevice} was not found", false);
        }

        public async Task<string> DeviceRequestCommandDialogFlow(GoogleCloudDialogflowV2WebhookRequest dialogflowRequest)
        {
            //identify device
            object deviceRequested = ConvertDialogflowResquestToObject_GoogleObj(dialogflowRequest);

            if (deviceRequested == null)
            {
                return FormatterSpeechResponse_GoogleObj(dialogflowRequest, $"I'm sorry, {dialogflowRequest.QueryResult.Parameters["idDevice"].ToString()} was not found", false);
            }

            string jsonReturn = string.Empty;

            if (deviceRequested is SonoffDualR2)
            {
                //TODO: use pattern matching
                SonoffDualR2 sonoffRequest = ((SonoffDualR2)deviceRequested);
                if (ValidIdDeviceRequested(sonoffRequest.IdDevice))
                {
                    switch (sonoffRequest.SonoffModelEnum)
                    {
                        case DeviceEnum.SonoffDualR2:
                            jsonReturn = await SonoffDualR2ExecuteCommand(sonoffRequest);
                            return FormatterSpeechResponse_GoogleObj(dialogflowRequest, jsonReturn, true);
                        default:
                            break;
                    }
                }
            }
            return FormatterSpeechResponse_GoogleObj(dialogflowRequest, $"I'm sorry, {dialogflowRequest.QueryResult.Parameters["idDevice"].ToString()} was not found", false);
        }

        private IEnumerable<IConfigurationSection> GetInformationDeviceById(DialogflowRequest dialogflowRequest)
        {
            return repository.GetInformationDeviceById(dialogflowRequest.QueryResult.Parameters.idDevice);
        }

        private IEnumerable<IConfigurationSection> GetInformationDeviceById_GoogleObj(GoogleCloudDialogflowV2WebhookRequest dialogflowRequest)
        {
            return repository.GetInformationDeviceById(dialogflowRequest.QueryResult.Parameters["idDevice"].ToString());
        }

        private object ConvertDialogflowResquestToObject(DialogflowRequest dialogflowRequest)
        {

            var device = GetInformationDeviceById(dialogflowRequest);

            if (device == null || device.Count() <= 0)
            {
                return null;
            }

            var objectType = device.Where(x => x.Key.Equals("ModelDevice")).Select(y => y.Value).FirstOrDefault();
            //TODO: valid objectType (!=null)

            //VALID DEVICE AND OBJECTTYPE
            switch ((DeviceEnum)Enum.Parse(typeof(DeviceEnum), objectType, true))
            {
                case DeviceEnum.SonoffDualR2:
                    {
                        int _channel = 1;//by default we use channel 1 (if is not mentioned in the object in appsettings.json
                        int.TryParse(device.Where(x => x.Key.Equals("Channel")).Select(y => y.Value).FirstOrDefault(), out _channel);

                        return new SonoffDualR2()
                        {
                            IdDevice = device.Where(x => x.Key.Equals("IP_Address")).Select(y => y.Value).FirstOrDefault(),
                            SonoffChannel = _channel,
                            SonoffRequestCommandEnum = ConvertStringCmdToSonoffRequestCommandEnum(dialogflowRequest.QueryResult.Parameters.command)
                        };
                    }
                default:
                    return null;
            }
        }

        private object ConvertDialogflowResquestToObject_GoogleObj(GoogleCloudDialogflowV2WebhookRequest dialogflowRequest)
        {

            var device = GetInformationDeviceById_GoogleObj(dialogflowRequest);

            if (device == null || device.Count() <= 0)
            {
                return null;
            }

            var objectType = device.Where(x => x.Key.Equals("ModelDevice")).Select(y => y.Value).FirstOrDefault();
            //TODO: valid objectType (!=null)

            //VALID DEVICE AND OBJECTTYPE
            switch ((DeviceEnum)Enum.Parse(typeof(DeviceEnum), objectType, true))
            {
                case DeviceEnum.SonoffDualR2:
                    {
                        int _channel = 1;//by default we use channel 1 (if is not mentioned in the object in appsettings.json
                        int.TryParse(device.Where(x => x.Key.Equals("Channel")).Select(y => y.Value).FirstOrDefault(), out _channel);

                        return new SonoffDualR2()
                        {
                            IdDevice = device.Where(x => x.Key.Equals("IP_Address")).Select(y => y.Value).FirstOrDefault(),
                            SonoffChannel = _channel,
                            SonoffRequestCommandEnum = ConvertStringCmdToSonoffRequestCommandEnum(dialogflowRequest.QueryResult.Parameters["Command"].ToString())
                        };
                    }
                default:
                    return null;
            }
        }

        private bool ValidIdDeviceRequested(string IdDevice)
        {
            return (!string.IsNullOrEmpty(IdDevice));
        }

        private async Task<string> SonoffDualR2ExecuteCommand(SonoffDualR2 sonoffRequest)
        {
            return await BaseService.GetResponse(sonoffRequest.IdDevice, SonoffDualR2Commands.GetCommandSonoffDualR2(sonoffRequest));
        }

        private SonoffRequestCommandEnum ConvertStringCmdToSonoffRequestCommandEnum(string cmd)
        {
            switch (cmd)
            {
                //cases coming from entity Command in Dialogflow
                case "on":
                    return SonoffRequestCommandEnum.SonoffDualR2_PowerOn;
                case "off":
                    return SonoffRequestCommandEnum.SonoffDualR2_PowerOff;
                case "toggle":
                    return SonoffRequestCommandEnum.SonoffDualR2_Toggle;
                case "123":
                    return SonoffRequestCommandEnum.SonoffDualR2_CurrentState;
                case "456":
                    return SonoffRequestCommandEnum.SonoffDualR2_FriendlyName;
                case "789":
                    return SonoffRequestCommandEnum.SonoffDualR2_SwitchModeExternalButton_ToButtonMode;
                case "0":
                    return SonoffRequestCommandEnum.SonoffDualR2_SwitchModeExternalButton_ToToggleMode;
                default:
                    return SonoffRequestCommandEnum.Indefined;
            }
        }

        private string FormatterSpeechResponse(DialogflowRequest dialogflowRequest, string response, bool trimResponse)
        {

            if (!trimResponse)
            {
                return response;
            }

            response = response.Replace("\"", "").Replace("\\", "").Replace("}", "").Split(":")[1].ToLower();
            return $"{dialogflowRequest.QueryResult.Parameters.idDevice} was turned {response}";
        }

        private string FormatterSpeechResponse_GoogleObj(GoogleCloudDialogflowV2WebhookRequest dialogflowRequest, string response, bool trimResponse)
        {

            if (!trimResponse)
            {
                return response;
            }

            response = response.Replace("\"", "").Replace("\\", "").Replace("}", "").Split(":")[1].ToLower();
            return $"{dialogflowRequest.QueryResult.Parameters["idDevice"].ToString()} was turned {response}";
        }

        #endregion DialogflowRequest

        #region CustomViewModule

        public async Task<string> DeviceRequestCommandCustomViewModule(CustomViewModuleRequest customViewModuleRequest)
        {
            //identify device
            object deviceRequested = ConvertCustomViewModuleResquestToObject(customViewModuleRequest);

            if (deviceRequested == null)
            {
                return FormatterSpeechResponse_CustomViewModule(customViewModuleRequest, $"I'm sorry, {customViewModuleRequest.IdDevice} was not found", false);
            }

            string jsonReturn = string.Empty;

            if (deviceRequested is SonoffDualR2)
            {
                //TODO: use pattern matching
                SonoffDualR2 sonoffRequest = ((SonoffDualR2)deviceRequested);
                if (ValidIdDeviceRequested(sonoffRequest.IdDevice))
                {
                    switch (sonoffRequest.SonoffModelEnum)
                    {
                        case DeviceEnum.SonoffDualR2:
                            jsonReturn = await SonoffDualR2ExecuteCommand(sonoffRequest);
                            return FormatterSpeechResponse_CustomViewModule(customViewModuleRequest, jsonReturn, true);
                        default:
                            break;
                    }
                }
            }
            return FormatterSpeechResponse_CustomViewModule(customViewModuleRequest, $"I'm sorry, {customViewModuleRequest.IdDevice} was not found", false);
        }

        private object ConvertCustomViewModuleResquestToObject(CustomViewModuleRequest customViewModuleRequest)
        {

            var device = GetInformationDeviceById(customViewModuleRequest);

            if (device == null || device.Count() <= 0)
            {
                return null;
            }

            var objectType = device.Where(x => x.Key.Equals("ModelDevice")).Select(y => y.Value).FirstOrDefault();
            //TODO: valid objectType (!=null)

            //VALID DEVICE AND OBJECTTYPE
            switch ((DeviceEnum)Enum.Parse(typeof(DeviceEnum), objectType, true))
            {
                case DeviceEnum.SonoffDualR2:
                    {
                        int _channel = 1;//by default we use channel 1 (if is not mentioned in the object in appsettings.json
                        int.TryParse(device.Where(x => x.Key.Equals("Channel")).Select(y => y.Value).FirstOrDefault(), out _channel);

                        return new SonoffDualR2()
                        {
                            IdDevice = device.Where(x => x.Key.Equals("IP_Address")).Select(y => y.Value).FirstOrDefault(),
                            SonoffChannel = _channel,
                            SonoffRequestCommandEnum = ConvertStringCmdToSonoffRequestCommandEnum(customViewModuleRequest.Command)
                        };
                    }
                default:
                    return null;
            }
        }

        private IEnumerable<IConfigurationSection> GetInformationDeviceById(CustomViewModuleRequest customViewModuleRequest)
        {
            return repository.GetInformationDeviceById(customViewModuleRequest.IdDevice);
        }

        private string FormatterSpeechResponse_CustomViewModule(CustomViewModuleRequest customViewModuleRequest, string response, bool trimResponse)
        {

            if (!trimResponse)
            {
                return response;
            }

            response = response.Replace("\"", "").Replace("\\", "").Replace("}", "").Split(":")[1].ToLower();
            return $"{customViewModuleRequest.IdDevice} was turned {response}";
        }

        #endregion CustomViewModule
    }
}
