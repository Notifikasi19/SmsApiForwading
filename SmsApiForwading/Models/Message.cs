using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsApiForwading.Models
{
    public class Message
    {
        public Content content { get; set; }
        public DateTime sendDate { get; set; }
        public DateTime validUntil { get; set; }
        public To to { get; set; }
        public Tracking tracking { get; set; }
    }
    public class Content
    {
        public string body { get; set; }
    }
    public class CTN
    {
        public string phone { get; set; }
        // public string carrierCode { get; set; }
    }
    public class Subscriber
    {
        public string phone { get; set; }
        // public string carrierCode { get; set; }
    }
    public class To
    {
        public Subscriber subscriber { get; set; }
    }
    public class Tracking
    {
        public string code { get; set; }
    }
    public class RequestMessage
    {
        public List<Message> messages = new List<Message>();
    }
    public class ResquestSMS
    {
        public string phonenumber { get; set; }
        public string messagebody { get; set; }
    }
}