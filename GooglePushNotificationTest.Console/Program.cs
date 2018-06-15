﻿using System;
using System.Collections.Generic;
using System.Net.Http;

namespace GooglePushNotificationTest.App
{
    public class Program
    {
        private static readonly HttpClient Client = new HttpClient();

        private const string ChannelCreatedSuccessfully = "Channel created successfully";
        private const string GoogleEventChannelUrl = "https://www.googleapis.com/apiName/apiVersion/resourcePath/watch";
        private const string ReceivingUrl = "http://mywebsite.com/api/googlenotification/events";


        public static async void Main(string[] args)
        {
            var values = new Dictionary<string, string>()
            {
                { "Id", Guid.NewGuid().ToString() },
                { "Type", "web_hook" },
                { "Address", ReceivingUrl }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await Client.PostAsync(GoogleEventChannelUrl, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Channel created successfully.");
            }

            Console.WriteLine("Press any key to terminate...");
            Console.ReadKey();
        }
    }
}
