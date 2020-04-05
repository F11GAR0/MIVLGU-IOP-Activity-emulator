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
        public static CookieContainer CC;
        public static Response SendRequest(string full_url, string reffer, string method, bool login = false, bool use_data = false,  string data = "")
        { 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(full_url);
           // request.Headers.Set(HttpRequestHeader.Referer,reffer);
            request.Referer = reffer;
            request.Method = method;
            request.Date = DateTime.Now;
            request.KeepAlive = true;
            if(login)
                CC = new CookieContainer();
            request.CookieContainer = CC;
            request.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 80.0.3987.149 Safari / 537.36";
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
                    return new Response(response, buff, response.ResponseUri.ToString());
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
        private string session_key;
        private List<string> page_links;
        private Random rand;
        public Emulator()
        {
            rand = new Random();
            page_links = new List<string>();
        }
        public void LoadPageList(List<string> pages)
        {
            this.page_links = pages;
        }
        public bool TryLogin(string login, string password)
        {
            this.login = login;
            this.password = password;
            bool ret = false;

            string testsession_location = Net.SendRequest("https://www.mivlgu.ru/iop/login/index.php", "https://www.mivlgu.ru/iop/login/index.php", "POST", true, true, "username=" + login
                + "&password=" + password
                + "&rememberusername=1").next_location;
            Net.Response last_resp = Net.SendRequest(testsession_location, "https://www.mivlgu.ru/iop/login/index.php", "GET");
            string login_location = last_resp.next_location;
            if (login_location == testsession_location)
            {
                last_resp = Net.SendRequest(testsession_location, "https://www.mivlgu.ru/iop/login/index.php", "GET");
                login_location = last_resp.next_location;
            }
            Net.Response base_resp = Net.SendRequest("https://www.mivlgu.ru/iop/", "https://www.mivlgu.ru/iop/", "GET");
            if (base_resp.str_resp.Contains("Вы зашли под именем"))
            {
                ret = true;
            }
            int sskeyind = base_resp.str_resp.IndexOf("sesskey"); //fuck go next
            sskeyind += "sesskey".Length;
            sskeyind = base_resp.str_resp.IndexOf("sesskey", sskeyind);

            string sessk = "";
            for (int i = sskeyind + "sesskey".Length + 1; i < sskeyind + 10 + "sesskey".Length + 1; i++)
            {
                if (base_resp.str_resp[i] == '\"') break;
                sessk += base_resp.str_resp[i];
            }
            this.session_key = sessk;
            return ret;
        }
        public void Out()
        {
            //https://www.mivlgu.ru/iop/login/logout.php?sesskey=dc99IPxcQW"
            var resp = Net.SendRequest("https://www.mivlgu.ru/iop/login/logout.php?sesskey=" + this.session_key, "https://www.mivlgu.ru/iop/", "GET");
            //MessageBox.Show(resp.str_resp.Substring(10000));
        }
        public struct PageRequestInfo
        {
            public bool isSuccessful;
            public string page;
            public int index_in_local_list;
            public PageRequestInfo(bool v1, string v2, int index) : this()
            {
                this.isSuccessful = v1;
                this.page = v2;
                this.index_in_local_list = index;
            }
        }
        public PageRequestInfo SendRandomPageRequest(int index = -1)
        {
            if (page_links.Count < 1) return new PageRequestInfo(false, "", -1);
            if(index == -1)
                index = rand.Next(page_links.Count);
            var resp = Net.SendRequest(page_links[index], "https://www.mivlgu.ru/iop/", "GET");
            return new PageRequestInfo(!resp.str_resp.Contains("Войдите в систему"), page_links[index], index);
        }
    }
}
