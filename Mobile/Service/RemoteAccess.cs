using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RemoteAccess
    {
        public string HOST_IP { get; set; }
        public string HOST_PORT { get; set; }
        public string USER_ID { get; set; }
        public string PHONE_PW { get; set; }
        public bool OnLine { get; set; }

        public static AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public async Task<List<MissCard>> Get_NoneAproMissCardByAproEmp(AproRequest request)
        {
            List<MissCard> result = new List<MissCard>();
            try
            {

                //芯怡 本機測試用
                //HOST_IP = "192.9.25.165";
                //HOST_PORT = "80";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(string.Format("http://{0}:{1}/)", HOST_IP, HOST_PORT));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //server                      
                string Route = $"AttendAPI/api/GetNoneAproMissCardByAproEmp";

                //local 
                //string Route = $"WebApi/api/GetNoneAproMissCardByAproEmp";
                
                
                // var json = JsonConvert.SerializeObject(new { as_emp = emp });
                var json = JsonConvert.SerializeObject(request);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Route, content);
                var webresponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<List<MissCard>>(webresponse);
                    result = data.OrderBy(x => x.attd_date).ToList();
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
            return result;
        }

        public async Task<bool> Set_AproMissCard(AproRequest request)
        {


            bool result = false;
            try
            {

                // 芯怡 本機測試用
                //HOST_IP = "192.9.25.165";
                //HOST_PORT = "80";



                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(string.Format("http://{0}:{1}/)", HOST_IP, HOST_PORT));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               

                //server
                string Route = $"AttendAPI/api/SetAproMissCard";

                //local
                //string Route = $"WebApi/api/SetAproMissCard";





                var json = JsonConvert.SerializeObject(request);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Route, content);
                var webresponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {

                    result = true;
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
            return result;





        }
    }
}
