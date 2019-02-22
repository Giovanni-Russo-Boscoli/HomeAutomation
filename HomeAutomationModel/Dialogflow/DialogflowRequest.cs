using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HomeAutomationModel.Dialogflow.DialogflowRequest
{
    public partial class DialogflowRequest
    {
        [JsonProperty("responseId")]
        public Guid ResponseId { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("queryResult")]
        public QueryResult QueryResult { get; set; }

        [JsonProperty("originalDetectIntentRequest")]
        public OriginalDetectIntentRequest OriginalDetectIntentRequest { get; set; }
    }

    public class OriginalDetectIntentRequest
    {
    }

    public class QueryResult
    {
        [JsonProperty("queryText")]
        public string QueryText { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("allRequiredParamsPresent")]
        public bool AllRequiredParamsPresent { get; set; }

        [JsonProperty("fulfillmentText")]
        public string FulfillmentText { get; set; }

        [JsonProperty("fulfillmentMessages")]
        public FulfillmentMessage[] FulfillmentMessages { get; set; }

        [JsonProperty("outputContexts")]
        public OutputContext[] OutputContexts { get; set; }

        [JsonProperty("intent")]
        public Intent Intent { get; set; }

        [JsonProperty("intentDetectionConfidence")]
        public long IntentDetectionConfidence { get; set; }

        [JsonProperty("diagnosticInfo")]
        public OriginalDetectIntentRequest DiagnosticInfo { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }
    }

    public class FulfillmentMessage
    {
        [JsonProperty("text")]
        public Text Text { get; set; }
    }

    public class Text
    {
        [JsonProperty("text")]
        public string[] TextText { get; set; }
    }

    public class Intent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public class OutputContext
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lifespanCount")]
        public long LifespanCount { get; set; }

        [JsonProperty("parameters")]
        public object Parameters { get; set; }
    }

    public class Parameters
    {
        [JsonProperty("idDevice")]
        public string idDevice { get; set; }

        [JsonProperty("command")]
        public string command { get; set; }

    }

    public partial class DialogflowRequest
    {
        public static DialogflowRequest FromJson(string json) => JsonConvert.DeserializeObject<DialogflowRequest>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this DialogflowRequest self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    /*
     "responseId": "ea3d77e8-ae27-41a4-9e1d-174bd461b68c",
"session": "projects/your-agents-project-id/agent/sessions/88d13aa8-2999-4f71-b233-39cbf3a824a0",
"queryResult": {
"queryText": "user's original query to your agent",
"parameters": {
  "param": "param value"
},
"allRequiredParamsPresent": true,
"fulfillmentText": "Text defined in Dialogflow's console for the intent that was matched",
"fulfillmentMessages": [
  {
    "text": {
      "text": [
        "Text defined in Dialogflow's console for the intent that was matched"
      ]
    }
  }
],
"outputContexts": [
  {
    "name": "projects/your-agents-project-id/agent/sessions/88d13aa8-2999-4f71-b233-39cbf3a824a0/contexts/generic",
    "lifespanCount": 5,
    "parameters": {
      "param": "param value"
    }
  }
],
"intent": {
  "name": "projects/your-agents-project-id/agent/intents/29bcd7f8-f717-4261-a8fd-2d3e451b8af8",
  "displayName": "Matched Intent Name"
},
"intentDetectionConfidence": 1,
"diagnosticInfo": {},
"languageCode": "en"
},
"originalDetectIntentRequest": {}
*/
}
