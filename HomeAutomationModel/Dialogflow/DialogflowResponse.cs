﻿using Newtonsoft.Json;

namespace HomeAutomationModel.Dialogflow.DialogflowResponse
{
    public partial class DialogflowResponse
    {
        [JsonProperty("fulfillmentText")]
        public string FulfillmentText { get; set; }

        //[JsonProperty("fulfillmentMessages")]
        //public FulfillmentMessage[] FulfillmentMessages { get; set; }

        //[JsonProperty("source")]
        //public string Source { get; set; }

        [JsonProperty("payload")]
        public Payload Payload { get; set; }

        //[JsonProperty("outputContexts")]
        //public OutputContext[] OutputContexts { get; set; }

        //[JsonProperty("followupEventInput")]
        //public FollowupEventInput FollowupEventInput { get; set; }
    }
    
    public partial class Payload
    {
        [JsonProperty("google")]
        public MyGoogle MyGoogle { get; set; }

        //[JsonProperty("facebook")]
        //public Facebook Facebook { get; set; }

        //[JsonProperty("slack")]
        //public Facebook Slack { get; set; }
    }

    public partial class MyGoogle
    {
        [JsonProperty("expectUserResponse")]
        public bool ExpectUserResponse { get; set; }

        [JsonProperty("richResponse")]
        public RichResponse RichResponse { get; set; }
    }

    public partial class RichResponse
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("simpleResponse")]
        public SimpleResponse SimpleResponse { get; set; }
    }

    public partial class SimpleResponse
    {
        [JsonProperty("textToSpeech")]
        public string TextToSpeech { get; set; }
    }

    //public partial class Facebook
    //{
    //    [JsonProperty("text")]
    //    public string Text { get; set; }
    //}


    //public partial class FollowupEventInput
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("languageCode")]
    //    public string LanguageCode { get; set; }

    //    [JsonProperty("parameters")]
    //    public Parameters Parameters { get; set; }
    //}

    //public partial class Parameters
    //{
    //    [JsonProperty("param")]
    //    public string Param { get; set; }
    //}

    //public partial class FulfillmentMessage
    //{
    //    [JsonProperty("card")]
    //    public Card Card { get; set; }
    //}

    //public partial class Card
    //{
    //    [JsonProperty("title")]
    //    public string Title { get; set; }

    //    [JsonProperty("subtitle")]
    //    public string Subtitle { get; set; }

    //    [JsonProperty("imageUri")]
    //    public Uri ImageUri { get; set; }

    //    [JsonProperty("buttons")]
    //    public Button[] Buttons { get; set; }
    //}

    //public partial class Button
    //{
    //    [JsonProperty("text")]
    //    public string Text { get; set; }

    //    [JsonProperty("postback")]
    //    public Uri Postback { get; set; }
    //}

    //public partial class OutputContext
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("lifespanCount")]
    //    public long LifespanCount { get; set; }

    //    [JsonProperty("parameters")]
    //    public Parameters Parameters { get; set; }
    //}

    //public partial class DialogflowResponse
    //{
    //    public static DialogflowResponse FromJson(string json) => JsonConvert.DeserializeObject<DialogflowResponse>(json, Converter.Settings);
    //}

    //public static class Serialize
    //{
    //    public static string ToJson(this DialogflowResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    //}

    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters =
    //        {
    //            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
    //        },
    //    };
    //}
}
