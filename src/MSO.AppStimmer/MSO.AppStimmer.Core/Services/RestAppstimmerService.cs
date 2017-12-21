//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Net;
//using System.Threading.Tasks;
//using MSO.StimmApp.Core.Models;

//namespace MSO.StimmApp.Core.Services
//{
//    public class RestAppstimmerService : IAppStimmerService
//    {
//        public String RemoteBasetUrl;
//        public String LocalBaseUrl;
//        private List<AppStimmer> appStimmers = new List<AppStimmer>();

//        public RestAppstimmerService()
//        {
//            this.LocalBaseUrl = "127.0.0.1";
//            this.RemoteBasetUrl = "127.0.0.1";

//            //var json = await FetchAppstimmerAsync();
//            //this.appStimmers = ParseAppstimmer();


//        }

//        private async void InitializeAndLoad()
//        {
            
//        }

//        private void ParseAppstimmer(var json)
//        {
            
//        }

//        // Gets Appstimmers for passed URL.
//        private async Task<JsonValue> FetchAppstimmerAsync(string url)
//        {
//            // Create an HTTP web request using the URL:
//            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
//            request.ContentType = "application/json";
//            request.Method = "GET";

//            // Send the request to the server and wait for the response:
//            using (WebResponse response = await request.GetResponseAsync())
//            {
//                // Get a stream representation of the HTTP web response:
//                using (Stream stream = response.GetResponseStream())
//                {
//                    // Use this stream to build a JSON document object:
//                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
//                    Debug.WriteLine("Response: {0}", jsonDoc.ToString());

//                    // Return the JSON document:
//                    return jsonDoc;
//                }
//            }
//        }

//        public List<AppStimmer> GetAllAppStimmers()
//        {
//            return ParseAppstimmer(GetAllAppStimmers());
//        }

//        public void SaveAppStimmer(AppStimmer appStimmer)
//        {
//            throw new NotImplementedException();
//        }

//        public void DeleteAppStimmer(AppStimmer appStimmer)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}