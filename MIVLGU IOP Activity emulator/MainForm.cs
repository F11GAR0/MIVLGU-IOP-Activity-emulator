using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private void Log(string message)
        {
            lbLog.Items.Add(message);
        }
        private void bStart_Click(object sender, EventArgs e)
        {
            Log("trying to login...");
            if(emul.TryLogin(tbLogin.Text, tbPassword.Text))
            {
                Log("successful!");
            } else
            {
                Log("login failed.");
            }
        }
    }
}
