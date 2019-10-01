using Google.Apis.Dialogflow.v2.Data;
using HomeAutomationModel.CustomViewModule;
using HomeAutomationModel.Dialogflow.DialogflowRequest;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeAutomationService.Interface
{
    public interface IHomeAssistantService
    {
        Task<string> DeviceRequestCommand(DialogflowRequest sonoffRequest);

        Task<string> DeviceRequestCommandDialogFlow(GoogleCloudDialogflowV2WebhookRequest sonoffRequest);

        Task<string> DeviceRequestCommandCustomViewModule(CustomViewModuleRequest sonoffRequest);
    }
}
