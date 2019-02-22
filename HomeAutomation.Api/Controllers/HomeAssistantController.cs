using HomeAutomationModel.CustomViewModule;
using HomeAutomationModel.Dialogflow.DialogflowRequest;
using HomeAutomationModel.Dialogflow.DialogflowResponse;
using HomeAutomationService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace HomeAutomation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeAssistantController : Controller
    {

        private readonly IHomeAssistantService service;

        public HomeAssistantController(IHomeAssistantService service)
        {
            this.service = service;
        }

        #region Desenv

        //TODO: 10 segundos funcionando
        //      7 segundos parado
        //HOW TO FIX - CONFIGURATION/CONFIGURE OTHER AND DISABLE CHECKBOX "MQTT ENABLE" (http://192.168.0.18/co?)
         
        //how assert the intent directly by action, without necessity ask to "talk to smart helper" and then call the action/intent
        //HOW TO FIX - CREATE A SHORTCUT IN GOOGLE HOME (SHORTCUT WILL SAY: ROOM LIGHTS ON - AND YOU SET IT UP TO SAY - TASK TO 'NAME APP', 'COMMAND WANTED'

        [HttpPost]
        public async Task<JsonResult> DeviceRequestCommand([FromBody]DialogflowRequest dialogflowRequest)
        {
            if (dialogflowRequest == null || string.IsNullOrEmpty(dialogflowRequest.QueryResult.Parameters.idDevice))
            {
                return await FormatResposeDialogFlow("I'm sorry, but I didn't find the device");
            }
            return await FormatResposeDialogFlow(await service.DeviceRequestCommand(dialogflowRequest));
        }

        [HttpPost]
        public async Task<JsonResult> DeviceRequestCommandCustomViewModule(CustomViewModuleRequest customViewModuleRequest)
        {
            //TODO (validate command)
            if (customViewModuleRequest.IdDevice == null || string.IsNullOrEmpty(customViewModuleRequest.IdDevice))
            {
                return await FormatResposeCustomViewModule("I'm sorry, but I didn't find the device");
            }
            return await FormatResposeCustomViewModule(await service.DeviceRequestCommandCustomViewModule(customViewModuleRequest));
        }

        private void SendMessageByWhatsapp(string from, string message, string to, string nick)
        {
            string yourId = "3lcu6e2O+kSPy3mCusqMK2Jvc2NvbGlfZG90X2dpb3Zhbm5pX2F0X2dtYWlsX2RvdF9jb20=";
            string yourMobile = "+353830335169"; // TO (who will receive the message)
            string yourMessage = "What a great day.";
            try
            {
                string url = "https://NiceApi.net/API";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("X-APIId", yourId);
                request.Headers.Add("X-APIMobile", yourMobile);
                using (StreamWriter streamOut = new StreamWriter(request.GetRequestStream()))
                {
                    streamOut.Write(yourMessage);
                }
                using (StreamReader streamIn = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    Console.WriteLine(streamIn.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                string erro = e.Message;
            }
        }

        #endregion Desenv

        private async Task<JsonResult> FormatResposeDialogFlow(string responseSpeech)
        {
            //TODO: use dependecy injection
            //use constructor method to initialize the classes
            JsonResult jr = Json(new DialogflowResponse()
            {
                FulfillmentText = "Response coming from 'FormatResposeDialogFlow' API HOME AUTOMATION",
                Payload = new Payload()
                {
                    Google = new Google()
                    {
                        ExpectUserResponse = true,
                        RichResponse = new RichResponse()
                        {
                            Items = new Item[]
                               {
                              new Item()
                              {
                                  SimpleResponse = new SimpleResponse(){
                                      TextToSpeech = responseSpeech
                                  }
                              }
                               }
                        }
                    }
                }
            });

            return await Task.FromResult(jr);
        }

        private async Task<JsonResult> FormatResposeCustomViewModule(string responseSpeech)
        {
            //TODO: use dependecy injection
            //use constructor method to initialize the classes
            JsonResult jr = Json(new CustomViewModuleResponse()
            {
                Message = "Response coming from 'FormatResposeCustomViewModule' API HOME AUTOMATION",
            });

            return await Task.FromResult(jr);
        }
    }
}
