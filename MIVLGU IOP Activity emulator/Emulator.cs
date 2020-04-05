using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace MIVLGU_IOP_Activity_emulator
{
    class Net
    {
        public struct Response
        {
            public HttpWebResponse resp;
            public string str_resp;
            public string next_location;
            public Response(HttpWebResponse response, string str, string next_location) : this()
            {
                this.resp = response;
                this.str_resp = str;
                this.next_location = next_location;
            }
        }
        public struct RespJson
        {
            public string result { get; set; }
            public string token { get; set; }
        }
        public static Response SendRequest(string full_url, string reffer, string method, bool use_data = false,  string data = "")
        { 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(full_url);
           // request.Headers.Set(HttpRequestHeader.Referer,reffer);
            request.Referer = reffer;
            request.Method = method;
            request.Date = DateTime.Now;
            request.KeepAlive = true;
            
            if (use_data)
            {
                var ldata = Encoding.ASCII.GetBytes(data);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = ldata.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(ldata, 0, ldata.Length);
                }
            }
            

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {                
                    StreamReader input = new StreamReader(response.GetResponseStream());
                    string buff = input.ReadToEnd();
                    return new Response(response, buff, response.Headers[HttpRequestHeader.ContentLocation]);
                }
            }
            finally
            {
                request?.Abort();
            }
        }
    }
    class Emulator
    {
        private string login;
        private string password;
        public bool TryLogin(string login, string password)
        {
            bool ret = false;
            
            string testsession_location = Net.SendRequest("https://www.mivlgu.ru/iop/login/index.php", "https://www.mivlgu.ru/iop/login/index.php", "POST", true, "username=" + login
                + "&password=" + password
                + "&rememberusername=1").next_location;
            string login_location = Net.SendRequest(testsession_location, "https://www.mivlgu.ru/iop/login/index.php?username=" + login
                + "&password=" + password
                + "&rememberusername=1", "GET").next_location;
            MessageBox.Show(Net.SendRequest(login_location, "https://www.mivlgu.ru/iop/login/index.php?username=" + login
               + "&password=" + password
               + "&rememberusername=1", "GET").str_resp);
            return ret;
        }
    }
}
