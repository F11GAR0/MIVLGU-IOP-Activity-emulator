using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIVLGU_IOP_Activity_emulator
{
    public partial class MainForm : Form
    {
        Emulator emul = new Emulator();
        public MainForm()
        {
            InitializeComponent();
        }
        public delegate void LogCb(string message);
        private void Log(string message)
        {
            string timestamp = "[" + DateTime.Now.Date.Day + ":" + DateTime.Now.Month + ":" + DateTime.Now.Year + " | " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "]: ";
            lbLog.Items.Add(timestamp + message);
            lbLog.TopIndex = lbLog.Items.Count - 1;
        }

        private System.Threading.Thread send_thread;

        private void SendThread()
        {
            Random rand = new Random();

            LogCb lLog = (m) =>
            {
                if (this.lbLog.InvokeRequired)
                {
                    LogCb cb = new LogCb(Log);
                    lbLog.Invoke(cb, new object[] { m });
                } else
                {
                    Log(m);
                }
            };

            lLog("Thread started.");
            while (true)
            {
                var local_resp = emul.SendRandomPageRequest();
                if (local_resp.isSuccessful)
                {
                    lLog("Sended enter to the " + local_resp.page + " page. " + "[DBG]: Index is " + local_resp.index_in_local_list.ToString());
                } else
                {
                    lLog("Failed to send reqest page " + local_resp.page + " [DBG]: Index is " + local_resp.index_in_local_list.ToString());
                    if (cbAutoLoginIfDisconnected.Checked)
                    {
                        lLog("Trying to login again.");
                        bool logined = false;
                        for(int i = 0; i < 10; i++)
                        {
                            lLog("Try #" + i.ToString());
                            if(emul.TryLogin(tbLogin.Text, tbPassword.Text))
                            {
                                lLog("Succesfuly logined!");
                                logined = true;
                                break;
                            } else
                            {
                                lLog("Failed to login...");
                                logined = false;
                            }
                        }
                        if (!logined) break;
                    }
                }
                int delay = 40000;
                if (cbRandomTimestamp.Checked)
                {
                    delay += rand.Next(10000, 20000);
                }
                System.Threading.Thread.Sleep(delay);
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            Log("trying to login...");
            if(emul.TryLogin(tbLogin.Text, tbPassword.Text))
            {
                Log("successful!");
                send_thread = new System.Threading.Thread(SendThread);
                send_thread.Start();
            } else
            {
                Log("login failed.");
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            send_thread.Abort();
            emul.Out();
            Log("succesfuly out");
        }

        private void bPageListLoad_Click(object sender, EventArgs e)
        {
            if(oFD.ShowDialog() == DialogResult.OK)
            {
                string[] data = File.ReadAllLines(oFD.FileName);
                List<string> pages = new List<string>();
                for(int i = 0; i < data.Length; i++)
                {
                    Uri ur;
                    
                    if(Uri.TryCreate(data[i], UriKind.Absolute, out ur)) {
                        Log("Added page: " + data[i]);
                        pages.Add(data[i]);
                    } else
                    {
                        Log("Failed to create URI for " + data[i] + " page");
                    }
                }
                emul.LoadPageList(pages);
                Log("Pages succesfuly loaded.");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            send_thread?.Abort();
            emul.Out();
        }
    }
}
